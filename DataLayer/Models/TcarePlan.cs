using System;
using System.Collections.Generic;

#nullable disable

namespace CarePlanWebApi.DataLayer.Models
{
    public partial class TcarePlan
    {
        public int IdCarePlan { get; set; }
        public string Title { get; set; }
        public string PatientName { get; set; }
        public string UserName { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime TargetDate { get; set; }
        public string Reason { get; set; }
        public string Action { get; set; }
        public bool Completed { get; set; }
        public DateTime? EndDate { get; set; }
        public string Outcome { get; set; }
    }
}
