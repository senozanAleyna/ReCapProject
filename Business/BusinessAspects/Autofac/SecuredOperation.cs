using Core.Utilities.Interceptors;
using Core.Utilities.Ioc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constans;

namespace Business.BusinessAspects.Autofac
{
    //JWT
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//istek yapıldığında aynı anda binlerce istek yapılablir
        //herkese bir tane thread oluşturulur.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); //roller virgülle ayrılarak veriliyor.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //aspects zincir içinde(business-data access vs) olmadığı için injection yaparsan web apı bunu gormez
            //web api değilde windows form kullandın diyelim bunu service tool sayesinde görülcek
        }


        //methodun önünde çalıştır demektir.
        //yani adamın yetkisi var mı diye bak
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles(); //rollerini bul
            foreach (var role in _roles) //rollerini gez
            {
                if (roleClaims.Contains(role))//ilgili rol varsa
                {
                    return;//metodu çalıştırmaya devam et
                }
            }
            throw new Exception(Messages.AuthorizationDenied); //yoksa yetkin yok hatası ver
        }
    }
}
