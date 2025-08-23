using Domain.UserAggregate.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.UserAggregate.ValueObjects
{
    public class PhoneNumber
    {
        private readonly static string _pattern = @"^(\+90|0)?5\d{9}$";
        public string Value { get; private set; }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new PhoneNumberIsRequiredException();
            if (!Regex.IsMatch(value, _pattern, RegexOptions.IgnoreCase))
                throw new InvalidPhoneNumberException();

            Value = value;
        }
    }
}
