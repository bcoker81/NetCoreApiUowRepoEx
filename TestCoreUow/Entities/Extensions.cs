using System;
using System.Collections.Generic;

namespace TestCoreUow.Entities
{
    public partial class Extensions
    {
        public int GrantExtensionId { get; set; }
        public DateTime ExtensionDate { get; set; }
        public int FkGrantId { get; set; }

        public Grants FkGrant { get; set; }
    }
}
