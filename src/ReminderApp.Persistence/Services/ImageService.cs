using Microsoft.AspNetCore.Http;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Models;
using ReminderApp.Domain.Constats;
using ReminderApp.Application.Extensions;

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
            if (!await _unitOfWork.GetReadRepository<Image>().AnyAsync(i => i.Name == Constat.DefaultImage))
            {
                await _unitOfWork.GetWriteRepository<Image>().CreateAsync(new() { Name = Constat.DefaultImage, Path = Constat.DefaultImagePath, FileType = Domain.Enums.FileType.image, Photo = Constat.DefaultImagePhoto.HexStringToByteArray(), isActive = true, CreatedDate = DateTime.Now, Id = Guid.Parse(Constat.DefaultImageId) });
            }

            bool imageUserRes = await _unitOfWork.GetWriteRepository<ImageUser>().CreateAsync(new() { ImageId = Guid.Parse(Constat.DefaultImageId), UserId = user.Id });

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
