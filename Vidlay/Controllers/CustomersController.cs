using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidlay.Models;
using Vidlay.ViewModels;

namespace Vidlay.Controllers
{
    
    public class CustomersController : Controller
    {
        // GET: CustomersController
        private ApplicationDbContext _Context;
        public CustomersController()
        {
            _Context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _Context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
                   
            }

            if (customer.Id == 0)
                _Context.Customers.Add(customer);
            else
            {
                var customerInDb = _Context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _Context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        
        public ActionResult New()
        {
            var membershipTypes = _Context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }
        //create view of customer


        //return a index view result of customers
        
        public ViewResult Index()
        {
            

            return View();
        }

        //detail view of a customer
        
        public ActionResult Details(int id)
        {
            var customer = _Context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        
        public ActionResult Edit(int id)
        {
            var Customer = _Context.Customers.SingleOrDefault(c => c.Id == id);
            if (Customer == null)
                return HttpNotFound();
            


            var viewModel = new CustomerFormViewModel
            {
                Customer = Customer,
                MembershipTypes = _Context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}