using BabbySitterAnytime.DataBaseModels;
using BabbySitterAnytime.DataViewModels.CustomerViewModels;
using BabbySitterAnytime.Services.ClientRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BabbySitterAnytime.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Customer")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDataViewModel>> GetProfileDetails(Guid id)
        {
            var customer = await _clientRepository.ProfileDetails(id);
            if (customer == null)
            {
                return NotFound();
            }

            var customerViewModel = new CustomerDataViewModel
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address
            };

            return customerViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDataViewModel>> CreatePofile(CustomerDataViewModel customer)
        {
            var newCustomer = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address
            };

            await _clientRepository.CreateProfile(newCustomer);

            var customerViewModel = new CustomerDataViewModel
            {
                FirstName = newCustomer.FirstName,
                LastName = newCustomer.LastName,
                Email = newCustomer.Email,
                PhoneNumber = newCustomer.PhoneNumber,
                Address = newCustomer.Address
            };

            return CreatedAtAction(nameof(GetProfileDetails), new { id = newCustomer.Id }, customerViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProfile(Guid id, CustomerDataViewModel customer)
        {
            var existingCustomer = await _clientRepository.ProfileDetails(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.FirstName= customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.Address = customer.Address;

            await _clientRepository.EditProfile(existingCustomer);
            return Ok();
        }
    }
}
