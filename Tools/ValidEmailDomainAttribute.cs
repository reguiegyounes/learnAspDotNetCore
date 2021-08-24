using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace learnAspDotNetCore.Tools
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string domain;

        public ValidEmailDomainAttribute(string Domain)
        {
            domain = Domain;
            this.ErrorMessage = $"Email domain must be in {this.domain}";
        }
        public override bool IsValid(object value)
        {
            string[] values=value.ToString().Split('@');
            string[] domains=this.domain.Trim().Split(',');
            
            foreach (string domain in domains)
            {
                if (values[values.Length-1] == domain)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
