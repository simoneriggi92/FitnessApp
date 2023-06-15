using System;
using System.Collections.Generic;
using FitnessApp.Models.Entities;
using GymApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Models.Services.Insfrastructure;

public partial class AppDbContext : IdentityDbContext<AspNetUser>
{

    public AppDbContext():base()
    {

    }
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {

    }


    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Measurment> Measurments { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<PlansRow> PlansRows { get; set; }

    public virtual DbSet<Rep> Reps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Data/gymApp.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.Property(e => e.Description)
                .HasColumnType("TEXT(10000)")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("TEXT(100)")
                .HasColumnName("name");
            entity.Property(e => e.Category)
                .HasColumnType("TEXT(100)")
                .HasColumnName("category");
        });

        modelBuilder.Entity<Measurment>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Measurments_user_id");

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
            entity.HasIndex(e => e.UserId, "IX_Plans_user_id");

            entity.Property(e => e.CreationDate)
                .HasColumnType("TEXT(100)")
                .HasColumnName("creation_date");
            entity.Property(e => e.EndDate)
                .HasColumnType("TEXT(100)")
                .HasColumnName("end_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("TEXT(100)")
                .HasColumnName("start_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Status)
                .HasColumnType("TEXT(100)")
                .HasColumnName("status");

            entity.HasOne(d => d.User).WithMany(p => p.Plans).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<PlansRow>(entity =>
        {
            entity.ToTable("Plans_Rows");

            entity.HasIndex(e => e.ExerciseId, "IX_Plans_Rows_exercise_id");

            entity.HasIndex(e => e.PlanId, "IX_Plans_Rows_plan_id");

            entity.HasIndex(e => e.RepsId, "IX_Plans_Rows_reps_id");

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

            // entity.HasOne(d => d.Reps).WithMany(p => p.PlansRows).HasForeignKey(d => d.RepsId);
        });

        modelBuilder.Entity<Rep>(entity =>
        {
            entity.ToTable("Reps");
            entity.HasIndex(e => e.Id);
            entity.Property(e => e.Type)
                .HasColumnType("TEXT(100)")
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
