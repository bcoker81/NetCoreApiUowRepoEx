using System;
using System.Collections.Generic;

namespace TestCoreUow.Entities
{
    public partial class AuditLog
    {
        public int AuditId { get; set; }
        public string GrantNumber { get; set; }
        public string UserName { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Message { get; set; }
    }
}
