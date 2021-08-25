using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace learnAspDotNetCore.ViewModels
{
    public class AdministrationCreateRoleViewModel
    {
        [Required]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
