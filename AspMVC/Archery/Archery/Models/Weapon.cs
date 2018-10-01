using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class Weapon : BaseModel
    {
        [Required]
        [Display(Name = "Nom de l'arme")]
        public string Name { get; set; }

        [Display(Name = "Tournois")]
        public ICollection<Tournament> Tournaments { get; set; }
    }
}