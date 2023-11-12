using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Models;

namespace ReminderApp.Application.Abstractions.Services
{
    public interface IImageService
    {
        Task<bool> AddImageAsync(FileUpload fileUpload);

        Task<Image> GetImageAsync(Guid ImageId);

        Task<bool> AddImageToUserAsync(User user, FileUpload fileUpload);

        Task<bool> AssignUserDefaultImage(User user);
    }
}
