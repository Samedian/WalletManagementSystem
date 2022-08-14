using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WalletManagementEntity
{
    public class Card
    {
        [Required]
        [Key]
        public int CardId { get; set; }

        [Required(ErrorMessage = "Please enter Card Number")]
        [CreditCard]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Please enter Owner Name")]
        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string CardOwnerName { get; set; }


        [Range(1, 12, ErrorMessage = "Range b/w 1 to 12")]
        [Required]
        public int Month { get; set; }

        public int Year { get; set; }

        public int UserId { get; set; }

    }
}
