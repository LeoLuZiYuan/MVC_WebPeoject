using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };
            return View("CustomerForm", viewModel);
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
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(v => v.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypesId = customer.MembershipTypesId;
                customerInDb.IsSubscribedToNewLetter = customer.IsSubscribedToNewLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(v => v.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        // GET: Customer
        public ActionResult Index()
        {
            // var customers = _context.Customers.Include(c => c.MembershipTypes).ToList();
            //
            // return View(customers);

            //Get from API
            return View();
        }

        [Route("customer/detail/{id}")]
        public ActionResult Detail(int id)
        {

            var customer = _context.Customers.Include(c => c.MembershipTypes).SingleOrDefault(v => v.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


    }
}