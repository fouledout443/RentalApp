using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalApp.Models
{
    public enum ResidenceType {
        Rent,
        Own
    };

    public class Residence {
        public int ResidenceID { get; set; }
        public string ResidenceNickName { get; set; }
        public ResidenceType ResidenceType { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string Duration { get; set; }
        public bool CurrentAddress { get; set; }
        public virtual LandLord LandLord { get; set; }
    }
}
