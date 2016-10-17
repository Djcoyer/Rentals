using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rentals.Models;
using Rentals.DTOs;

namespace Rentals.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerDto customer { get; set; }
        private List<CustomerDto> customers = CustomerManager.GetCustomers();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {   
            return View(customer);
        }

        public ActionResult Create()
        {
            return View(customer);
        }

        public ActionResult AddCustomer(CustomerDto customerDto)
        {
            return RedirectToAction("createCustomer", "Customer", customerDto);
        }

        public ActionResult CreateCustomer(CustomerDto customerDto)
        {
            customerDto.CustomerId = Guid.NewGuid();
            CustomerManager.AddCustomer(customerDto);
            return RedirectToAction("Index", "Home");
        }

        public string ValidateLogin(CustomerDto customerDto)
        {
            var email = customerDto.Email;
            var password = customerDto.Password;
            var customer = customers.FirstOrDefault(p => p.Email == email);

            if(password == customer.Password)
            {
                return "Logged in";
            }
            else
            {
                return "Failed";
            }
        }
    }
}