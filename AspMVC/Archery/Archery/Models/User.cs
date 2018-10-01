using Archery.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public abstract class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [StringLength(150, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
        [Display(Name = "Adresse mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
            , ErrorMessage = "Le format n'est pas bon.")]
        [Index(IsUnique = true)]
        [Email(ErrorMessage = "Le mail existe déjà.")]
        public string Mail { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
            ErrorMessage = "{0} incorrect.")]
        [StringLength(150)]
        public string Password { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La confirmation n'est pas bonne.")]
        [NotMapped]
        public string ConfirmedPassword { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Date de naissance")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        [DataType(DataType.Date)]
        [Age(9, MaximumAge = 90, ErrorMessage = "Pour le champ {0}, vous devez avoir plus de {1} ans")]
        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }

    }
}