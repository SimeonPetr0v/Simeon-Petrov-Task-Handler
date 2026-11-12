using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHandler.Data.Constants;
using TaskHandler.Data.Entities;

namespace TaskHandler.Data.Configurations;

public class TimeEntryConfiguration : IEntityTypeConfiguration<TimeEntry>
{
    public void Configure(EntityTypeBuilder<TimeEntry> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_TimeEntries_DurationMinutes",
                $"[DurationMinutes] BETWEEN {EntityConstants.TimeEntry.MinDurationMinutes} AND {EntityConstants.TimeEntry.MaxDurationMinutes}");

            table.HasCheckConstraint(
                "CK_TimeEntries_StartAndEnd",
                "([StartUtc] IS NULL AND [EndUtc] IS NULL) OR ([StartUtc] IS NOT NULL AND [EndUtc] IS NOT NULL AND [EndUtc] > [StartUtc])");

            table.HasCheckConstraint(
                "CK_TimeEntries_HourlyRate",
                "[HourlyRate] >= 0");
        });

        builder.HasKey(entry => entry.Id);

        builder.Property(entry => entry.Description)
            .HasMaxLength(EntityConstants.TimeEntry.DescriptionMaxLength);

        builder.Property(entry => entry.HourlyRate)
            .HasPrecision(EntityConstants.MoneyPrecision, EntityConstants.MoneyScale);

        builder.Property(entry => entry.Source)
            .HasConversion<string>()
            .HasMaxLength(EntityConstants.TimeEntry.SourceMaxLength);

        builder.HasIndex(entry => new { entry.UserId, entry.WorkDate });

        builder.HasOne(entry => entry.User)
            .WithMany(user => user.TimeEntries)
            .HasForeignKey(entry => entry.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entry => entry.ProjectTask)
            .WithMany(task => task.TimeEntries)
            .HasForeignKey(entry => entry.ProjectTaskId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
