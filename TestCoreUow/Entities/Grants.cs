using System;
using System.Collections.Generic;

namespace TestCoreUow.Entities
{
    public partial class Grants
    {
        public Grants()
        {
            Comments = new HashSet<Comments>();
            Extensions = new HashSet<Extensions>();
            Reports = new HashSet<Reports>();
        }

        public int Id { get; set; }
        public string MshpGrantNumber { get; set; }
        public string Status { get; set; }
        public string GrantName { get; set; }
        public decimal CfdaNumber { get; set; }
        public string Component { get; set; }
        public string ProjectDirector { get; set; }
        public string Accountant { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public DateTime? ExtendedProjectDate { get; set; }
        public decimal AwardAmount { get; set; }
        public decimal Expenditures { get; set; }
        public string AwardContractNumber { get; set; }
        public string LdprProjectNumber { get; set; }
        public bool Match { get; set; }
        public string Division { get; set; }
        public DateTime FinancialReportDueDate { get; set; }
        public DateTime ProgrammingReportDueDate { get; set; }
        public decimal RemainingBal { get; set; }
        public string Granter { get; set; }
        public DateTime ApplicationDueDate { get; set; }
        public string ApplicationStatus { get; set; }
        public string Forecast { get; set; }
        public DateTime AwardDate { get; set; }
        public string GrantType { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public ICollection<Extensions> Extensions { get; set; }
        public ICollection<Reports> Reports { get; set; }
    }
}
