using System;
using System.Collections.Generic;

namespace ERP.Models
{
    public partial class PeWo
    {
        public int IdPeWo { get; set; }
        public int? IdPe { get; set; }
        public string JoDePeWo { get; set; }
        public int? OrPeWo { get; set; }
        public DateTime? DaPeWo { get; set; }

        public virtual Pe IdPeNavigation { get; set; }
    }
}
