//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IWFF.DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class DESPACHO
    {
        public decimal ID_DESPACHO { get; set; }
        public Nullable<decimal> ID_ORDEN_COMPRA1 { get; set; }
        public string ID_CLIENTE { get; set; }
        public decimal ORDEN_DESPACHO_ID_ORDEN_COMPRA { get; set; }
        public decimal ORDEN_DESPACHO_ID_CLIENTE { get; set; }
        public string ORDEN_DESPACHO_RUT { get; set; }
        public string ORDEN_DESPACHO_ID_COMUNA { get; set; }
        public decimal BOLETA_ID_BOLETA { get; set; }
        public decimal FACTURA_ID_FACTURA { get; set; }
    
        public virtual BOLETA BOLETA { get; set; }
        public virtual FACTURA FACTURA { get; set; }
        public virtual ORDEN_DESPACHO ORDEN_DESPACHO { get; set; }
    }
}
