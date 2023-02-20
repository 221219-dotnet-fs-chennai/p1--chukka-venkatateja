using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataEf.Entities;

public partial class VenkatContext : DbContext
{
    public VenkatContext()
    {
    }

    public VenkatContext(DbContextOptions<VenkatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comp> Comps { get; set; }

    public virtual DbSet<Edu> Edus { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-SCNR5TAF;Database=venkat;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comp>(entity =>
        {
            entity.HasKey(e => e.CompId).HasName("PK__comp__531653DD9A549A7F");

            entity.HasOne(d => d.Us).WithMany(p => p.Comps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usid_Comp");
        });

        modelBuilder.Entity<Edu>(entity =>
        {
            entity.HasKey(e => e.EduId).HasName("PK__edu__25833771CC9F1704");

            entity.HasOne(d => d.Us).WithMany(p => p.Edus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usid_edu");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__skills__FBBA83793BE2D0B4");

            entity.HasOne(d => d.Us).WithMany(p => p.Skills)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usid_skill");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__B9BE370F242E42CA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
