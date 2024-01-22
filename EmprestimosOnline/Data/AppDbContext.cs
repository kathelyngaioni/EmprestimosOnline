using EmprestimosOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimosOnline.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<EmprestimosModel> Emprestimos { get; set; }
}