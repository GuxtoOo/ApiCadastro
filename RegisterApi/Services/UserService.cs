using AutoMapper;
using AvonalleRegisterApi.Domain.Models;
using AvonalleRegisterApi.DTOs;
using AvonalleRegisterApi.Infrastructure.Repositories.Interfaces;
using AvonalleRegisterApi.Services.Interfaces;

namespace AvonalleRegisterApi.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> PostAsync(UserDto model)
        {
            var user = new User(model.Logon, model.Password);
            user.EncryptPassword();

            await _userRepository.PostAsync(user);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> LoginAsync(string logon, string password)
        {
            var user = await _userRepository.GetByLogonAsync(logon);
            if (user != null && !user.ValidatePassword(password))
                return null;
            return _mapper.Map<UserDto>(user);
        }
    }
}
