using System;
using System.Collections.Generic;

namespace Domain
{
    public class Team
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        // Связи с заказами и работниками
        public ICollection<Order> Orders { get; private set; } = new HashSet<Order>();
        public ICollection<Worker> Workers { get; private set; } = new HashSet<Worker>();

        public Team(string name, bool isActive = true)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            IsActive = isActive;
        }

        public void SetStatus(bool isActive) => IsActive = isActive;

        public override string ToString() => $"{Name} ({(IsActive ? "Свободна" : "Занята")})";
    }
}
