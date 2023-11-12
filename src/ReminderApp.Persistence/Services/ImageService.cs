using Microsoft.AspNetCore.Http;
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
        private bool imageResult;
        public ImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            saveResult = 0;
            imageResult = false;
        }

        public async Task<bool> AddImageAsync(FileUpload fileUpload)
        {
            var fileBytes = GetByteToImage(fileUpload.File);

            await _unitOfWork.GetWriteRepository<Image>().CreateAsync(new() { Name = fileUpload.Name, Path = fileUpload.Path, Photo = fileBytes });
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddImageToUserAsync(User user, FileUpload fileUpload)
        {
            var fileBytes = GetByteToImage(fileUpload.File);

            Image image = new() { Name = fileUpload.Name, Path = fileUpload.Path, Photo = fileBytes, FileType = Domain.Enums.FileType.image, ContentType = Domain.Enums.ContentType.jpeg };

            imageResult = await _unitOfWork.GetWriteRepository<Image>().CreateAsync(image);

            bool imageUserRes = await _unitOfWork.GetWriteRepository<ImageUser>().CreateAsync(new() { ImageId = image.Id, UserId = user.Id });

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> AssignUserDefaultImage(User user)
        {
            bool imageUserRes = await _unitOfWork.GetWriteRepository<ImageUser>().CreateAsync(new() { ImageId = Guid.Parse(ReminderApp.Domain.Constats.Constat.DefaultImage), UserId = user.Id });

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<Image> GetImageAsync(Guid ImageId)
            => await _unitOfWork.GetReadRepository<Image>().GetAsync(i => i.Id == ImageId);

        private byte[] GetByteToImage(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
