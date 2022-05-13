using System.ComponentModel.DataAnnotations;

namespace DatingApp.DTO.Input
{
    public class RegisterUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
