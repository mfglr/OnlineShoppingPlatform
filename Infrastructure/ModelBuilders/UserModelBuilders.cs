using Domain.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelBuilders
{
    internal class UserModelBuilders : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.OwnsOne(x => x.PhoneNumber);
            builder.OwnsOne(x => x.Email);
            builder.OwnsOne(x => x.Password, password => password.Ignore(x => x.Value));
            builder.OwnsOne(x => x.RefreshToken, x => x.Ignore(x => x.Value));
            builder.OwnsOne(x => x.PasswordResetToken, x => x.Ignore(x => x.Value));
            builder.OwnsOne(x => x.EmailConfirmationToken, x => x.Ignore(x => x.Value));
        }
    }
}
