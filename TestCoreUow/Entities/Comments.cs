using System;
using System.Collections.Generic;

namespace TestCoreUow.Entities
{
    public partial class Comments
    {
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public int FkGrantId { get; set; }

        public Grants FkGrant { get; set; }
    }
}
