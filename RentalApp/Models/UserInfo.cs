using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalApp.Models
{
    public class UserInfo {

        //Extended user properties
        //PRIMARY KEY  --EF looks for a property with the same name as the class with ID on the end
        //OR for a data annotation on the field like this [Key] 
        public int UserInfoID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }

        //These virtual properties are called 'navigation fields' which allows entity framework
        //to see that an instance of UserInfo can have many addresses or employers
        public virtual ICollection<Residence> Residence { get; set; }
        public virtual ICollection<Employer> Employers { get; set; }
        public virtual ICollection<Reference> References { get; set; }
    }
}