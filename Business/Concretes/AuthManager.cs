using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Auth.Requests;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.Entities.Abstract;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concretes;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        IMapper _mapper;
        ITokenHelper _tokenHelper;
        AuthBusinessRules _authBusinessRules; 

        public AuthManager(IUserService userService, IMapper mapper, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _authBusinessRules = authBusinessRules;
        }
        public AccessToken CreateAccesToken(IUser user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return accessToken;

        }

        public async Task<IUser> Login(LoginRequest loginRequest)
        {
            return await _authBusinessRules.UserToCheck(loginRequest);

        }

        public async Task<IUser> Register(RegisterRequest registerRequest)
        {
            bool isRegister = await _authBusinessRules.CheckIfUserExists(registerRequest.Email);
            if (isRegister)
            {
                HashingHelper.CreatePasswordHash(registerRequest.Password, out registerRequest._passwordHash, out registerRequest._passwordSalt);
                User user = _mapper.Map<User>(registerRequest);
                CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(user);
                CreatedUserResponse createdUserResponse = await _userService.AddAsync(createUserRequest);
                return _mapper.Map<User>(createdUserResponse);
            }
            else
            {
                return null;
            }
        }
    }
}
