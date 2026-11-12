using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHandler.Data.Constants;
using TaskHandler.Data.Entities;

namespace TaskHandler.Data.Configurations;

public class WeeklyTemplateConfiguration : IEntityTypeConfiguration<WeeklyTemplate>
{
    public void Configure(EntityTypeBuilder<WeeklyTemplate> builder)
    {
        builder.HasKey(template => template.Id);

        builder.Property(template => template.Name)
            .IsRequired()
            .HasMaxLength(EntityConstants.WeeklyTemplate.NameMaxLength);

        builder.HasIndex(template => new { template.UserId, template.Name })
            .IsUnique();

        builder.HasOne(template => template.User)
            .WithMany(user => user.WeeklyTemplates)
            .HasForeignKey(template => template.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
