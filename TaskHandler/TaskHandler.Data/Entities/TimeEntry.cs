using TaskHandler.Data.Contracts;
using TaskHandler.Data.Enums;

namespace TaskHandler.Data.Entities;

public class TimeEntry : IHasCreatedOn
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    public ApplicationUser User { get; set; } = null!;

    public int ProjectTaskId { get; set; }

    public ProjectTask ProjectTask { get; set; } = null!;

    public DateOnly WorkDate { get; set; }

    public DateTime? StartUtc { get; set; }

    public DateTime? EndUtc { get; set; }

    public int DurationMinutes { get; set; }

    public string? Description { get; set; }

    public bool IsBillable { get; set; }

    public decimal? HourlyRate { get; set; }

    public TimeEntrySource Source { get; set; }

    public DateTime CreatedOnUtc { get; set; }
}
