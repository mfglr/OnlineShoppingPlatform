using Domain.CategoryAggregate.Exceptions;

namespace Domain.CategoryAggregate.ValueObjects
{
    public class CategoryName
    {
        public static readonly int MinLength = 4;
        public static readonly int MaxLength = 256;

        public string Value { get; private set; }

        public CategoryName(string value)
        {
            if (value == null || value.Length < MinLength || value.Length > MaxLength)
                throw new CategoryNameException();
            Value = value;
        }
    }
}
