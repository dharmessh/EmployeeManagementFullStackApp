using System.ComponentModel.DataAnnotations;

namespace BooksAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get;set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-Mail is Required")]
        [EmailAddress(ErrorMessage = "Inavalid E-Mail")]
        public string Email { get;set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Position is Required")]
        public string Position {  get; set; }

    }
}
