using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Areas.BackOffice.Models
{
    public class AuthenticationLoginViewModel
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        public string Mail { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}