using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHandler.Data.Constants;
using TaskHandler.Data.Entities;

namespace TaskHandler.Data.Configurations;

public class RunningTimerConfiguration : IEntityTypeConfiguration<RunningTimer>
{
    public void Configure(EntityTypeBuilder<RunningTimer> builder)
    {
        builder.HasKey(timer => timer.UserId);

        builder.Property(timer => timer.Description)
            .HasMaxLength(EntityConstants.TimeEntry.DescriptionMaxLength);

        builder.HasOne(timer => timer.User)
            .WithOne(user => user.RunningTimer)
            .HasForeignKey<RunningTimer>(timer => timer.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(timer => timer.ProjectTask)
            .WithMany()
            .HasForeignKey(timer => timer.ProjectTaskId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
