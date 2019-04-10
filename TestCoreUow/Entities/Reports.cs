using System;
using System.Collections.Generic;

namespace TestCoreUow.Entities
{
    public partial class Reports
    {
        public int ReportId { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int FkGrantId { get; set; }

        public Grants FkGrant { get; set; }
    }
}
