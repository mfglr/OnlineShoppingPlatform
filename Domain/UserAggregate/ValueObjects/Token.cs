using Domain.UserAggregate.DomainServices;
using System.Security.Cryptography;

namespace Domain.UserAggregate.ValueObjects
{
    public class Token
    {
        private readonly static string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public byte[] Hash { get; private set; }
        public string Value { get; private set; }
        public DateTime ExpiredAt { get; private set; }

        private Token() { }

        public Token(string value, double validityPeriod)
        {
            Hash = HashComputer.Compute(value);
            Value = value;
            ExpiredAt = DateTime.UtcNow.AddMinutes(validityPeriod);
        }

        public bool IsValid(string token)
            => HashComputer.Check(token, Hash) && DateTime.UtcNow <= ExpiredAt;

        public static Token CreateRandom(double validityPeriod)
        {
            var numberByte = new byte[32];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(numberByte);
            return new(Convert.ToBase64String(numberByte), validityPeriod);
        }

        public static Token CreateRandomAlfanumeric(int length, double validityPeriod)
        {
            var random = new Random();
            return new(new([.. Enumerable.Repeat(_chars, length).Select(s => s[random.Next(s.Length)])]), validityPeriod);
        }
    }
}
