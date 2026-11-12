namespace TaskHandler.Data.Entities;

public class WeeklyTemplateEntry
{
    public int Id { get; set; }

    public int WeeklyTemplateId { get; set; }

    public WeeklyTemplate WeeklyTemplate { get; set; } = null!;

    public int ProjectTaskId { get; set; }

    public ProjectTask ProjectTask { get; set; } = null!;

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly? StartTime { get; set; }

    public int DurationMinutes { get; set; }

    public string? Description { get; set; }

    public bool IsBillable { get; set; }
}
