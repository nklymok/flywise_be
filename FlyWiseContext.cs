using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlyWiseBackendDbFirst;

public partial class FlyWiseContext : DbContext
{
    public FlyWiseContext()
    {
    }

    public FlyWiseContext(DbContextOptions<FlyWiseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airplane> Airplanes { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Filename=C:\\\\Users\\\\nazariiklymok\\\\source\\\\repos\\\\FlyWise\\\\FlyWiseBackend\\\\FlyWiseBackend\\\\FlyWise.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasIndex(e => e.AirplaneId, "IX_Passengers_AirplaneId");

            entity.HasOne(d => d.Airplane).WithMany(p => p.Passengers).HasForeignKey(d => d.AirplaneId);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasIndex(e => e.AirplaneId, "IX_Tickets_AirplaneId");

            entity.HasIndex(e => e.PassengerId, "IX_Tickets_PassengerId");

            entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.Airplane).WithMany(p => p.Tickets).HasForeignKey(d => d.AirplaneId);

            entity.HasOne(d => d.Passenger).WithMany(p => p.Tickets).HasForeignKey(d => d.PassengerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
