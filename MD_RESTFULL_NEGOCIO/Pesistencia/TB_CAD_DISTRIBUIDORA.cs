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
    
    public partial class TB_CAD_DISTRIBUIDORA
    {
        public int CD_USUARIO { get; set; }
        public string NM_RAZAO_SOCIAL { get; set; }
        public string NR_TELEFONE { get; set; }
        public string CNPJ { get; set; }
        public System.DateTime DT_DATA_HORA_INICIO_ENTREGA { get; set; }
        public System.DateTime DT_DATA_HORA_FIM_ENTREGA { get; set; }
        public string DS_SAUDACAO { get; set; }
        public Nullable<decimal> VL_VALOR_ENTREGA_PEDIDO { get; set; }
        public byte[] IMG_LOGO_DISTRIBUIDORA { get; set; }
    
        public virtual TB_CAD_USUARIO TB_CAD_USUARIO { get; set; }
    }
}
