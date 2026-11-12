using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskHandler.Data.Contracts;
using TaskHandler.Data.Entities;

namespace TaskHandler.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Client> Clients => Set<Client>();

    public DbSet<Project> Projects => Set<Project>();

    public DbSet<ProjectTask> ProjectTasks => Set<ProjectTask>();

    public DbSet<ProjectMember> ProjectMembers => Set<ProjectMember>();

    public DbSet<TimeEntry> TimeEntries => Set<TimeEntry>();

    public DbSet<RunningTimer> RunningTimers => Set<RunningTimer>();

    public DbSet<WeeklyTemplate> WeeklyTemplates => Set<WeeklyTemplate>();

    public DbSet<WeeklyTemplateEntry> WeeklyTemplateEntries => Set<WeeklyTemplateEntry>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        var entityTypesWithCreatedOn = builder.Model.GetEntityTypes()
            .Where(entityType => typeof(IHasCreatedOn).IsAssignableFrom(entityType.ClrType));

        foreach (var entityType in entityTypesWithCreatedOn)
        {
            builder.Entity(entityType.ClrType)
                .Property(nameof(IHasCreatedOn.CreatedOnUtc))
                .HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
