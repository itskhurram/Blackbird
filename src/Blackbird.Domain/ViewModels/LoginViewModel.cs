using System.ComponentModel.DataAnnotations;

namespace Blackbird.Domain.ViewModels {
    public class LoginViewModel {
        [Required]
        public string LoginName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
