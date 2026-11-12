using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHandler.Data.Constants;
using TaskHandler.Data.Entities;

namespace TaskHandler.Data.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable(table => table.HasCheckConstraint(
            "CK_Projects_HourlyRate",
            "[HourlyRate] >= 0"));

        builder.HasKey(project => project.Id);

        builder.Property(project => project.Name)
            .IsRequired()
            .HasMaxLength(EntityConstants.Project.NameMaxLength);

        builder.Property(project => project.Description)
            .HasMaxLength(EntityConstants.Project.DescriptionMaxLength);

        builder.Property(project => project.HourlyRate)
            .HasPrecision(EntityConstants.MoneyPrecision, EntityConstants.MoneyScale);

        builder.HasIndex(project => new { project.ClientId, project.Name })
            .IsUnique();

        builder.HasOne(project => project.Client)
            .WithMany(client => client.Projects)
            .HasForeignKey(project => project.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
