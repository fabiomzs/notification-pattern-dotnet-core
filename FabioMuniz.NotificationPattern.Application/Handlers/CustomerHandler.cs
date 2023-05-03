using FabioMuniz.NotificationPattern.Application.Models;
using FabioMuniz.NotificationPattern.Domain.Entities;
using FabioMuniz.NotificationPattern.Domain.Interfaces;
using FabioMuniz.NotificationPattern.Domain.Notifications;

namespace FabioMuniz.NotificationPattern.Application.Handlers
{
    public class CustomerHandler
    {
        private readonly NotificationHandler _notificationContext;
        private readonly ICustomerRepository _customerRepository;
        public CustomerHandler(NotificationHandler notificationContext, ICustomerRepository customerRepository)
        {
            _notificationContext = notificationContext;
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(CustomerModel request)
        {
            Customer customer = new Customer(Guid.NewGuid(), request.Name, request.Email, request.Age);

            if (!customer.ValidationResult.IsValid)
                _notificationContext.AddNotifications(customer.ValidationResult);
            else
                _customerRepository.Add(customer);

            return customer;
        }
    }
}
