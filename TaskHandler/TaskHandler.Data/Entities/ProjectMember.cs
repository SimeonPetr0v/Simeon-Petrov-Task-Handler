namespace TaskHandler.Data.Entities;

public class ProjectMember
{
    public int ProjectId { get; set; }

    public Project Project { get; set; } = null!;

    public string UserId { get; set; } = string.Empty;

    public ApplicationUser User { get; set; } = null!;

    public decimal? HourlyRate { get; set; }

    public bool IsProjectManager { get; set; }

    public DateTime JoinedOnUtc { get; set; }
}
