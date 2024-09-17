using ConnecTor_Back.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;

public class ConnecTorDbContext : DbContext
{
    public ConnecTorDbContext(DbContextOptions<ConnecTorDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserTypes> UserTypes { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Profession> Professions { get; set; }
    public DbSet<ProjectField> ProjectFields { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectImage> ProjectImages { get; set; }
    public DbSet<ProjectProposal> ProjectProposals { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<LogTable> LogTables { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region User
        // User model relationships
        modelBuilder.Entity<User>()
            .HasKey(u => u.UserID);

        modelBuilder.Entity<User>()
            .HasOne(u => u.UserType)
            .WithMany(ut => ut.Users)
            .HasForeignKey(u => u.UserTypeID)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuring User to Region relationship
        modelBuilder.Entity<User>()
            .HasOne(u => u.Region)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RegionID)
            .OnDelete(DeleteBehavior.Restrict); // Adjust delete behavior as needed


        // Configuring User to Profession relationship
        modelBuilder.Entity<User>()
            .HasOne(u => u.Profession)
            .WithMany(p => p.Users)
            .HasForeignKey(u => u.ProfessionID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.SentMessages)
            .WithOne(m => m.Sender)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.ReceivedMessages)
            .WithOne(m => m.Receiver)
            .HasForeignKey(m => m.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);

        // User's projects
        modelBuilder.Entity<User>()
            .HasMany(u => u.ProjectsAsClient)
            .WithOne(p => p.Client)
            .HasForeignKey(p => p.ClientID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.ProjectsAsContractor)
            .WithOne(p => p.Contractor)
            .HasForeignKey(p => p.ContractorID)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Region
        // Region model relationships
        modelBuilder.Entity<Region>()
            .HasMany(r => r.Users)
            .WithOne(u => u.Region)
            .HasForeignKey(u => u.RegionID)
            .OnDelete(DeleteBehavior.Restrict); // Prevents cascade delete

        modelBuilder.Entity<Region>()
            .HasMany(r => r.Projects)
            .WithOne(p => p.Region)
            .HasForeignKey(p => p.RegionID)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Project
        // Project model relationships
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Client)
            .WithMany(u => u.ProjectsAsClient)
            .HasForeignKey(p => p.ClientID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.Contractor)
            .WithMany(u => u.ProjectsAsContractor)
            .HasForeignKey(p => p.ContractorID)
            .OnDelete(DeleteBehavior.Restrict);
        #endregion

        #region Proposals
        // ProjectProposal model relationships
        modelBuilder.Entity<ProjectProposal>()
            .HasKey(pp => new { pp.ProjectID, pp.ProposalDate });
        #endregion

        #region Rating
        // Rating model relationships
        modelBuilder.Entity<Rating>()
            .HasKey(r => new { r.RaterUserID, r.RatedUserID, r.RatingDate });
        #endregion

        #region Message
        // Message model relationships and indexing
        modelBuilder.Entity<Message>()
            .HasIndex(m => m.SenderId);

        modelBuilder.Entity<Message>()
            .HasIndex(m => m.ReceiverId);
        #endregion

        base.OnModelCreating(modelBuilder);
    }
    public async Task<UserDto> GetUserById(int id)
    {
        var sql = "EXEC GetUserById @p0";
        return await this.Database.GetDbConnection()
            .QuerySingleOrDefaultAsync<UserDto>(sql, new { p0 = id });
    }

    public async Task<List<LastProjectsDto>> GetLastProjectsById(int id, int amount)
    {
        var sql = "EXEC GetUserProjectsById @UserID = @id, @ProjectCount = @amount";

        var rawResult = await this.Database.GetDbConnection()
            .QueryAsync<dynamic>(sql, new { id, amount });

        var result = rawResult.Select(row => new LastProjectsDto
        {
            ProjectID = row.ProjectID,
            ProjectName = row.ProjectName,
            ProjectDescription = row.ProjectDescription,
            Deadline = DateOnly.FromDateTime((DateTime)row.Deadline) // Convert DateTime to DateOnly
        }).ToList();

        return result;
    }

    public async Task<List<LastBidsDto>> GetLastBidsById(int id, int amount)
    {
        var sql = "EXEC GetLastBidsById @UserID = @id, @Amount = @amount";
        var result = await this.Database.GetDbConnection()
            .QueryAsync<LastBidsDto>(sql, new { id, amount });
        return result.ToList();
    }



}
