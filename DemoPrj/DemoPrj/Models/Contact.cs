using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoPrj.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Contact()
        {
            ID = -1;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
    }
}