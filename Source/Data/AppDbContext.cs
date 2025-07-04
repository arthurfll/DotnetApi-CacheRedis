using Microsoft.EntityFrameworkCore;
using Source.Models;


namespace Source.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }
  public DbSet<ToDo> ToDos { get; set; }
}