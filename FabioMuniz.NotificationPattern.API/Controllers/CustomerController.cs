using FabioMuniz.NotificationPattern.Application.Handlers;
using FabioMuniz.NotificationPattern.Application.Models;
using FabioMuniz.NotificationPattern.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FabioMuniz.NotificationPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerHandler _handler;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(CustomerHandler handler, ICustomerRepository customerRepository)
        {
            _handler = handler;
            _customerRepository = customerRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var customer = _customerRepository.Get(id);

            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = _customerRepository.GetAll();

            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerModel request)
        {

            var customer = await _handler.Handle(request);

            return Ok(customer);

        }
    }
}
