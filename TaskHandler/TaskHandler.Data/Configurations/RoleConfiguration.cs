using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHandler.Data.Constants;

namespace TaskHandler.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            CreateRole("6d3f1c52-8a4e-4b7d-9f21-3c5e7a9b1d01", RoleNames.Administrator),
            CreateRole("b2e84f17-5c6d-4a3e-8b92-7d1f0e4c2a02", RoleNames.Manager),
            CreateRole("e91a7d3c-2f5b-4c8e-a6d4-0b3c9f8e5a03", RoleNames.Employee));
    }

    private static IdentityRole CreateRole(string id, string name) => new()
    {
        Id = id,
        Name = name,
        NormalizedName = name.ToUpperInvariant(),
        ConcurrencyStamp = id,
    };
}
