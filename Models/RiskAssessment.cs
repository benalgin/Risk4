using System.Collections.Generic;

namespace Risk.Models
{
    public class RiskAssessment
    {
        public int Id{get; set;}
        public string Title{get; set;}
        public double Latitude{get;set;}
        public double Longitude {get; set;}
        public ICollection<Threat> Threats {get; set;} 
    }
}