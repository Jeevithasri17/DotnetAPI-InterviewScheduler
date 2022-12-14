using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InterviewSchedulerAPI.InterviewSchedulerModel
{
    public partial class InterviewSchedulerDBContext : DbContext
    {
        public InterviewSchedulerDBContext()
        {
        }

        public InterviewSchedulerDBContext(DbContextOptions<InterviewSchedulerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<CandidateAvailability> CandidateAvailabilities { get; set; }
        public virtual DbSet<InterviewLevel> InterviewLevels { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Panel> Panels { get; set; }
        public virtual DbSet<PanelAvailability> PanelAvailabilities { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-478\\SQLSERVER2019;Database=InterviewSchedulerDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JobId).HasColumnName("Job_Id");

                entity.Property(e => e.LevelId).HasColumnName("Level_Id");

                entity.Property(e => e.Mobileno)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Resume)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CJFK");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CLFK");
            });

            modelBuilder.Entity<CandidateAvailability>(entity =>
            {
                entity.ToTable("CandidateAvailability");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AvailableDate)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CandidateId).HasColumnName("CandidateID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidateAvailabilities)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CFK");
            });

            modelBuilder.Entity<InterviewLevel>(entity =>
            {
                entity.ToTable("InterviewLevel");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LevelDes)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JobId)
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("JobID")
                    .HasComputedColumnSql("('KA-'+CONVERT([varchar](16),[id]))", false);

                entity.Property(e => e.JobRole)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Panel>(entity =>
            {
                entity.ToTable("Panel");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.Mobileno)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Panels)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PJFK");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Panels)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PLFK");
            });

            modelBuilder.Entity<PanelAvailability>(entity =>
            {
                entity.ToTable("PanelAvailability");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AvailableDate)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PanelId).HasColumnName("PanelID");

                entity.HasOne(d => d.Panel)
                    .WithMany(p => p.PanelAvailabilities)
                    .HasForeignKey(d => d.PanelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PFK");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CandidateId).HasColumnName("Candidate_id");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.PanelId).HasColumnName("Panel_id");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CFK1");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SJFK");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SLFK");

                entity.HasOne(d => d.Panel)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.PanelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PFK1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Rolename)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
