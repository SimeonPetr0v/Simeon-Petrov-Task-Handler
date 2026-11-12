using TaskHandler.Data.Contracts;

namespace TaskHandler.Data.Entities;

public class Client : IArchivable, IHasCreatedOn
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool IsArchived { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
