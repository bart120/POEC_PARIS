using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Models
{
    public class Tournament : BaseModel
    {
        [Required]
        [Display(Name = "Nom")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Lieu")]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Début")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:MM}")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Fin")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:MM}")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Nombre d'archer max")]
        public int ArcherCount { get; set; }

        [Display(Name = "Prix")]
        public decimal? Price { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Armes")]
        public ICollection<Weapon> Weapons { get; set; }

        [Display(Name = "Tireurs")]
        public ICollection<Shooter> Shooters { get; set; }
    }
}