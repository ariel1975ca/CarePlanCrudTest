using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarePlanWebApi.DataLayer.Models
{
    public partial class CarePlanDBContext : DbContext
    {
        public CarePlanDBContext()
        {
        }

        public CarePlanDBContext(DbContextOptions<CarePlanDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TcarePlan> TcarePlan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TcarePlan>(entity =>
            {
                entity.HasKey(e => e.IdCarePlan);

                entity.ToTable("TCarePlan");

                entity.Property(e => e.IdCarePlan).HasColumnName("ID_CarePlan");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ActualStartDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Outcome).HasMaxLength(1000);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.TargetDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
