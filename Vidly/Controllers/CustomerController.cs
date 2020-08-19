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
            return View(membershipType);
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipTypes).ToList();

            return View(customers);
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