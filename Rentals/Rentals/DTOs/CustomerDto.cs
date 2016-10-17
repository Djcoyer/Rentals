using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rentals.Models;

namespace Rentals.DTOs
{
    public class CustomerDto
    {
        public System.Guid CustomerId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Films { get; set; }
    }
}