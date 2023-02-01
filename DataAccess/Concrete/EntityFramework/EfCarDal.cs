using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.Name,
                                 CarName = car.Description,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                

                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands on car.BrandId equals brand.Id
                    join color in context.Colors on car.ColorId equals color.Id
                             where car.BrandId==brandId
                    select new CarDetailDto
                    {
                        CarId = car.Id,
                        BrandName = brand.Name,
                        CarName = car.Description,
                        ColorName = color.Name,
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear,
                       
                    };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands on car.BrandId equals brand.Id
                    join color in context.Colors on car.ColorId equals color.Id
                             where car.ColorId==colorId
                    select new CarDetailDto
                    {
                        CarId = car.Id,
                        BrandName = brand.Name,
                        CarName = car.Description,
                        ColorName = color.Name,
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear,
                    };
                return result.ToList();
            }
        }



        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands on car.BrandId equals brand.Id
                    join color in context.Colors on car.ColorId equals color.Id
                    where car.Id == carId
                             select new CarDetailDto
                    {
                        CarId = car.Id,
                        BrandName = brand.Name,
                        CarName = car.Description,
                        ColorName = color.Name,
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear,
                    };
                return result.ToList();
            }
        }
    }
}
