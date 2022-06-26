using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Models
{
    public class Faculty
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int age { get; set; }

        [Required(ErrorMessage = "Father's Name is required")]
        public string FathersName { get; set; }

        [Required(ErrorMessage = "Mother's Name is required")]
        public string MothersName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Username is required"), NotNull]
        public string Username { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }
    }
}
