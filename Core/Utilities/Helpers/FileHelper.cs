using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        public static IResult Add(IFormFile file)
        {
            var checkFileExist = CheckFileExist(file);
            if (!checkFileExist.IsSuccess)
            {
                return checkFileExist;
            }

            var extension = Path.GetExtension(file.FileName);
            var checkFileTypeValid = CheckFileTypeValid(extension);
            if (!checkFileTypeValid.IsSuccess)
            {
                return checkFileTypeValid;
            }

            var newFileName = GetNewFileNameByGuid(file);
            var mainPath = GetMainPath();
            var fullPath = Path.Combine(mainPath, newFileName);

            try
            {
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult(fullPath);
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static IResult Update(IFormFile file, string sourcePath)
        {
            var deletedImage = Delete(sourcePath);
            if (!deletedImage.IsSuccess)
            {
                return deletedImage;
            }

            var addedImage = Add(file);
            if (!addedImage.IsSuccess)
            {
                return addedImage;
            }

            return new SuccessResult(addedImage.Message);
        }

        //--------------------Helper Methods--------------------
        public static IResult CheckFileExist(IFormFile file)
        {
            if (file.Length <= 0 || file == null)
            {
                return new ErrorResult("The file can not exist or null.");
            }
            return new SuccessResult();
        }

        public static IResult CheckFileTypeValid(string type)
        {
            type = type.ToLower();
            if (type != ".png" && type != ".jpeg" && type != ".jpg")
            {
                return new ErrorResult("The media type of file does not supported.");
            }
            return new SuccessResult();
        }

        public static string GetNewFileNameByGuid(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            var extension = fileInfo.Extension;
            var newFileName = Guid.NewGuid().ToString("D");
            var newFullFileName = newFileName + extension;
            return newFullFileName;
        }

        public static string GetMainPath()
        {
            var path = Path.Combine("D:\\Career\\Software\\CSharp\\Youtube-EnginDemirog\\CarRentalProject\\CarRentalProject", "Images");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string GetDefaultPath()
        {
            var path = GetMainPath();
            var defaultImageName = "default.png";
            var defaultImagePath = Path.Combine(path, defaultImageName);
            return defaultImagePath;
        }
    }
}
