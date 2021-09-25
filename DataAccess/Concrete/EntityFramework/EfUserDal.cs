using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
           
                using (ReCapContext context = new ReCapContext())
                {
                    var result = from c in context.Customers
                                 join u in context.Users
                                  on c.CustomerId equals u.UserId

                                 select new CustomerDetailDto
                                 {
                                     CustomerID = c.CustomerId,
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     Email = u.Email,
                                     CompanyName = c.CompanyName,
                                     PasswordHash = u.PasswordHash,
                                     PasswordSalt = u.PasswordSalt,
                                     Status = u.Status
                                 };
                    return result.ToList();
                }   
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

    }
}
