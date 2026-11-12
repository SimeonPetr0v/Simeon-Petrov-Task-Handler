namespace TaskHandler.Data.Entities;

public class RunningTimer
{
    public string UserId { get; set; } = string.Empty;

    public ApplicationUser User { get; set; } = null!;

    public int ProjectTaskId { get; set; }

    public ProjectTask ProjectTask { get; set; } = null!;

    public DateTime StartedOnUtc { get; set; }

    public string? Description { get; set; }

    public bool IsBillable { get; set; }
}
