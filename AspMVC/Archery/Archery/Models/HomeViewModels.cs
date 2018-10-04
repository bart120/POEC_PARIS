using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Tournament> Tournaments { get; set; }
    }
}