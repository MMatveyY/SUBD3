using System;

namespace Domain
{
    public class Order
    {
        public Guid Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public bool CustomProject { get; private set; }
        public decimal TotalPrice { get; private set; }

        // Внешние ключи и связи
        public Guid ServiceId { get; private set; }
        public Service Service { get; private set; }

        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        public Guid? TeamId { get; private set; }
        public Team? Team { get; private set; }

        public Order(Service service, Customer customer, DateTime orderDate, decimal totalPrice, bool customProject = false, Team? team = null)
        {
            Id = Guid.NewGuid();
            Service = service ?? throw new ArgumentNullException(nameof(service));
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            ServiceId = service.Id;
            CustomerId = customer.Id;

            OrderDate = orderDate;
            TotalPrice = totalPrice >= 0 ? totalPrice : throw new ArgumentOutOfRangeException(nameof(totalPrice));
            CustomProject = customProject;

            Team = team;
            TeamId = team?.Id;
        }

        public override string ToString() =>
            $"{OrderDate.ToShortDateString()}: {Service.Name} для {Customer.Name}, стоимость: {TotalPrice:C}";
    }
}
