using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UI.Models;

namespace UI
{
    public partial class ProjectXContext : DbContext
    {
        public ProjectXContext()
        {
        }

        public ProjectXContext(DbContextOptions<ProjectXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Consultant> Consultants { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-T1C8OQF;Database=ProjectX;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Company_Name");
            });

            modelBuilder.Entity<Consultant>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("First_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Last_name");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.Projects)
                    .WithMany(p => p.Consultants)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectsConsultant",
                        l => l.HasOne<Project>().WithMany().HasForeignKey("ProjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProjectsC__proje__3864608B"),
                        r => r.HasOne<Consultant>().WithMany().HasForeignKey("ConsultantId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProjectsC__consu__37703C52"),
                        j =>
                        {
                            j.HasKey("ConsultantId", "ProjectId").HasName("PK__Projects__03C2F50F3993A47D");

                            j.ToTable("ProjectsConsultants");

                            j.IndexerProperty<int>("ConsultantId").HasColumnName("consultant_Id");

                            j.IndexerProperty<int>("ProjectId").HasColumnName("project_Id");
                        });
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssignDate)
                    .HasColumnType("date")
                    .HasColumnName("Assign_date");

                entity.Property(e => e.CompanyId).HasColumnName("Company_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Projects__Compan__32AB8735");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
