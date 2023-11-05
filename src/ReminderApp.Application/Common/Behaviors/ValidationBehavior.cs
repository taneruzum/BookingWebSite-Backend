using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ReminderApp.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                List<ValidationFailure> failures = _validators
                                             .Select(validator => validator.Validate(context))
                                             .SelectMany(result => result.Errors)
                                             .Where(failure => failure != null)
                                             .ToList();
                if (failures.Count != 0) throw new FluentValidation.ValidationException(failures);
            }
            return next();
        }
    }
}
