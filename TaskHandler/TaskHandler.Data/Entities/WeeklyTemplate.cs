using TaskHandler.Data.Contracts;

namespace TaskHandler.Data.Entities;

public class WeeklyTemplate : IHasCreatedOn
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    public ApplicationUser User { get; set; } = null!;

    public string Name { get; set; } = string.Empty;

    public DateTime CreatedOnUtc { get; set; }

    public ICollection<WeeklyTemplateEntry> Entries { get; set; } = new List<WeeklyTemplateEntry>();
}
