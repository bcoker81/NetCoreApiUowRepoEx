using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestCoreUow.Entities
{
    public partial class BPD01_Grant_ManagementContext : DbContext
    {
        public BPD01_Grant_ManagementContext()
        {
        }

        public BPD01_Grant_ManagementContext(DbContextOptions<BPD01_Grant_ManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditLog> AuditLog { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Extensions> Extensions { get; set; }
        public virtual DbSet<Grants> Grants { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=BPD01_Grant_Management;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(e => e.AuditId);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.HasIndex(e => e.FkGrantId)
                    .HasName("IX_FK_Grant_Id");

                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.Property(e => e.FkGrantId).HasColumnName("FK_Grant_Id");

                entity.HasOne(d => d.FkGrant)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.FkGrantId)
                    .HasConstraintName("FK_dbo.CommentModels_dbo.GrantModels_FK_Grant_Id");
            });

            modelBuilder.Entity<Extensions>(entity =>
            {
                entity.HasKey(e => e.GrantExtensionId);

                entity.HasIndex(e => e.FkGrantId)
                    .HasName("IX_FK_Grant_Id");

                entity.Property(e => e.ExtensionDate).HasColumnType("datetime");

                entity.Property(e => e.FkGrantId).HasColumnName("FK_Grant_Id");

                entity.HasOne(d => d.FkGrant)
                    .WithMany(p => p.Extensions)
                    .HasForeignKey(d => d.FkGrantId)
                    .HasConstraintName("FK_dbo.GrantExtensionModels_dbo.GrantModels_FK_Grant_Id");
            });

            modelBuilder.Entity<Grants>(entity =>
            {
                entity.Property(e => e.ApplicationDueDate).HasColumnType("datetime");

                entity.Property(e => e.ApplicationStatus).HasMaxLength(20);

                entity.Property(e => e.AwardDate).HasColumnType("datetime");

                entity.Property(e => e.ExtendedProjectDate).HasColumnType("datetime");

                entity.Property(e => e.FinancialReportDueDate).HasColumnType("datetime");

                entity.Property(e => e.GrantName).IsRequired();

                entity.Property(e => e.MshpGrantNumber).IsRequired();

                entity.Property(e => e.ProgrammingReportDueDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectEndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectStartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.HasKey(e => e.ReportId);

                entity.HasIndex(e => e.FkGrantId)
                    .HasName("IX_FK_Grant_Id");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FkGrantId).HasColumnName("FK_Grant_Id");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.ReportDate).HasColumnType("datetime");

                entity.HasOne(d => d.FkGrant)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.FkGrantId)
                    .HasConstraintName("FK_dbo.ReportDateModels_dbo.GrantModels_FK_Grant_Id");
            });
        }
    }
}
