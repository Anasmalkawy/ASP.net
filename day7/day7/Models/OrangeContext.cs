using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace day7.Models;

public partial class OrangeContext : DbContext
{
    public OrangeContext()
    {
    }

    public OrangeContext(DbContextOptions<OrangeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Info> Infos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ANAS;Database=orange;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Info>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__info__3214EC078C1859A0");

            entity.ToTable("info");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07C10F9FE4");

            entity.Property(e => e.Img)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Info)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("info");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
