using Domain.ProductAggregate.Exceptions;

namespace Domain.ProductAggregate.ValueObjects
{
    public class ProductName
    {
        public readonly static int MinLength = 3;
        public readonly static int MaxLength = 256;
        public string Value { get; private set; }

        public ProductName(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < MinLength || value.Length > MaxLength)
                throw new ProductNameLengthException();

            Value = value;
        }
    }
}
