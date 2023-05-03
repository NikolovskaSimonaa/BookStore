using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Models
{
    public class Author
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [StringLength(50)] public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        [StringLength(50)] public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        [StringLength(50)] public string? Nationality { get; set; }
        [StringLength(50)] public string? Gender { get; set; }
        public ICollection<Book> Books { get; set; } //eden avtor moze da ima poveke knigi

        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }
    }
}
