using Library.Core.Enum;
using Library.Core.Result.Abstract;
using Library.Entities.Entities.Dtos.ImageDto;

namespace Library.Data.ImageHelper
{
    public interface IImageHelper
    {
        IAppResult<ImageDeletedDto> Delete(string pictureName);
        IAppResult<ImageUploadedDto> Upload(string name, string fileName, PictureType pictureType, string folderName = null);
    }
}