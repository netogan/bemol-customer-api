using Bemol.Customer.Api.Controllers.ViewModels;
using Bemol.Customer.Api.Domain.Models;
using Bemol.Customer.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cash.Flow.Api.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private const string RouteApi = "api/[controller]";

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet(RouteApi + "{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var transaction = await _customerService.GetCustomer(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return transaction;
        }

        [HttpPost(RouteApi)]
        public async Task<ActionResult<Customer>> PostCustomer(AddCustomer customer)
        {
            var customerCreated = await _customerService.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customerCreated.Id }, customer);
        }

        [HttpPut(RouteApi + "{id}")]
        [Authorize]
        public async Task<IActionResult> PutCustomer(Customer customer)
        {
            var existingCustomer = await _customerService.GetCustomer(customer.Id);
            if (existingCustomer == null)
            {
                return NotFound();
            }
            await _customerService.UpdateCustomer(customer);
            return AcceptedAtAction(nameof(GetCustomer), new { id = customer.Id }, existingCustomer);
        }

        [HttpDelete(RouteApi + "{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}
