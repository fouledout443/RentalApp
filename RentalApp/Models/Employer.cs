using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalApp.Models
{
    public enum EmployerStatus {
        Previous,
        Current
    }

    public enum PayType {
        Hourly,
        Salary
    }
    public class Employer {
        public int EmployerID { get; set; }
        public string EmployerName { get; set; }
        public string Location { get; set; }
        public string ManagerName { get; set; }
        public int PhoneNumber { get; set; }
        public string PositionTitle { get; set; }
        public string JobDescription { get; set; }
        public string ReasonForLeaving { get; set; }
        public string DurationOfEmployment { get; set; }
        public PayType PayType { get; set; }
    }
}