using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class Patron
    {
        [Key]
        public int PatronId { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Display(Name="Library")]
        public int LibraryId { get; set; }

        public Library Library { get; set; }


        public ICollection<Book> CheckedOutBooks { get; set; }

    }
}
