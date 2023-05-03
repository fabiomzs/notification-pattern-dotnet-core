using FabioMuniz.NotificationPattern.Domain.Entities;
using FabioMuniz.NotificationPattern.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using System.Reflection;

namespace FabioMuniz.NotificationPattern.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMemoryCache _cache;
        public CustomerRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Add(Customer customer)
        {
            _cache.Set(customer.Id, customer);
        }

        public Customer Get(Guid id)
        {
            var customer = _cache.Get<Customer>(id);

            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> result = new List<Customer>();
            var items = new List<string>();
           
            var field = typeof(MemoryCache).GetField("_coherentState", BindingFlags.NonPublic | BindingFlags.Instance);

            var coherentState = field.GetValue(_cache);
            var coherentStateType = coherentState?.GetType();
            var propertyInfo = coherentStateType!.GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance)!;

            var collection = propertyInfo.GetValue(coherentState) as ICollection;

            if (collection != null)
                foreach (var item in collection)
                {
                    var methodInfo = item.GetType().GetProperty("Key");
                    var val = methodInfo.GetValue(item);
                    items.Add(val.ToString());
                    result.Add(_cache.Get<Customer>(Guid.Parse(val.ToString())));
                }

            return result;
        }
    }
}
