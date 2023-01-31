using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;

using Core.Aspects.Autofac.Validation;

using Core.Utilities.Results;

using DataAccess.Abstract;

using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.FileHelper;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private const string DefaultCarImagePath = "/Uploads/Images/defaultImage.jpg";
        private const int ServerMaintenanceHour = 0;
        private ICarImageDal _carImagesDal;
        private IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImagesDal, IFileHelper fileHelper)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            if (DateTime.Now.Hour == ServerMaintenanceHour)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll());
        }

        public IDataResult<CarImage> Get(Expression<Func<CarImage, bool>> filter)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(filter), Messages.SuccessfullyRetrieved);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(x => x.Id == carImageId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Insert(IFormFile file, CarImage carImages)
        {
            var result = BusinessRules.Run(GetCarImagesLimitExceeded(carImages.CarId));

            if (result != null)
            {
                return result;
            }
            SetDefaultCarImageOrNot(file, carImages);
            _carImagesDal.Add(carImages);
            return new SuccessResult(Messages.ImageUploaded);
        }

        private IResult GetCarImagesLimitExceeded(int carId)
        {
            var result = _carImagesDal.GetAll(x => x.CarId == carId).Count();
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImagesLimitExceeded);
            }

            return new SuccessResult();
        }

        private void SetDefaultCarImageOrNot(IFormFile file, CarImage carImages)
        {
            if (file == null)
            {
                carImages.ImagePath = "/Uploads/Images/defaultImage.jpg";
            }
            else
            {
                var imageResult = _fileHelper.Upload(file);
                carImages.ImagePath = imageResult.Message;
            }
        }

        private void UpdateImage(IFormFile file, CarImage carImages)
        {
            var result = _carImagesDal.GetAll().Single(x => x.Id == carImages.Id).ImagePath;


            if (carImages.ImagePath == DefaultCarImagePath && file != null)
            {
                var imageResult = _fileHelper.Upload(file);
                carImages.ImagePath = imageResult.Message;
            }
            else if (file == null && result == DefaultCarImagePath)
            {
                carImages.ImagePath = "/Uploads/Images/defaultImage.jpg";
            }
            else if (file == null && result != DefaultCarImagePath)
            {
                FileHelperManager fileHelper = new FileHelperManager();
                fileHelper.Delete(result);
                carImages.ImagePath = "/Uploads/Images/defaultImage.jpg";
            }
            else
            {
                var imageResult = _fileHelper.Update(file, carImages.ImagePath);
                carImages.ImagePath = imageResult.Message;
            }
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImages)
        {
            UpdateImage(file, carImages);
            _carImagesDal.Update(carImages);
            return new SuccessResult(Messages.ImageUpdated);
        }

        public IResult IsCarExisted(int id)
        {
            var result = _carImagesDal.GetAll(x => x.Id == id);
            if (result == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImages)
        {
            var result = BusinessRules.Run(IsCarExisted(carImages.Id));

            if (result != null)
            {
                return new ErrorResult(Messages.CarNotExisted);
            }

            _fileHelper.Delete(carImages.ImagePath);
            _carImagesDal.Delete(carImages);
            return new SuccessResult(Messages.ImageDeleted);



        }
    }
}