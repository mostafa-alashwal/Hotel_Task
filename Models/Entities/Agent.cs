using System.ComponentModel.DataAnnotations;

namespace Hotel_Task.Models.Entities
{
    public class Agent
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [StringLength(50, ErrorMessage = "User Name cannot be longer than 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [StringLength(250, ErrorMessage = "Remark cannot be longer than 250 characters.")]
        public string Remake { get; set; }

        public bool IsDeleted { get; set; } // Assuming you are using this for soft deletion
    }
}
