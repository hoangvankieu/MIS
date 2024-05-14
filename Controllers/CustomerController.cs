﻿using Microsoft.AspNetCore.Mvc;
using MIS.Entity;
using MIS.Service;

namespace MIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }




        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = _customerService.GetCustomerById(id);

            if (existingCustomer == null)
                return NotFound();

            existingCustomer.Name = customer.Name;
            existingCustomer.Address = customer.Address;
            existingCustomer.City = customer.City;
            existingCustomer.Region = customer.Region;
            existingCustomer.PostalCode = customer.PostalCode;
            existingCustomer.Country = customer.Country;

            _customerService.UpdateCustomer(existingCustomer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            _customerService.DeleteCustomer(customer);
            return NoContent();
        }
    }
}
