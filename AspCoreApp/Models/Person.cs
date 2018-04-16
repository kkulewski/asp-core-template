using System.ComponentModel.DataAnnotations;

namespace AspCoreApp.Models
{
    public class Person
    {
        public string Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public Address Address { get; set; }

        public string AddressId { get; set; }
    }
}
