using System;

namespace Domain
{
    public class Worker
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Role { get; private set; }

        // Внешний ключ для бригады
        public Guid? TeamId { get; private set; }
        public Team? Team { get; private set; }

        public Worker(string name, string role, Team? team = null)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Role = role ?? throw new ArgumentNullException(nameof(role));
            Team = team;
            TeamId = team?.Id;
        }

        public override string ToString() => $"{Name} - {Role}";
    }
}
