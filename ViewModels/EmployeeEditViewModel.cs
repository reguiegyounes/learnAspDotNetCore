using learnAspDotNetCore.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace learnAspDotNetCore.ViewModels
{
    public class EmployeeEditViewModel:EmployeeCreateViewModel
    {
        public int Id { get; set; }
        public string imageOldPath { get; set; }
    }
}
