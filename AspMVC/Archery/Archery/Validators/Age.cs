using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Age : ValidationAttribute
    {
        public int MinimumAge { get; private set; }

        private int? maximumAge;

        public int MaximumAge
        {
            get { return (int)maximumAge; }
            set { maximumAge = value; }
        }


        public Age(int minimumAge)
        {
            this.MinimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                if (value is DateTime)
                {
                    if (this.maximumAge == null)
                        return DateTime.Now.AddYears(-this.MinimumAge) >= (DateTime)value;
                    else
                        return DateTime.Now.AddYears(-this.MinimumAge) >= (DateTime)value
                            && ((DateTime)value).AddYears(this.MaximumAge) >= DateTime.Now;
                }
                else
                    throw new ArgumentException("Le type doit être un DateTime");
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            if(this.maximumAge == null)
                return string.Format(this.ErrorMessage, name, this.MinimumAge.ToString());
            return string.Format(this.ErrorMessage, name, this.MinimumAge.ToString(), this.MaximumAge.ToString());

        }
    }
}