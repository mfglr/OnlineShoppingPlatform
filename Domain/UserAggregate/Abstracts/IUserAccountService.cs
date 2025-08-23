namespace Domain.UserAggregate.Abstracts
{
    public record Account(string AccessToken, string RefreshToken);
    public interface IUserAccountService
    {
        Task<Account> CreateAsync(string Email, string Password, CancellationToken cancellationToken);
    }
}
