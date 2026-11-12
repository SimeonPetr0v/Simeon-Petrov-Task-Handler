using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskHandler.Data.Constants;
using TaskHandler.Data.Entities;

namespace TaskHandler.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(client => client.Id);

        builder.Property(client => client.Name)
            .IsRequired()
            .HasMaxLength(EntityConstants.Client.NameMaxLength);

        builder.HasIndex(client => client.Name)
            .IsUnique();

        builder.Property(client => client.Email)
            .HasMaxLength(EntityConstants.Client.EmailMaxLength);

        builder.Property(client => client.Phone)
            .HasMaxLength(EntityConstants.Client.PhoneMaxLength);
    }
}
