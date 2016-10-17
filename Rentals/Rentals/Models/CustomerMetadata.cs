using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rentals.Models
{
    [MetadataType(typeof(Customer.Metadata))]
    public partial class Customer
    {
        sealed class Metadata
        {
            public System.Guid CustomerId { get; set; }

            [Required]
            [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
            public string Email { get; set; }


            public string Name { get; set; }

            [Required]
            public string Phone { get; set; }

            [Required]
            public string Address { get; set; }

            [Required]
            public string Password { get; set; }

            public string Films { get; set; }

        }
    }
}