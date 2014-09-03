using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Models
{
    public class UserInfo
    {
        //Extended user properties
        public int UserInfoID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Employer> Employers { get; set; }
    }
}