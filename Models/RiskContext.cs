using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Risk.Models
{
    public class RiskContext: DbContext
    {
        public RiskContext(DbContextOptions<RiskContext> options)
            : base(options)
            {

            }
        //public RiskContext(){}
            public DbSet<RiskAssessment> RiskAssessments {get; set;}
            public DbSet<Threat> Threats {get; set;}
    }
}