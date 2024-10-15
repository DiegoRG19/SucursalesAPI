using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QualaAPI.Models;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MonedaPru> MonedaPrus { get; set; }

    public virtual DbSet<SucursalesPru> SucursalesPrus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MonedaPru>(entity =>
        {
            entity.HasKey(e => e.IdMoneda).HasName("PK__Moneda_P__AA690671FBFEEDF5");

            entity.ToTable("Moneda_Pru");

            entity.Property(e => e.IdMoneda).ValueGeneratedNever();
            entity.Property(e => e.AbrevMoneda).HasMaxLength(3);
            entity.Property(e => e.NomMoneda).HasMaxLength(20);
        });

        modelBuilder.Entity<SucursalesPru>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Sucursal__06370DADBEB8F77A");

            entity.ToTable("Sucursales_Pru");

            entity.Property(e => e.Codigo).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Direccion).HasMaxLength(250);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Identificacion).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
