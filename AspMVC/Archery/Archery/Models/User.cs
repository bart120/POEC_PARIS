using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public abstract class User
    {
        public int ID { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

    }
}