using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidlay.Dtos;
using Vidlay.Models;

namespace Vidlay.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }



        //GET/API/CUSTOMERS
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }


        //Get/Api/Customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok( Mapper.Map<Customer, CustomerDto>(customer));
        }


        //Post/Api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto); 
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        //Put/Api/Customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer( int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var CustomerInDB = _context.Customers.SingleOrDefault(m => m.Id == id);
            if (CustomerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, CustomerInDB);
            

            _context.SaveChanges();
            return Ok();

        }
        //Delete/Api/Customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var CustomerInDB = _context.Customers.SingleOrDefault(m => m.Id == id);
            if (CustomerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(CustomerInDB);
            _context.SaveChanges();
            return Ok();

        }



    }
}
