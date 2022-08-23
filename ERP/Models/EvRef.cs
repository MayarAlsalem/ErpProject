using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public partial class EvRef
    {
        public EvRef()
        {
            Ev = new HashSet<Ev>();
        }

        public int IdEvRef { get; set; }
        [Display(Name =("اسم مرجع الحدث"))]
        public string NaEvRef { get; set; }

        public virtual ICollection<Ev> Ev { get; set; }
    }
}
