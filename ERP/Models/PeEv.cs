using System;
using System.Collections.Generic;

namespace ERP.Models
{
    public partial class PeEv
    {
        public int? IdPe { get; set; }
        public string RelPeEv { get; set; }
        public DateTime? DaNpe { get; set; }
        public int IdPeEv { get; set; }
        public int? IdEv { get; set; }

        public virtual Ev IdEvNavigation { get; set; }
        public virtual Pe IdPeNavigation { get; set; }
    }
}
