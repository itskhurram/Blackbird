using System.ComponentModel.DataAnnotations;

namespace Blackbird.Domain.ViewModels {
    public class LoginViewModel {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
