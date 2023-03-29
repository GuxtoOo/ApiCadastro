using AvonalleRegisterApi.Domain.Models;
using AvonalleRegisterApi.DTOs;

namespace AvonalleRegisterApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> PostAsync(UserDto model);
        Task<UserDto> LoginAsync(string logon, string password);
    }
}
