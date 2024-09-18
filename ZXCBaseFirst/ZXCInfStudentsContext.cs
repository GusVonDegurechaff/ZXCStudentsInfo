using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZXCBaseFirst
{
    public partial class ZXCInfStudentsContext : DbContext
    {
        public ZXCInfStudentsContext()
        {
        }

        public ZXCInfStudentsContext(DbContextOptions<ZXCInfStudentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Specialnost> Specialnosts { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1NMG4AP\\SQLEXPRESS;Database=ZXCInfStudents;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.SpecialnostId, "IX_Students_SpecialnostId");

                entity.Property(e => e.Fio).HasColumnName("FIO");

                entity.HasOne(d => d.Specialnost)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SpecialnostId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
