using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class TournamentPicture : BaseModel
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string ContentType { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public int TournamentID { get; set; }

        [ForeignKey("TournamentID")]
        public Tournament Tournament { get; set; }

    }
}