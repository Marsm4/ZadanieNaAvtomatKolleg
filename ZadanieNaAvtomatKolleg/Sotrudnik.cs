//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZadanieNaAvtomatKolleg
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sotrudnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sotrudnik()
        {
            this.Prepodovatel = new HashSet<Prepodovatel>();
            this.Zav_Otdelenia = new HashSet<Zav_Otdelenia>();
        }
    
        public int ID_sotrudnika { get; set; }
        public string Familia { get; set; }
        public string Ima { get; set; }
        public string Othestvo { get; set; }
        public Nullable<System.DateTime> Data_Rojdenia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prepodovatel> Prepodovatel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zav_Otdelenia> Zav_Otdelenia { get; set; }
    }
}
