using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningMVC.Models
{
    public class ProjectModel
    {
        public string project { get; set; }
        public IFormFile file { get; set; }
        public string assignTo { get; set; }
    }
}
