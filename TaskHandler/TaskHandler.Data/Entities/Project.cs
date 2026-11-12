using TaskHandler.Data.Contracts;

namespace TaskHandler.Data.Entities;

public class Project : IArchivable, IHasCreatedOn
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int ClientId { get; set; }

    public Client Client { get; set; } = null!;

    public decimal? HourlyRate { get; set; }

    public bool IsBillable { get; set; } = true;

    public bool IsArchived { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();

    public ICollection<ProjectMember> Members { get; set; } = new List<ProjectMember>();
}
