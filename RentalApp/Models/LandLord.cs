using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Models
{
    public class LandLord {
        public int LandLordId { get; set; }
        public string AgencyName { get; set; }
        public string ContactName { get; set; }
        public int PhoneNumber { get; set; }
        //public virtual Residence Residence  { get; set; }
    }
}