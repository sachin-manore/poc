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

    public virtual DbSet<fixture> fixtures { get; set; }

    public virtual DbSet<league> leagues { get; set; }

    public virtual DbSet<period> periods { get; set; }

    public virtual DbSet<score> scores { get; set; }

    public virtual DbSet<status> statuses { get; set; }

    public virtual DbSet<team> teams { get; set; }

    public virtual DbSet<venue> venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=poc_entities");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<fixture>(entity =>
        {
            entity.ToTable("fixture");

            entity.Property(e => e.date).HasColumnType("datetime");
            entity.Property(e => e.referee).HasMaxLength(50);
            entity.Property(e => e.timestamp).HasMaxLength(50);
            entity.Property(e => e.timezone)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<league>(entity =>
        {
            entity.ToTable("league");

            entity.Property(e => e.country).HasMaxLength(50);
            entity.Property(e => e.flag).HasMaxLength(50);
            entity.Property(e => e.logo).HasMaxLength(50);
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.round)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.season)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.fixture).WithMany(p => p.leagues)
                .HasForeignKey(d => d.fixtureid)
                .HasConstraintName("FK_league_fixture");
        });

        modelBuilder.Entity<period>(entity =>
        {
            entity.HasKey(e => e.periodsid);

            entity.Property(e => e.first).HasMaxLength(50);
            entity.Property(e => e.second).HasMaxLength(50);

            entity.HasOne(d => d.fixture).WithMany(p => p.periods)
                .HasForeignKey(d => d.fixtureid)
                .HasConstraintName("FK_periods_fixture");
        });

        modelBuilder.Entity<score>(entity =>
        {
            entity.ToTable("score");

            entity.HasOne(d => d.team).WithMany(p => p.scores)
                .HasForeignKey(d => d.teamid)
                .HasConstraintName("FK_score_score");
        });

        modelBuilder.Entity<status>(entity =>
        {
            entity.ToTable("status");

            entity.Property(e => e._long)
                .HasMaxLength(50)
                .HasColumnName("long");
            entity.Property(e => e._short)
                .HasMaxLength(50)
                .HasColumnName("short");
            entity.Property(e => e.elapsed)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.fixture).WithMany(p => p.statuses)
                .HasForeignKey(d => d.fixtureid)
                .HasConstraintName("FK_status_fixture");
        });

        modelBuilder.Entity<team>(entity =>
        {
            entity.HasKey(e => e.teamsid);

            entity.Property(e => e.logo).HasMaxLength(50);
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.teamlocation).HasMaxLength(50);

            entity.HasOne(d => d.fixture).WithMany(p => p.teams)
                .HasForeignKey(d => d.fixtureid)
                .HasConstraintName("FK_teams_fixture");
        });

        modelBuilder.Entity<venue>(entity =>
        {
            entity.ToTable("venue");

            entity.Property(e => e.city).HasMaxLength(50);
            entity.Property(e => e.name).HasMaxLength(50);

            entity.HasOne(d => d.fixture).WithMany(p => p.venues)
                .HasForeignKey(d => d.fixtureid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_venue_fixture");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
