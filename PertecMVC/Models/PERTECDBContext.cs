using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PertecMVC.Models
{
    public partial class PERTECDBContext : DbContext
    {
        public PERTECDBContext()
        {
        }

        public PERTECDBContext(DbContextOptions<PERTECDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeInOut> EmployeeInOuts { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<JobHistory> JobHistories { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<VwEmployee> VwEmployees { get; set; } = null!;
        public virtual DbSet<VwEmployeeHistory> VwEmployeeHistories { get; set; } = null!;
        public virtual DbSet<VwEmployeeJob> VwEmployeeJobs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdNumber)
                    .HasName("PK__EMPLOYEE__92061597005B268E");

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ID_NUMBER");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.CurrentJob).HasColumnName("CURRENT_JOB");

                entity.Property(e => e.CurrentStatus).HasColumnName("CURRENT_STATUS");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");

                entity.HasOne(d => d.CurrentJobNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CurrentJob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_JOB");
            });

            modelBuilder.Entity<EmployeeInOut>(entity =>
            {
                entity.ToTable("EMPLOYEE_IN_OUTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.EmployeeIdNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_ID_NUMBER");

                entity.Property(e => e.OutReason)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("OUT_REASON");

                entity.Property(e => e.Type)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.HasOne(d => d.EmployeeIdNumberNavigation)
                    .WithMany(p => p.EmployeeInOuts)
                    .HasForeignKey(d => d.EmployeeIdNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_IN_OUTS_EMPLOYEE");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("JOB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<JobHistory>(entity =>
            {
                entity.ToTable("JOB_HISTORY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeIdNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_ID_NUMBER");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.JobId).HasColumnName("JOB_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE");

                entity.HasOne(d => d.EmployeeIdNumberNavigation)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.EmployeeIdNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_HISTORY_EMPLOYEE");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_HISTORY_JOB");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("STATUS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<VwEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_EMPLOYEES");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.CurrentJob)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CURRENT_JOB");

                entity.Property(e => e.CurrentStatus)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CURRENT_STATUS");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ID_NUMBER");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");
            });

            modelBuilder.Entity<VwEmployeeHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_EMPLOYEE_HISTORY");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ID_NUMBER");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.OutReason)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("OUT_REASON");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<VwEmployeeJob>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_EMPLOYEE_JOBS");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ID_NUMBER");

                entity.Property(e => e.JobDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("JOB_DESCRIPTION");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
