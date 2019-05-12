using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace Risk.Models
{
    public class Threat
    {
        public int Id{get; set;}
        public string Title{get; set;}
        [Range(0,2)]
        public int Level{get;set;}
        public int RiskAssessmentId {get; set;}
        public RiskAssessment RiskAssessment {get; set;}
    }
}