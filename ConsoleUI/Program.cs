using System;
using System.Linq;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //GetAllColors(colorManager);
            //GetAllCars(carManager);
            //GetAllBrands(brandManager);

            //GetCarsByBrandId
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("{0} --- {1}",car.Description,car.BrandId);
            }

            //GetCarsByColorId
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("{0} --- {1}", car.Description, car.ColorId);
            }

            carManager.Add(new Car
            {
                Id = 3,
                BrandId = 3,
                Description = "Bmw 2008 model",
                ColorId = 1,
                DailyPrice = 1000,
                ModelYear = 2008
            });




        }

        private static void GetAllBrands(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void GetAllColors(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void GetAllCars(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
