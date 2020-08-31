using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipTypes> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public string Title {
            get
            {
                return Customer.Id == 0 ? "New Customer" : "Edit Customer";
            }
        }   
    }
}