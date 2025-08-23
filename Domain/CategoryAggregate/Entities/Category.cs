using Core;
using Domain.CategoryAggregate.ValueObjects;

namespace Domain.CategoryAggregate.Entities
{
    public class Category : Entity, IAggregateRoot
    {
        public CategoryName Name { get; private set; }

        private Category() { }
        public Category(CategoryName name)
        {
            Name = name;
        }

        public void UpdateName(CategoryName name)
        {
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }


    }
}
