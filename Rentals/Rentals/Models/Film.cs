using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentals.Models
{
    public partial class Film
    {
        public System.Guid FilmId { get; set; }

        public Rentals.Enums.Genres Genre { get; set; }

        public string Series { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Details { get; set; }

        public Nullable<int> NumberofSeries { get; set; }

        public string Renter { get; set; }

        public bool Rented { get; set; }
    }
}