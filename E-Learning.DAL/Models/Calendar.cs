using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Models
{
    public class Calendar
    {
        [DataType(DataType.Upload)]
        public string Id { get; set; }
        public string Event { get; set; }
        public DateTime date { get; set; }
        public string user { get; set; }
    }
}
