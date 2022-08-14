using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WalletManagementEntity
{
    public class User
    {
        [Required]
        [Key]
        public int UserId { get; set; }

        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter name")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }

        [Phone]
        [Required(ErrorMessage = "Please enter Contact Number")]
        public string PhoneNo { get; set; }

        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Please enter min 8 digit with uppercase lowercase digit and special char")]
        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        public string SecretPassword { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [Compare("SecretPassword")]
        public string CompareSecretPassword { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
