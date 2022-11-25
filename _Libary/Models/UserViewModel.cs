using Business;
using System.ComponentModel.DataAnnotations;

namespace _Libary.Models
{
    public class UserViewModel
    {
       
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Surname { get; set; }
       
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 8,ErrorMessage ="The paasword must be at least 8 character")]
        public string Password { get; set; }
        [Required]
        public bool Rol { get; set; }

        public UserViewModel(User user)
        {
            this.UserID = user.UserID;
            this.UserName = user.UserName;
            this.Surname = user.Surname;
            this.Email = user.Email;
            this.Password = user.Password;
            this.Rol = user.Rol;
        }

        public UserViewModel()
        {
        }



    }
}
