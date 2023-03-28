using Microsoft.EntityFrameworkCore;

namespace AvonalleRegisterApi.Infrastructure.Data;
public partial class AvonalleContext : DbContext
{
    public AvonalleContext(DbContextOptions<AvonalleContext> options)
        : base(options) { }

    public virtual DbSet<Produto> Produtos { get; set; } = null!;    
}