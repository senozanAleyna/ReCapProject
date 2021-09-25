using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from rental in context.Rentals

                             join car in context.Cars
                             on rental.CarId equals car.Id

                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId

                             join user in context.Users
                             on rental.CustomerId equals user.UserId

                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId

                             select new RentalDetailDto
                             {
                                 Id = rental.RentalId,
                                 CarId=car.Id,
                                 Description = car.Description,
                                 Brand = brand.BrandName,
                                 ModelYear = car.ModelYear,
                                 CompanyName = customer.CompanyName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 FullName=user.FirstName+" "+user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            };
        }
    }
}
