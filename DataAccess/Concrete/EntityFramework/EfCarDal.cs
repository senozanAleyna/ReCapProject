using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars

                             join b in context.Brands
                             on car.BrandId equals b.BrandId

                             join c in context.Colors
                             on car.ColorId equals c.ColorId

                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandId = car.BrandId,
                                 ColorId = car.ColorId,
                                 CarName = car.CarName,
                                 BrandName = b.BrandName,
                                 Description = car.Description,
                                 ColorName = c.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 //CarId = car.Id,
                                 //ModelYear = car.ModelYear,

                             };
                return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();

            }
        }

        public CarDetailDto GetCarDetails(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             where carId == c.Id
                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Id = c.Id,
                                 Description = c.Description
                             };
                return result.FirstOrDefault();


            }
        }

    }
}
