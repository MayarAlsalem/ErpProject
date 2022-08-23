using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public partial class Pe
    {
        public Pe()
        {
            InverseId1PeNavigation = new HashSet<Pe>();
            PeEv = new HashSet<PeEv>();
            PeWo = new HashSet<PeWo>();
            Ta = new HashSet<Ta>();
        }
        [Required]
        [Display(Name = "الرقم")]
        public int IdPe { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم المرجع "), Display(Name = "الاسم")]
        public string NaPe { get; set; }
        [Display(Name = "الجنسية")]
        public string NatPe { get; set; }
        [Display(Name = "المدينة")]
        public string CiPe { get; set; }
        [Display(Name = "العمل")]
        public string JoPe { get; set; }
        [Required(ErrorMessage = "يجب ادخال رقم الهاتف  "), Display(Name = "الهاتف")]
        [RegularExpression("^\\+\\d*\\s?(\\d+[\\s?]\\d+)+(\\s?\\-\\s?\\+\\d*\\s?(\\d+[\\s?]\\d+)+)*$", ErrorMessage = "خطا في تنسيق رقم الهاتف")]

        public string PhoPe { get; set; }
        [Display(Name = "الملاحظات")]
        public string NotPe { get; set; }
        [Required]
        [Display(Name = "تاريخ التعريف")]
        public DateTime DaPe { get; set; }
        [Display(Name = "الشهادة")]
        public string CerPe { get; set; }
        [Display(Name = "البريد الاكتروني")]
        public string EmPe { get; set; }
        [Display(Name = "تاريخ التسجيل")]
        public DateTime DaNpe { get; set; }
        [Display(Name = "طريقة التعارف")]
        public int? Id1Pe { get; set; }
        [Display(Name = "طريقة التصنيف")]
        public string MetPe { get; set; }
        [Display(Name = "التصنيف")]
        public int? IdPeCat { get; set; }
        [Required]
        [Display(Name = "اخر تواصل")]
        public DateTime DaEnPe { get; set; }
        [Display(Name = "النوع")]
        public string TyPe { get; set; }
        public virtual Pe Id1PeNavigation { get; set; }
        public virtual PeCat IdPeCatNavigation { get; set; }
        public virtual ICollection<Ev> Ev { get; set; }
        public virtual ICollection<Pe> InverseId1PeNavigation { get; set; }
        public virtual ICollection<PeEv> PeEv { get; set; }
        public virtual ICollection<PeWo> PeWo { get; set; }
        public virtual ICollection<Ta> Ta { get; set; }
    }
}
