using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(Expression<Func<CarImage, bool>> filter);
        IDataResult<CarImage> GetById(int entityId);
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IResult Insert(IFormFile file, CarImage entity);
        IResult Update(IFormFile file, CarImage entity);
        IResult Delete(CarImage entity);


    }
}
