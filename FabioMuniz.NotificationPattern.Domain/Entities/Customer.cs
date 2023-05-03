using FabioMuniz.NotificationPattern.Domain.Validators;

namespace FabioMuniz.NotificationPattern.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public Customer(Guid id, string name, string email, int age)
        {
            Id = id;
            Name = name;
            Email = email;
            Age = age;

            Validate(this, new CustomerValidator());
        }
    }
}
