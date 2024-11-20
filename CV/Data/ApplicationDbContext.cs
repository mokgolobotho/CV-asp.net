namespace CV.Data;
using CV.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<CVEntity> CVEntity { get; set; }
    public DbSet<FilesEntity> FilesEntity { get; set; }
}