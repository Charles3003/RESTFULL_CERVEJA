//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MD_RESTFULL_NEGOCIO.Pesistencia
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_CAD_COMENTARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_CAD_COMENTARIO()
        {
            this.TB_CAD_COMENTARIO1 = new HashSet<TB_CAD_COMENTARIO>();
        }
    
        public int CD_COMENTARIO { get; set; }
        public Nullable<int> CD_COMENTARIO_PAI { get; set; }
        public Nullable<int> CD_USUARIO { get; set; }
        public int CD_PRODUTO { get; set; }
        public Nullable<int> CD_DISTRIBUIDORA { get; set; }
        public string DS_COMENTARIO { get; set; }
        public System.DateTime DT_DATA_CRIACAO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_CAD_COMENTARIO> TB_CAD_COMENTARIO1 { get; set; }
        public virtual TB_CAD_COMENTARIO TB_CAD_COMENTARIO2 { get; set; }
        public virtual TB_CAD_PRODUTO TB_CAD_PRODUTO { get; set; }
        public virtual TB_CAD_USUARIO TB_CAD_USUARIO { get; set; }
    }
}
