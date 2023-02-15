using System;
using System.Collections.Generic;
using GymApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Models.Services.Insfrastructure;

public partial class GymAppDbContext : DbContext
{
    public GymAppDbContext()
    {
    }

    public GymAppDbContext(DbContextOptions<GymAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Measurment> Measurments { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<PlansRow> PlansRows { get; set; }

    public virtual DbSet<Rep> Reps { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Data/gymApp.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.Property(e => e.Description)
                .HasColumnType("TEXT(10000)")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("TEXT(100)")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Measurment>(entity =>
        {
            entity.Property(e => e.Bicep)
                .HasColumnType("TEXT(50)")
                .HasColumnName("bicep");
            entity.Property(e => e.Calf)
                .HasColumnType("TEXT(50)")
                .HasColumnName("calf");
            entity.Property(e => e.Chest)
                .HasColumnType("TEXT(50)")
                .HasColumnName("chest");
            entity.Property(e => e.Gluteus)
                .HasColumnType("TEXT(50)")
                .HasColumnName("gluteus");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Waistline)
                .HasColumnType("TEXT(50)")
                .HasColumnName("waistline");

            entity.HasOne(d => d.User).WithMany(p => p.Measurments).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Plan>(entity =>
        {
            entity.Property(e => e.CreationDate)
                .HasColumnType("DATETIME")
                .HasColumnName("creation_date");
            entity.Property(e => e.EndDate)
                .HasColumnType("END_DATE")
                .HasColumnName("end_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("START_DATE")
                .HasColumnName("start_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Plans).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<PlansRow>(entity =>
        {
            entity.ToTable("Plans_Rows");

            entity.Property(e => e.Band)
                .HasColumnType("TEXT(30)")
                .HasColumnName("band");
            entity.Property(e => e.ExecutedReps)
                .HasColumnType("TEXT(50)")
                .HasColumnName("executed_reps");
            entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");
            entity.Property(e => e.PlanId).HasColumnName("plan_id");
            entity.Property(e => e.RepsId).HasColumnName("reps_id");
            entity.Property(e => e.Rest)
                .HasColumnType("TEXT(20)")
                .HasColumnName("rest");
            entity.Property(e => e.WeekNumber).HasColumnName("week_number");
            entity.Property(e => e.Weight)
                .HasColumnType("TEXT(10)")
                .HasColumnName("weight");

            entity.HasOne(d => d.Exercise).WithMany(p => p.PlansRows).HasForeignKey(d => d.ExerciseId);

            entity.HasOne(d => d.Plan).WithMany(p => p.PlansRows).HasForeignKey(d => d.PlanId);

            entity.HasOne(d => d.Reps).WithMany(p => p.PlansRows).HasForeignKey(d => d.RepsId);
        });

        modelBuilder.Entity<Rep>(entity =>
        {
            entity.Property(e => e.Type)
                .HasColumnType("TEXT(100)")
                .HasColumnName("type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.BirthDay)
                .HasColumnType("DATETIME")
                .HasColumnName("birth_day");
            entity.Property(e => e.Country)
                .HasColumnType("TEXT(100)")
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasColumnType("TEXT(100)")
                .HasColumnName("email");
            entity.Property(e => e.ImagePath)
                .HasColumnType("TEXT(500)")
                .HasColumnName("image_path");
            entity.Property(e => e.Name)
                .HasColumnType("TEXT(100)")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnType("TEXT(100)")
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("TEXT(100)")
                .HasColumnName("phone_number");
            entity.Property(e => e.PlansCompleted)
                .HasDefaultValueSql("0")
                .HasColumnType("NUMERIC")
                .HasColumnName("plans_completed");
            entity.Property(e => e.StateRegion)
                .HasColumnType("TEXT(100)")
                .HasColumnName("state_region");
            entity.Property(e => e.Surname)
                .HasColumnType("TEXT(100)")
                .HasColumnName("surname");
            entity.Property(e => e.Username)
                .HasColumnType("TEXT(100)")
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
