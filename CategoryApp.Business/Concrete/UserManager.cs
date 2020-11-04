using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using CategoryApp.Business.Abstract;
using CategoryApp.Business.Constants;
using CategoryApp.Core.Helpers.Security;
using CategoryApp.Core.Results;
using CategoryApp.DataAccess.Abstract;
using CategoryApp.Entities.Concrete;
using CategoryApp.Entities.Dtos;

namespace CategoryApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCheck = _userDal.Get(x => x.Username == userForRegisterDto.Username);
            if (userToCheck == null)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
                var user = new User
                {
                    Email = userForRegisterDto.Email,
                    Username = userForRegisterDto.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                _userDal.Add(user);
                return new SuccessDataResult<User>(user, Messages.UserRegistered);
            }
            else
            {
                return new ErrorDataResult<User>(Messages.UserAlreadyExists);
            }
        }
        public IDataResult<LoginDtoForResponse> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userDal.Get(x => x.Username == userForLoginDto.Username);
            if (userToCheck == null)
            {
                return new ErrorDataResult<LoginDtoForResponse>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<LoginDtoForResponse>(Messages.PasswordError);
            }
            Random rnd = new Random();
            var code = rnd.Next(1000, 9999).ToString();

            SendEmail(userToCheck.Email, "Kod", code);
            return new SuccessDataResult<LoginDtoForResponse>(new LoginDtoForResponse{Username = userForLoginDto.Username,Code = code}, Messages.SuccessfulLogin);
        }

        public IResult Confirm(LoginConfirmDto model, string code)
        {
            if (model.Code.Equals(code))
            {
                return  new SuccessResult(Messages.SuccessfulLogin);
            }
            else
            {
                return  new ErrorResult(Messages.AuthorizationFailed);
            }
        }

        public void SendEmail(string addressToSend, string title, string message)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.UseDefaultCredentials = false;
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("muhadikmen@gmail.com", "Şifre");
                client.EnableSsl = true;
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("muhadikmen@gmail.com");
                    mailMessage.To.Add(addressToSend);
                    mailMessage.IsBodyHtml = false;
                    mailMessage.Body = message;
                    mailMessage.Subject = title;
                    client.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
