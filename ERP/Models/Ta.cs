using System;
using System.Collections.Generic;

namespace ERP.Models
{
    public partial class Ta
    {
        public DateTime? DaTa { get; set; }
        public int? IdCat { get; set; }
        public string NotTa { get; set; }
        public string Ta1 { get; set; }
        public int IdTa { get; set; }
        public int? IdPe { get; set; }
        public DateTime? DaNta { get; set; }

        public virtual Pe IdPeNavigation { get; set; }
    }
}
