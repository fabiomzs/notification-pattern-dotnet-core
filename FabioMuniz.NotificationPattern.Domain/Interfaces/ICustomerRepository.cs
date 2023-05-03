using FabioMuniz.NotificationPattern.Domain.Entities;

namespace FabioMuniz.NotificationPattern.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Customer Get(Guid id);
        IEnumerable<Customer> GetAll();
    }
}
