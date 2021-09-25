using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //AddCar(carManager);
            //CarDetails(carManager);
            //ColorTest(colorManager);
            //userManager.Add(new User() { Email="aleynasnzn@gmail.com", FirstName="Aleyna", LastName="Senozan", Password="123123" });
            //customerManager.Add(new Customer() { UserId = 1, CompanyName = "aleys" });
            //RentalTest(rentalManager);


            //RentalDetails(rentalManager);

        }

        private static void RentalDetails(RentalManager rentalManager)
        {
            var result = rentalManager.GetRentalDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + "/" + car.Brand + "/" + car.Description);
                    Console.WriteLine(car.FirstName + "/" + car.LastName + "/" + car.CompanyName);
                    Console.WriteLine("---------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalTest(RentalManager rentalManager)
        {
            rentalManager.Add(new Rental()
            {
                CarId = 2002,
                CustomerId = 1,
                RentDate = new DateTime(2021, 06, 22),
                ReturnDate = new DateTime(2021, 07, 22),
            });
        }

        private static void ColorTest(ColorManager colorManager)
        {
            //colorManager.Add(new Color() { ColorName = "Black" });
            //colorManager.Update(new Color() { ColorId = 5, ColorName = "Yellow" });
            var result = colorManager.GetAll();
            if (result.Success == true)
            {

                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorId + "/" + color.ColorName);
                }
               
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarDetails(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "/" + car.CarName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddCar(CarManager carManager)
        {
            carManager.Add(new Car() { BrandId = 4, ColorId = 1, DailyPrice = 1100, ModelYear = 2015, Description = "classic" });
            carManager.Add(new Car() { BrandId = 2, ColorId = 3, DailyPrice = 600, ModelYear = 2012, Description = "sporty" });
            //carManager.Delete(new Car() { Id = 1010, BrandId = 4, ColorId = 1, DailyPrice = 1100, ModelYear = 2015, Description = "classic" });
        }
    }
}
