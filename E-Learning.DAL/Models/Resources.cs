﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Models
{
    public class Resources
    {
        [Key]
        public string Id { get; set; }
        public string Heading { get; set; }
        public string Body { get; set; }
        public DateTime Time { get; set; }
    }
}
