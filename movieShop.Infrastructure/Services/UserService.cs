using movieShop.Core.Entities;
using movieShop.Core.Models.Request;
using movieShop.Core.Models.Response;
using movieShop.Core.RepositoryInterfaces;
using movieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace movieShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;

        public UserService(IUserRepository repository, ICryptoService cryptoService)
        {
            _userRepository = repository;
            _cryptoService = cryptoService;
        }

        public async Task<UserRegisterResponseModel> CreateUser(UserRegisterRequestModel requestModel)
        {
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);
            if (dbUser != null && string.Equals(dbUser.Email, requestModel.Email, StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Email Already Exits");

            // first is to create unique random salt
            string salt = _cryptoService.CreateSalt();
            string hashedPassword = _cryptoService.HashPassword(requestModel.Password, salt);

            var user = new User
            {
                Email = requestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName
            };
            var createdUser = await _userRepository.AddAsync(user);
            var response = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };
            return response;
        }

        public Task<User> GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserRegisterResponseModel> GetUserDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserLoginResponseModel> ValidateUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user is null) return null;
            var hashedPassword = _cryptoService.HashPassword(password, user.Salt);
            var isSuccess = user.HashedPassword == hashedPassword;

            //var response = _mapper.Map<UserLoginResponseModel>(user);

            var response = new UserLoginResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth
            };            //var response = _mapper.Map<UserLoginResponseModel>(user);            //var userRoles = roles.ToList();
            //if (userRoles.Any())
            //{
            //    response.Roles = userRoles.Select(r => r.Role.Name).ToList();
            //}
            if (isSuccess)
                return response;
            else
                return null;
        }
    }
}
