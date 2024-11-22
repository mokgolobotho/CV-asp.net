namespace CV.Data;

using CV.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<CVEntity> CV { get; set; }
    public DbSet<FilesEntity> Files { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<CVEntity>()
            .HasOne(cv => cv.File)
            .WithMany(file => file.Cvs)
            .HasForeignKey(cv => cv.FileId)
            .IsRequired();

        modelBuilder.Entity<CVEntity>().Property(cv => cv.FileId).ValueGeneratedOnAdd();
    }
}
