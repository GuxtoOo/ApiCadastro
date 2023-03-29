using AvonalleRegisterApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AvonalleRegisterApi.Infrastructure.Data;
public partial class AvonalleContext : DbContext
{
    public AvonalleContext(DbContextOptions<AvonalleContext> options)
        : base(options) { }

    public virtual DbSet<Product> Produtos { get; set; } = null!;
    public virtual DbSet<User> Usuarios { get; set; } = null!;
}