using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebPage.Models
{
    public class ContactViewModel
    {
        public String Email { get; set; }
        public String Name { get; set; }
        public String Subject { get; set; }
        public String Message { get; set; }
    }
}
