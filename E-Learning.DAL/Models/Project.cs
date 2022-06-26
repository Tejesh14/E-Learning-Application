using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Models
{
    public class Project
    {
        [Key]
        public string Id { get; set; }
        public string ProjectName { get; set; }
        public string FileNameAssigned { get; set; }
        public string FileTypeAssigned { get; set; }
        public string AssignBy { get; set; }
        public DateTime AssignedAt { get; set; }
        //student
        public string FileNameSubmitted { get; set; }
        public string FileTypeSubmitted { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string AssignTo { get; set; }
    }
}
