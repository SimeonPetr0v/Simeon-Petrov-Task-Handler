using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHandler.Data.Constants;
using TaskHandler.Data.Entities;

namespace TaskHandler.Data.Configurations;

public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
{
    public void Configure(EntityTypeBuilder<ProjectTask> builder)
    {
        builder.HasKey(task => task.Id);

        builder.Property(task => task.Name)
            .IsRequired()
            .HasMaxLength(EntityConstants.ProjectTask.NameMaxLength);

        builder.Property(task => task.Description)
            .HasMaxLength(EntityConstants.ProjectTask.DescriptionMaxLength);

        builder.HasIndex(task => new { task.ProjectId, task.Name })
            .IsUnique();

        builder.HasOne(task => task.Project)
            .WithMany(project => project.Tasks)
            .HasForeignKey(task => task.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
