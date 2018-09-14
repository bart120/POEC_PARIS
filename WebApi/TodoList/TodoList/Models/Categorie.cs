using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TodoList.Data;

namespace TodoList.Models
{
    public class Categorie
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        //[Column("Name")]
        public string Nom { get; set; }
    }
}