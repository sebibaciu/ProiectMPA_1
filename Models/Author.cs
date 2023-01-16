using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProiectMPA_1.Models
{
    public class Author
    {
        public int ID { get; set; }
        [Display(Name = "First name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last name")]
        public string? LastName { get; set; }
        [Display(Name = "Full name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        // One-many relationship (an author can write multiple books)
        public ICollection<Book>? Book { get; set; }
    }
}
