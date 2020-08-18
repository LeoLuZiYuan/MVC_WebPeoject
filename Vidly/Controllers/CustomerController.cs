using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        [Route("customer/detail/{id}")]
        public ActionResult Detail(int id)
        {

            var customer = GetCustomers().SingleOrDefault(v => v.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer(){Id = 1, Name = "John Smith"},
                new Customer(){Id = 2, Name = "Mary Williams"}
            };

            return customers;
        }
    }
}