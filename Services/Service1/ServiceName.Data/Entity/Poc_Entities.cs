using System;
using System.Collections.Generic;
using Libraries.Abstract.Data;

using Microsoft.EntityFrameworkCore;
using ServiceName.Data.DataModel;

namespace ServiceName.Data.Entity;

public partial class Poc_Entities : AbstractDbContext
{
    public Poc_Entities()
    {
    }

    public Poc_Entities(DbContextOptions<Poc_Entities> options)
        : base(options)
    {
    }

    public virtual DbSet<Fixture> Fixtures { get; set; }

    public virtual DbSet<League> Leagues { get; set; }

    public virtual DbSet<PerIod> PerIods { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=poc_entities");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fixture>(entity =>
        {
            entity.ToTable("Fixture");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Referee).HasMaxLength(50);
            entity.Property(e => e.Timestamp).HasMaxLength(50);
            entity.Property(e => e.Timezone)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<League>(entity =>
        {
            entity.ToTable("League");

            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Flag).HasMaxLength(50);
            entity.Property(e => e.Logo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Round)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Season)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Fixture).WithMany(p => p.Leagues)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("FK_League_Fixture");
        });

        modelBuilder.Entity<PerIod>(entity =>
        {
            entity.HasKey(e => e.PeriodsId).HasName("PK_Periods");

            entity.Property(e => e.First).HasMaxLength(50);
            entity.Property(e => e.Second).HasMaxLength(50);

            entity.HasOne(d => d.Fixture).WithMany(p => p.PerIods)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("FK_Periods_Fixture");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.ToTable("Score");

            entity.HasOne(d => d.Team).WithMany(p => p.Scores)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_Score_Score");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Elapsed)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Long).HasMaxLength(50);
            entity.Property(e => e.Short).HasMaxLength(50);

            entity.HasOne(d => d.Fixture).WithMany(p => p.Statuses)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("FK_Status_Fixture");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamsId);

            entity.Property(e => e.Logo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TeamLocation).HasMaxLength(50);

            entity.HasOne(d => d.Fixture).WithMany(p => p.Teams)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("FK_Teams_Fixture");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.ToTable("Venue");

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Fixture).WithMany(p => p.Venues)
                .HasForeignKey(d => d.FixtureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venue_Fixture");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
