using System;
using System.Collections.Generic;

namespace ERP.Models
{
    public partial class PeCat
    {
        public PeCat()
        {
            Pe = new HashSet<Pe>();
        }

        public int IdPeCat { get; set; }
        public string PeCat1 { get; set; }

        public virtual ICollection<Pe> Pe { get; set; }
    }
}
