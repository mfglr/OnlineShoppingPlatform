using Core;
using Domain.UserAggregate.Exceptions;
using Domain.UserAggregate.ValueObjects;

namespace Domain.UserAggregate.Entities
{
    public class User : Entity
    {
        private readonly static int _refreshTokenValidityPeriod = 43200;
        private readonly static int _emailConfirmationTokenValidityPeriod = 5;
        private readonly static int _passwordResetTokenValidityPeriod = 5;

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public bool IsEmailConfirmed { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber? PhoneNumber { get; private set; }
        public Password Password { get; private set; }
        public Role Role { get; private set; }
        public Token? EmailConfirmationToken { get; private set; }
        public Token? PasswordResetToken { get; private set; }
        public Token RefreshToken { get; private set; }

        private User() { }

        public User(Email email,Password password)
        {
            Email = email;
            Password = password;
            IsEmailConfirmed = false;
            EmailConfirmationToken = Token.CreateRandomAlfanumeric(6, _emailConfirmationTokenValidityPeriod);
            RefreshToken = Token.CreateRandom(_refreshTokenValidityPeriod);
            Role = Role.Customer;
        }

        public void ConfirmEmail(string token)
        {
            if (IsEmailConfirmed)
                throw new EmailAlreadyConfirmedException();

            if (EmailConfirmationToken == null || !EmailConfirmationToken.IsValid(token))
                throw new InvalidTokenException();

            IsEmailConfirmed = true;
            EmailConfirmationToken = null;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateEmailConfirmationToken()
        {
            if (IsEmailConfirmed)
                throw new EmailAlreadyConfirmedException();

            EmailConfirmationToken = Token.CreateRandomAlfanumeric(6, _emailConfirmationTokenValidityPeriod);
            UpdatedAt = DateTime.UtcNow;
        }

        public void ResetPassword(string token, string password)
        {
            if(PasswordResetToken == null || !PasswordResetToken.IsValid(token))
                throw new InvalidTokenException();
            Password = new Password(password);
            PasswordResetToken = null;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatePasswordResetToken()
        {
            PasswordResetToken = Token.CreateRandomAlfanumeric(5, _passwordResetTokenValidityPeriod);
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateFirstName(string? name)
        {
            FirstName = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateLastName(string? lastName)
        {
            LastName = lastName;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatePassword(string password, string newPassword)
        {
            if (!Password.IsValid(password))
                throw new PasswordNotMatchException();
            Password = new Password(newPassword);
            UpdatedAt = DateTime.UtcNow;
        }

        public void LoginByRefreshToken(string token)
        {
            if (!RefreshToken.IsValid(token))
                throw new InvalidRefreshTokenException();
            RefreshToken = Token.CreateRandom(_refreshTokenValidityPeriod);
        }

        public void LoginByPassword(string password)
        {
            if (!Password.IsValid(password))
                throw new LoginFailedException();
            RefreshToken = Token.CreateRandom(_refreshTokenValidityPeriod);
        }

    }
}
