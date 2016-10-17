using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rentals.DTOs
{
    public class FilmDto
    {
        public System.Guid FilmId { get; set; }
        public Rentals.Enums.Genres Genre { get; set; }
        public string Series { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Details { get; set; }
        public Nullable<int> NumberofSeries { get; set; }
        public bool Available { get; set; }
        public string Renter { get; set; }
    }
}