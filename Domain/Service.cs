using System;
using System.Collections.Generic;

namespace Domain
{
    public class Service
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string? Description { get; private set; }
        public decimal CustomPriceMultiplier { get; private set; }

        // Связь с заказами (многие-к-одному)
        public ICollection<Order> Orders { get; private set; } = new HashSet<Order>();

        public Service(string name, decimal price, string? description = null, decimal customPriceMultiplier = 1.0m)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price >= 0 ? price : throw new ArgumentOutOfRangeException(nameof(price));
            Description = description;
            CustomPriceMultiplier = customPriceMultiplier > 0 ? customPriceMultiplier : throw new ArgumentOutOfRangeException(nameof(customPriceMultiplier));
        }

        public override string ToString() => $"{Name}: {Price:C}";
    }
}
