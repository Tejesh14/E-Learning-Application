using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Models
{
    public class Chat
    {
        [Key]
        public string Id { get; set; }
        public string SendFrom { get; set; }
        public string SendTo { get; set; }
        public string Message { get; set; }
        public DateTime SendAt { get; set; }
    }
}
