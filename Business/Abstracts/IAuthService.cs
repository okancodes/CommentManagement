using Business.Dtos.Auth.Requests;
using Core.Entities.Abstract;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        Task<IUser> Login(LoginRequest loginRequest);
        Task<IUser> Register(RegisterRequest registerRequest);
        AccessToken CreateAccesToken(IUser user);
    }
}
