using System.Collections.Generic;
using CategoryApp.Core.Helpers.Security;
using CategoryApp.Core.Results;
using CategoryApp.Entities.Concrete;
using CategoryApp.Entities.Dtos;

namespace CategoryApp.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<LoginDtoForResponse> Login(UserForLoginDto userForLoginDto);
        IResult Confirm(LoginConfirmDto model, string code);
        void SendEmail(string addressToSend,string title, string message);
    }
}
