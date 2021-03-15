using System;
using System.IO;
using System.Text.RegularExpressions;
using Library.Core.Enum;
using Library.Core.Extensions;
using Library.Core.Result.Abstract;
using Library.Core.Result.Concrete;
using Library.Entities.Entities.Dtos.ImageDto;

namespace Library.Data.ImageHelper
{
    public class ImageHelper : IImageHelper
    {
        private string _message;
        private readonly string _wwwroot;
        private const string ImgFolder = "img";
        private const string UserImagesFolder = "userImages";
        private const string BookImagesFolder = "bookImages";
        private const string WriterImagesFolder = "writerImages";
        private readonly string _runningPath = AppDomain.CurrentDomain.BaseDirectory;

        public ImageHelper()
        {
            _wwwroot = Directory.GetCurrentDirectory();
            if (Directory.Exists($"{_wwwroot}/{ImgFolder}")) return;
            Directory.CreateDirectory($"{_wwwroot}/{ImgFolder}/{UserImagesFolder}");
            Directory.CreateDirectory($"{_wwwroot}/{ImgFolder}/{BookImagesFolder}");
            Directory.CreateDirectory($"{_wwwroot}/{ImgFolder}/{WriterImagesFolder}");
            var defaultUser = $"{Path.GetFullPath(Path.Combine(_runningPath, @"..\..\"))}Resources\\defaultUser.png";
            var defaultRoot = $"{Path.GetFullPath(Path.Combine(_runningPath, @"..\..\"))}Resources\\defaultRoot.png";
            var defaultBook = $"{Path.GetFullPath(Path.Combine(_runningPath, @"..\..\"))}Resources\\defaultBook.png";
            var defaultWriter = $"{Path.GetFullPath(Path.Combine(_runningPath, @"..\..\"))}Resources\\defaultWriter.jpg";
            File.Copy(defaultUser, $"{_wwwroot}/{ImgFolder}/{UserImagesFolder}/defaultUser.png");
            File.Copy(defaultRoot, $"{_wwwroot}/{ImgFolder}/{UserImagesFolder}/defaultRoot.png");
            File.Copy(defaultBook, $"{_wwwroot}/{ImgFolder}/{BookImagesFolder}/defaultBook.png");
            File.Copy(defaultWriter, $"{_wwwroot}/{ImgFolder}/{WriterImagesFolder}/defaultWriter.jpg");
        }

        public IAppResult<ImageDeletedDto> Delete(string pictureName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{ImgFolder}/", pictureName);
            if (!File.Exists(fileToDelete))
                return new AppResult<ImageDeletedDto>().Fail(message:_message);
            var fileInfo = new FileInfo(fileToDelete);
            var imageDeletedDto = new ImageDeletedDto
            {
                FullName = pictureName,
                Extension = fileInfo.Extension,
                Path = fileInfo.FullName,
                Size = fileInfo.Length
            };
            File.Delete(fileToDelete);
            return new AppResult<ImageDeletedDto>().Success(imageDeletedDto);
        }
        public IAppResult<ImageUploadedDto> Upload(string name, string fileName, PictureType pictureType, string folderName = null)
        {
            /* Eğer folderName değişkeni null gelir ise, o zaman resim tipine göre (PictureType) klasör adı ataması yapılır. */
            if (folderName == null)
            {
                switch (pictureType)
                {
                    case PictureType.User:
                        folderName = UserImagesFolder;
                        break;
                    case PictureType.Book:
                        folderName = BookImagesFolder;
                        break;
                    case PictureType.Writer:
                        folderName = WriterImagesFolder;
                        break;
                }
            }

            /* Eğer folderName değişkeni ile gelen klasör adı sistemimizde mevcut değilse, yeni bir klasör oluşturulur. */
            if (!Directory.Exists($"{_wwwroot}/{ImgFolder}/{folderName}"))
                Directory.CreateDirectory($"{_wwwroot}/{ImgFolder}/{folderName}");

            /* Resimin yüklenme sırasındaki ilk adı oldFileName adlı değişkene atanır. */
            var oldFileName = Path.GetFileNameWithoutExtension(fileName);

            /* Resimin uzantısı fileExtension adlı değişkene atanır. */
            var fileExtension = Path.GetExtension(fileName);

            var regex = new Regex("[*'\",._&#^@]");
            name = regex.Replace(name, string.Empty);

            var dateTime = DateTime.Now;

            /*
            // Parametre ile gelen değerler kullanılarak yeni bir resim adı oluşturulur.
            // Örn: CengizhanDinar_587_5_38_12_3_10_2020.png
            */
            var newFileName = $"{name}_{dateTime.FullDateTimeWithUnderscore()}{fileExtension}";

            /* Kendi parametrelerimiz ile sistemimize uygun yeni bir dosya yolu (path) oluşturulur. */
            var path = Path.Combine($"{_wwwroot}/{ImgFolder}/{folderName}", newFileName);

            /* Sistemimiz için oluşturulan yeni dosya yoluna resim kopyalanır. */
            File.Copy(fileName, path);

            switch (pictureType)
            {
                /* Resim tipine göre kullanıcı için bir mesaj oluşturulur. */
                case PictureType.User:
                    _message = "Kullanıcı resmi ile ilgili bir sorun oluştur.";
                    break;
                case PictureType.Writer:
                    _message = "Yazar resmi ile ilgili bir sorun oluştur.";
                    break;
                case PictureType.Book:
                    _message = "Kitap kapak resmi ile ilgili bir sorun oluştur.";
                    break;
            }

            if (string.IsNullOrEmpty(folderName) || 
                string.IsNullOrEmpty(newFileName) || 
                string.IsNullOrEmpty(oldFileName) || 
                string.IsNullOrEmpty(path) || 
                string.IsNullOrEmpty(fileExtension))
            {
                return new AppResult<ImageUploadedDto>().Fail(message:_message);
            }
            var imageUploadedDto = new ImageUploadedDto
            {
                FullName = $"{folderName}/{newFileName}",
                OldName = oldFileName,
                Extension = fileExtension,
                FolderName = folderName,
                Path = path
            };
            return new AppResult<ImageUploadedDto>().Success(imageUploadedDto);
        }
    }
}