using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHandler.Data.Constants;
using TaskHandler.Data.Entities;

namespace TaskHandler.Data.Configurations;

public class ProjectMemberConfiguration : IEntityTypeConfiguration<ProjectMember>
{
    public void Configure(EntityTypeBuilder<ProjectMember> builder)
    {
        builder.ToTable(table => table.HasCheckConstraint(
            "CK_ProjectMembers_HourlyRate",
            "[HourlyRate] >= 0"));

        builder.HasKey(member => new { member.ProjectId, member.UserId });

        builder.Property(member => member.HourlyRate)
            .HasPrecision(EntityConstants.MoneyPrecision, EntityConstants.MoneyScale);

        builder.Property(member => member.JoinedOnUtc)
            .HasDefaultValueSql("SYSUTCDATETIME()");

        builder.HasOne(member => member.Project)
            .WithMany(project => project.Members)
            .HasForeignKey(member => member.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(member => member.User)
            .WithMany(user => user.ProjectMemberships)
            .HasForeignKey(member => member.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
