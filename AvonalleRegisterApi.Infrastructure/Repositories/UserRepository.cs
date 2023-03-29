using AvonalleRegisterApi.Domain.Models;
using AvonalleRegisterApi.Infrastructure.Data;
using AvonalleRegisterApi.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AvonalleRegisterApi.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AvonalleContext _dataContext;

    public UserRepository(AvonalleContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task PostAsync(User model)
    {
        _dataContext.Add(model);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<User> GetByLogonAsync(string logon)
    {
        var entity = await _dataContext.Usuarios
            .Where(s => s.Logon == logon)
            .FirstOrDefaultAsync();
        return entity;
    }
}
