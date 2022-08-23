using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public partial class Ev
    {
        public Ev()
        {
            PeEv = new HashSet<PeEv>();
        }
        [Display(Name ="الرقم")]
        public int IdEv { get; set; }
        [Display(Name = "تاريخ")]
        public DateTime? DaEv { get; set; }
        [Display(Name = "البداية")]
        public DateTime? Ti1Ev { get; set; }
        [Display(Name = "البيان")]
        public string TitEv { get; set; }
        [Display(Name = "المحتوى")]
        public string ExEv { get; set; }
        [Display(Name = "الملاحظات")]
        public string NotEv { get; set; }
        [Display(Name = "المكان")]
        public string PlEv { get; set; }
        [Display(Name = "تاريخ تسجيل القيد")]
        public DateTime? DaNev { get; set; }
        [Display(Name = "رقم الشخص")]
        public int? IdPe { get; set; }
        [Display(Name = "رمز المشروع")]
        public string CoPr { get; set; }
        [Display(Name = "مرجع الاحداث")]
        public int? IdEvRef { get; set; }
        [Display(Name = "ارشفة")]
        public bool ArEv  { get; set; }
        [Display(Name = "النهاية")]
        public DateTime? Ti2Ev { get; set; }

        public virtual Pr CoPrNavigation { get; set; }
        public virtual EvRef IdEvRefNavigation { get; set; }
        public virtual Pe IdPeNavigation { get; set; }
        public virtual ICollection<PeEv> PeEv { get; set; }
    }
}
