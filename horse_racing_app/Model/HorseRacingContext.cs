using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace horse_racing_app.Model;

public partial class HorseRacingContext : DbContext
{
    public HorseRacingContext()
    {
    }

    public HorseRacingContext(DbContextOptions<HorseRacingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Competition> Competitions { get; set; }

    public virtual DbSet<Horse> Horses { get; set; }

    public virtual DbSet<HorseBreed> HorseBreeds { get; set; }

    public virtual DbSet<HorseGender> HorseGenders { get; set; }

    public virtual DbSet<Jockey> Jockeys { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<ParticipantTime> ParticipantTimes { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<RaceType> RaceTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Violation> Violations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=horse_racing;Username=postgres;Password=1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Competition>(entity =>
        {
            entity.HasKey(e => e.CompetitionId).HasName("competitions_pkey");

            entity.ToTable("competitions");

            entity.Property(e => e.CompetitionId).HasColumnName("competition_id");
            entity.Property(e => e.CompetitionDate).HasColumnName("competition_date");
            entity.Property(e => e.CompetitionName)
                .HasMaxLength(100)
                .HasColumnName("competition_name");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
        });

        modelBuilder.Entity<Horse>(entity =>
        {
            entity.HasKey(e => e.HorseId).HasName("horses_pkey");

            entity.ToTable("horses");

            entity.Property(e => e.HorseId).HasColumnName("horse_id");
            entity.Property(e => e.BirthYear).HasColumnName("birth_year");
            entity.Property(e => e.BreedId).HasColumnName("breed_id");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.Nickname)
                .HasMaxLength(50)
                .HasColumnName("nickname");
            entity.Property(e => e.Owner)
                .HasMaxLength(100)
                .HasColumnName("owner");
            entity.Property(e => e.TrainerFullName)
                .HasMaxLength(100)
                .HasColumnName("trainer_full_name");

            entity.HasOne(d => d.Breed).WithMany(p => p.Horses)
                .HasForeignKey(d => d.BreedId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("horses_breed_id_fkey");

            entity.HasOne(d => d.Gender).WithMany(p => p.Horses)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("horses_gender_id_fkey");
        });

        modelBuilder.Entity<HorseBreed>(entity =>
        {
            entity.HasKey(e => e.BreedId).HasName("horse_breeds_pkey");

            entity.ToTable("horse_breeds");

            entity.HasIndex(e => e.BreedName, "horse_breeds_breed_name_key").IsUnique();

            entity.Property(e => e.BreedId).HasColumnName("breed_id");
            entity.Property(e => e.BreedName)
                .HasMaxLength(50)
                .HasColumnName("breed_name");
        });

        modelBuilder.Entity<HorseGender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("horse_genders_pkey");

            entity.ToTable("horse_genders");

            entity.HasIndex(e => e.GenderName, "horse_genders_gender_name_key").IsUnique();

            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.GenderName)
                .HasMaxLength(10)
                .HasColumnName("gender_name");
        });

        modelBuilder.Entity<Jockey>(entity =>
        {
            entity.HasKey(e => e.JockeyId).HasName("jockeys_pkey");

            entity.ToTable("jockeys");

            entity.HasIndex(e => e.PersonalCode, "jockeys_personal_code_key").IsUnique();

            entity.Property(e => e.JockeyId).HasColumnName("jockey_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.PersonalCode)
                .HasMaxLength(20)
                .HasColumnName("personal_code");
            entity.Property(e => e.Weight)
                .HasPrecision(5, 2)
                .HasColumnName("weight");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.ParticipantId).HasName("participants_pkey");

            entity.ToTable("participants");

            entity.Property(e => e.ParticipantId).HasColumnName("participant_id");
            entity.Property(e => e.Disqualified)
                .HasDefaultValue(false)
                .HasColumnName("disqualified");
            entity.Property(e => e.HorseId).HasColumnName("horse_id");
            entity.Property(e => e.JockeyId).HasColumnName("jockey_id");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.ViolationDetails).HasColumnName("violation_details");

            entity.HasOne(d => d.Horse).WithMany(p => p.Participants)
                .HasForeignKey(d => d.HorseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("participants_horse_id_fkey");

            entity.HasOne(d => d.Jockey).WithMany(p => p.Participants)
                .HasForeignKey(d => d.JockeyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("participants_jockey_id_fkey");

            entity.HasOne(d => d.Race).WithMany(p => p.Participants)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("participants_race_id_fkey");
        });

        modelBuilder.Entity<ParticipantTime>(entity =>
        {
            entity.HasKey(e => e.TimeId).HasName("participant_times_pkey");

            entity.ToTable("participant_times");

            entity.Property(e => e.TimeId).HasColumnName("time_id");
            entity.Property(e => e.ParticipantId).HasColumnName("participant_id");
            entity.Property(e => e.TimeTaken)
                .HasPrecision(5, 1)
                .HasColumnName("time_taken");

            entity.HasOne(d => d.Participant).WithMany(p => p.ParticipantTimes)
                .HasForeignKey(d => d.ParticipantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("participant_times_participant_id_fkey");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.RaceId).HasName("races_pkey");

            entity.ToTable("races");

            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.CompetitionId).HasColumnName("competition_id");
            entity.Property(e => e.Distance).HasColumnName("distance");
            entity.Property(e => e.PrizeFund)
                .HasPrecision(10, 2)
                .HasColumnName("prize_fund");
            entity.Property(e => e.RaceName)
                .HasMaxLength(100)
                .HasColumnName("race_name");
            entity.Property(e => e.RaceNumber).HasColumnName("race_number");
            entity.Property(e => e.RaceTypeId).HasColumnName("race_type_id");
            entity.Property(e => e.Restrictions)
                .HasMaxLength(255)
                .HasColumnName("restrictions");
            entity.Property(e => e.StartTime).HasColumnName("start_time");

            entity.HasOne(d => d.Competition).WithMany(p => p.Races)
                .HasForeignKey(d => d.CompetitionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("races_competition_id_fkey");

            entity.HasOne(d => d.RaceType).WithMany(p => p.Races)
                .HasForeignKey(d => d.RaceTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("races_race_type_id_fkey");
        });

        modelBuilder.Entity<RaceType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("race_types_pkey");

            entity.ToTable("race_types");

            entity.HasIndex(e => e.TypeName, "race_types_type_name_key").IsUnique();

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(20)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleName, "roles_role_name_key").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("users_role_id_fkey");
        });

        modelBuilder.Entity<Violation>(entity =>
        {
            entity.HasKey(e => e.ViolationId).HasName("violations_pkey");

            entity.ToTable("violations");

            entity.Property(e => e.ViolationId).HasColumnName("violation_id");
            entity.Property(e => e.ParticipantId).HasColumnName("participant_id");
            entity.Property(e => e.ViolationDescription).HasColumnName("violation_description");
            entity.Property(e => e.ViolationTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("violation_time");

            entity.HasOne(d => d.Participant).WithMany(p => p.Violations)
                .HasForeignKey(d => d.ParticipantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("violations_participant_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
