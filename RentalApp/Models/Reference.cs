using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalApp.Models
{ 
    public class Reference {
        public int ReferenceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public int YearsKnown { get; set; }
        public int PhoneNumber { get; set; }
    }
}