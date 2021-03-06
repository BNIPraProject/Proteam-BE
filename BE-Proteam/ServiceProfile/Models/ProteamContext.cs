using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ServiceProfile.Models
{
    public partial class ProteamContext : DbContext
    {
        public ProteamContext()
        {
        }

        public ProteamContext(DbContextOptions<ProteamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<Jenjab> Jenjabs { get; set; }
        public virtual DbSet<Kelompok> Kelompoks { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        public virtual DbSet<Manday> Mandays { get; set; }
        public virtual DbSet<ResourceEmployee> ResourceEmployees { get; set; }
        public virtual DbSet<Skillset> Skillsets { get; set; }
        public virtual DbSet<UnitProfiling> UnitProfilings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-MF5H145R;Database=Proteam;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EmployeeSkill>(entity =>
            {
                entity.HasKey(e => e.EmpSkillId);

                entity.ToTable("EmployeeSkill");

                entity.Property(e => e.EmpSkillId).HasColumnName("EmpSkill_id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.SkillsetId).HasColumnName("Skillset_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeSkill_Employee_id");

                entity.HasOne(d => d.Skillset)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.SkillsetId)
                    .HasConstraintName("FK_EmployeeSkill_Skillset_id");
            });

            modelBuilder.Entity<Jenjab>(entity =>
            {
                entity.ToTable("Jenjab");

                entity.Property(e => e.JenjabId).HasColumnName("Jenjab_id");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("date");

                entity.Property(e => e.JenjangJabatan).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Kelompok>(entity =>
            {
                entity.ToTable("Kelompok");

                entity.Property(e => e.KelompokId).HasColumnName("Kelompok_id");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("date");

                entity.Property(e => e.Kelompok1)
                    .HasMaxLength(50)
                    .HasColumnName("Kelompok");

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Lookup>(entity =>
            {
                entity.ToTable("Lookup");

                entity.Property(e => e.LookupId).HasColumnName("Lookup_id");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Manday>(entity =>
            {
                entity.HasKey(e => e.MandaysId);

                entity.Property(e => e.MandaysId).HasColumnName("Mandays_id");

                entity.Property(e => e.ContractNumber).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("date");

                entity.Property(e => e.LastContract).HasColumnType("date");

                entity.Property(e => e.StartContract).HasColumnType("date");

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.VendorName).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(255);
            });

            modelBuilder.Entity<ResourceEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("ResourceEmployee");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Employee_id");

                entity.Property(e => e.ActiveDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .HasColumnName("Employee_name");

                entity.Property(e => e.JenjabId).HasColumnName("Jenjab_id");

                entity.Property(e => e.KelompokId).HasColumnName("Kelompok_id");

                entity.Property(e => e.LastWorkDate).HasColumnType("date");

                entity.Property(e => e.Npp)
                    .HasMaxLength(50)
                    .HasColumnName("NPP");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.ProjectExp)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TotalManhour).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Jenjab)
                    .WithMany(p => p.ResourceEmployees)
                    .HasForeignKey(d => d.JenjabId)
                    .HasConstraintName("FK_ResourceEmployee_Jenjab_id");

                entity.HasOne(d => d.Kelompok)
                    .WithMany(p => p.ResourceEmployees)
                    .HasForeignKey(d => d.KelompokId)
                    .HasConstraintName("FK_ResourceEmployee_Kelompok_id");
            });

            modelBuilder.Entity<Skillset>(entity =>
            {
                entity.ToTable("Skillset");

                entity.Property(e => e.SkillsetId).HasColumnName("Skillset_id");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("date");

                entity.Property(e => e.Skillset1)
                    .HasMaxLength(50)
                    .HasColumnName("Skillset");

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<UnitProfiling>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.ToTable("UnitProfiling");

                entity.Property(e => e.UnitId).HasColumnName("Unit_id");

                entity.Property(e => e.EmpSkillId).HasColumnName("EmpSkill_id");

                entity.Property(e => e.KelompokId).HasColumnName("Kelompok_id");

                entity.Property(e => e.TotalEmployee).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalManhour).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.EmpSkill)
                    .WithMany(p => p.UnitProfilings)
                    .HasForeignKey(d => d.EmpSkillId)
                    .HasConstraintName("FK_UnitProfiling_EmpSkill_id");

                entity.HasOne(d => d.Kelompok)
                    .WithMany(p => p.UnitProfilings)
                    .HasForeignKey(d => d.KelompokId)
                    .HasConstraintName("FK_UnitProfiling_Kelompok_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Npp)
                    .HasMaxLength(50)
                    .HasColumnName("NPP");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
