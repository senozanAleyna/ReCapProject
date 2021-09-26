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
            using (ReCapContext context=new ReCapContext())
            {
                var result= from car in context.Cars

                            join b in context.Brands
                            on car.BrandId equals b.BrandId

                            join c in context.Colors
                            on car.ColorId equals c.ColorId

                            select new CarDetailDto
                            {
                                Id=car.Id,
                                BrandId=car.BrandId,
                                ColorId=car.ColorId,
                                CarName = car.CarName,
                                BrandName = b.BrandName,
                                Description=car.Description,
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


    }
}
