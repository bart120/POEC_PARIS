using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public class Player : User
    {
        public string LicenseNumber { get; set; }
    }
}