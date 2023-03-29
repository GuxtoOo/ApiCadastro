using AvonalleRegisterApi.Domain.Models;

namespace AvonalleRegisterApi.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    Task PostAsync(User model);
    Task<User> GetByLogonAsync(string logon);
}
