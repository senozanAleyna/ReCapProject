### General info
This project is the backend side of RentACar project in my repositories. You can check the front end project here =><a href="https://github.com/senozanAleyna/recap-frontend">RentACarFrontEnd</a>

The project consists of 5 layers: Entities, DataAccess, Business, Core and WebAPI.  
Each operation is controlled by its own manager that uses Dal classes to implement crud operations. All data access layers implement generic IEntityRepository interface as a common outline.

Autofac IoC Container is used for Dependency Injection and Aspect Oriented Programming was implemented.
(Aspects: ValidationAspect, CacheAspect, CacheRemoveAspect, PerformanceAspect, SecuredOperationAspect, TransactionAspect).

Validation is a Cross Cutting Concern and as regard of AOP, Validation Aspect is created with Autofac using Interceptors. 
FluentValidation is the Validation Tool used for the verification process.

### Backend Tecnologies
- Asp.Net Core for Restful api
- MsSql
- EntityFramework Core
- Autofac
- FluentValidation

### Backend Techniques
- Layered Architecture Design Pattern
- AOP
- JWT
- Autofac dependency resolver
- IOC
- Aspects
- File upload

## Packages

- Asp.Net Core 3.1
- .Net Framework 4.5
- Microsoft.EntityFrameworkCore.SqlServer 3.1.0
- Microsoft.EntityFrameworkCore 3.1.0
- FluentValidation 9.5.1
- Autofac 6.1.0
- Autofac.Extras.DynamicProxy 6.0.0
- Autofac.Extensions.DependencyInjection 7.1.0
- Microsoft.Extensions.DependencyInjection 5.0.1
- Microsoft.AspNetCore.Hosting.Abstractions 2.2.0
- Microsoft.AspNetCore.Http 2.2.2
- Microsoft.AspNetCore.Http.Features 5.0.3
- Microsoft.IdentityModel.Tokens 6.8.0
- System.IdentityModel.tokens.Jwt 6.8.0
- Microsoft.AspNetCore.Authentication.JwtBearer 3.1.12
- Microsoft.AspNetCore.Mvc.NewtonsoftJson 3.1.10
- Microsoft.AspNetCore.Http.Abstractions 2.2.0
