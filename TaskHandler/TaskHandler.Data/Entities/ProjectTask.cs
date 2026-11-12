using TaskHandler.Data.Contracts;

namespace TaskHandler.Data.Entities;

public class ProjectTask : IArchivable, IHasCreatedOn
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int ProjectId { get; set; }

    public Project Project { get; set; } = null!;

    public bool IsArchived { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
}
