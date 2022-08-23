using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public partial class Pr
    {
        public Pr()
        {
            Ev = new HashSet<Ev>();
        }

        public int Idpr { get; set; }
        [Display(Name ="رمز المشروع")]
        public string CoPr { get; set; }
        public string DesPr { get; set; }
        public DateTime? DaPr { get; set; }
        public string StPr { get; set; }
        public int? IdPrTy { get; set; }

        public virtual ICollection<Ev> Ev { get; set; }
    }
}
