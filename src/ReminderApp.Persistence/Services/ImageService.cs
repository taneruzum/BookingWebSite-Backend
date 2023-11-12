using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Models;

namespace ReminderApp.Persistence.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private int saveResult;
        bool imageResult;
        public ImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            saveResult = 0;
            imageResult = false;
        }

        public async Task<bool> AddImageAsync(FileUpload fileUpload)
        {
            using (var ms = new MemoryStream())
            {
                fileUpload.File.CopyTo(ms);
                var fileBytes = ms.ToArray();
                await _unitOfWork.GetWriteRepository<Image>().CreateAsync(new() { Name = fileUpload.Name, Path = fileUpload.Path, Photo = fileBytes });
                return await _unitOfWork.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> AddImageToUserAsync(User user, FileUpload fileUpload)
        {
            using (var ms = new MemoryStream())
            {
                fileUpload.File.CopyTo(ms);

                var fileBytes = ms.ToArray();

                Image image = new() { Name = fileUpload.Name, Path = fileUpload.Path, Photo = fileBytes, FileType = Domain.Enums.FileType.image, ContentType = Domain.Enums.ContentType.jpeg };

                imageResult = await _unitOfWork.GetWriteRepository<Image>().CreateAsync(image);

                bool imageUserRes = await _unitOfWork.GetWriteRepository<ImageUser>().CreateAsync(new() { ImageId = image.Id, UserId = user.Id });

                return await _unitOfWork.SaveChangesAsync() > 0;
            }
        }

        public async Task<Image> GetImageAsync(Guid ImageId)
            => await _unitOfWork.GetReadRepository<Image>().GetAsync(i => i.Id == ImageId);
    }
}
