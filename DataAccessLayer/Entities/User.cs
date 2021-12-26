using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class User : Base
    {
        public string userName { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;
        public string fullName { get; set; } = String.Empty; 
    }
}
