using Microsoft.AspNetCore.Identity;

namespace TaskHandler.Data.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public decimal? DefaultHourlyRate { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<ProjectMember> ProjectMemberships { get; set; } = new List<ProjectMember>();

    public ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();

    public ICollection<WeeklyTemplate> WeeklyTemplates { get; set; } = new List<WeeklyTemplate>();

    public RunningTimer? RunningTimer { get; set; }
}
