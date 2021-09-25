using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
        List<CustomerDetailDto> GetCustomerDetails();
        List<OperationClaim> GetClaims(User user); //ekstra bir metod var burada join atayacağım.
    }
}
