using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        //bunun sayesinde sisteme ya giriş yapıcam ya da kayıt olucam
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email); //kullanıcı var mı ?
        IDataResult<AccessToken> CreateAccessToken(User user);
    }

}
