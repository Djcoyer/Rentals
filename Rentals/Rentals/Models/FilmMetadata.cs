using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rentals.Models
{
    [MetadataType(typeof(Film.Metadata))]
    public partial class Film
    {
        sealed class Metadata
        {
            [Key]
            public System.Guid FilmId { get; set; }

            [Required(ErrorMessage ="Please Select a Genre")]
            [Display(Name ="Film Genre")]
            public Rentals.Enums.Genres Genre { get; set; }

            [Display(Name="Film Series")]
            public string Series { get; set; }

            [Required(ErrorMessage ="A Film Title is Required")]
            [Display(Name="Film Title")]
            [StringLength(100, ErrorMessage = "Value entered is too long.")]
            public string Name { get; set; }

            [Required(ErrorMessage ="Please ")]
            [Display(Name ="Release Year")]
            [RegularExpression(@"^(19|20)\d{2}$", ErrorMessage ="Please enter a valid release year.")]
            public int Year { get; set; }

            public string Details { get; set; }

            [RegularExpression(@"^[1-9][0-9]?$|^100$")]
            public Nullable<int> NumberofSeries { get; set; }

            public Nullable<System.Guid> Renter { get; set; }

            public bool Available { get; set; }
        }


    }
}