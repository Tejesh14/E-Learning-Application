using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL.Models
{
    public class TokenReturn
    {
        public string userId { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
