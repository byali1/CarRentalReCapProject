using System;
using System.Linq;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("--All Cars in DB--");

            GetAll(carManager);

            Console.WriteLine("\n--Updated Volvo and added BMW--");

            Car newCar = new Car
            {

                Id = 1,
                BrandId = 6,
                ColorId = 4,
                Description = "Volvo yeni",
                DailyPrice = 4000,
                ModelYear = 2022
            };

            Car newCar2 = new Car
            {

                Id =5,
                BrandId = 2,
                ColorId = 2,
                Description = "BMW",
                DailyPrice = 3000,
                ModelYear = 2020
            };

            carManager.Update(newCar);
            carManager.Add(newCar2);


            GetAll(carManager);

            Console.WriteLine("\n--Deleted Bmw--");

            carManager.Delete(newCar2);
            GetAll(carManager);
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
