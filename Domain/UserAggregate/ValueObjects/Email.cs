using Domain.UserAggregate.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.UserAggregate.ValueObjects
{
    public class Email
    {
        public static readonly string _pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        public string Value { get; private set; }
        
        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new EmailRequiredException();
            if (!Regex.IsMatch(value, _pattern, RegexOptions.IgnoreCase))
                throw new InvalidEmailException();

            Value = value;
        }


    }
}
