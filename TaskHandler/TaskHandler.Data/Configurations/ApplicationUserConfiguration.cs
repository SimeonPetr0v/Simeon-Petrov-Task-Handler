using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHandler.Data.Constants;
using TaskHandler.Data.Entities;

namespace TaskHandler.Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable(table => table.HasCheckConstraint(
            "CK_AspNetUsers_DefaultHourlyRate",
            "[DefaultHourlyRate] >= 0"));

        builder.Property(user => user.FirstName)
            .IsRequired()
            .HasMaxLength(EntityConstants.User.FirstNameMaxLength);

        builder.Property(user => user.LastName)
            .IsRequired()
            .HasMaxLength(EntityConstants.User.LastNameMaxLength);

        builder.Property(user => user.DefaultHourlyRate)
            .HasPrecision(EntityConstants.MoneyPrecision, EntityConstants.MoneyScale);
    }
}
