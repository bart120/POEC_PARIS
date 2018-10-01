using Archery.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Validators
{
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value != null && value is string)
            {
                using(ArcheryDbContext db = new ArcheryDbContext())
                {
                    return !db.Archers.Any(x => x.Mail == value.ToString());
                }
            }
            return true;
        }
    }
}