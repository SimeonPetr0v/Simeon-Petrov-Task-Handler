using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHandler.Data.Constants;
using TaskHandler.Data.Entities;

namespace TaskHandler.Data.Configurations;

public class WeeklyTemplateEntryConfiguration : IEntityTypeConfiguration<WeeklyTemplateEntry>
{
    public void Configure(EntityTypeBuilder<WeeklyTemplateEntry> builder)
    {
        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_WeeklyTemplateEntries_DurationMinutes",
                $"[DurationMinutes] BETWEEN {EntityConstants.TimeEntry.MinDurationMinutes} AND {EntityConstants.TimeEntry.MaxDurationMinutes}");

            table.HasCheckConstraint(
                "CK_WeeklyTemplateEntries_DayOfWeek",
                "[DayOfWeek] BETWEEN 0 AND 6");
        });

        builder.HasKey(entry => entry.Id);

        builder.Property(entry => entry.Description)
            .HasMaxLength(EntityConstants.WeeklyTemplate.DescriptionMaxLength);

        builder.HasOne(entry => entry.WeeklyTemplate)
            .WithMany(template => template.Entries)
            .HasForeignKey(entry => entry.WeeklyTemplateId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(entry => entry.ProjectTask)
            .WithMany()
            .HasForeignKey(entry => entry.ProjectTaskId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
