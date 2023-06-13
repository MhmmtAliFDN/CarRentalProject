using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            var checkResult = BusinessRules.Run(CheckIfCarImageLimitExceed(carImage.CarId));
            if (checkResult != null)
            {
                return checkResult;
            }

            var result = FileHelper.Add(file);
            if (!result.IsSuccess)
            {
                return result;
            }
            carImage.SetImagePath(result.Message);


            _carImageDal.Add(carImage);
            return new SuccessResult($"{Messages.CarImageAdded} Image Path: {result.Message}");
        }

        public IResult Delete(CarImage carImage)
        {
            var deletedFile = FileHelper.Delete(carImage.ImagePath);
            if (!deletedFile.IsSuccess)
            {
                return new ErrorResult(deletedFile.Message);
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<CarImage> Get(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.CarImageId == carImageId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count <= 0)
            {
                return new SuccessDataResult<List<CarImage>>(FileHelper.GetDefaultPath());
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var image = Get(carImage.CarImageId).Data;
            var updatedFile = FileHelper.Update(file, image.ImagePath);
            if (!updatedFile.IsSuccess)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.SetImagePath(updatedFile.Message);

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImageLimitExceed(int carId)
        {
            var result = GetImagesByCarId(carId);
            if (result.Data.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceed);
            }
            return new SuccessResult();
        }
    }
}
