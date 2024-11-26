using System;
using System.Collections.Generic;

namespace Domain
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? ContactInfo { get; private set; }

        // Связь с заказами (многие-к-одному)
        public ICollection<Order> Orders { get; private set; } = new HashSet<Order>();

        public Customer(string name, string? contactInfo = null)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ContactInfo = contactInfo;
        }

        public override string ToString() => $"{Name} ({ContactInfo ?? "Контакты отсутствуют"})";
    }
}
