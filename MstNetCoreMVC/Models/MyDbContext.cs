using Microsoft.EntityFrameworkCore;

namespace MstNetCoreMVC.Models;

public partial class MyDbContext:DbContext
{
    private ModelBuilder _modelBuilder;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public MyDbContext(DbContextOptions options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
        SetTbKodePos();
    }

    public virtual DbSet<TbKodePos>? TbKodePos { get; set; }

    private void SetTbKodePos()
    {
        _modelBuilder.Entity<TbKodePos>().ToTable("TbKodePos");
        _modelBuilder.Entity<TbKodePos>().HasKey("Id");
    }

}
