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
    
    public partial class CLIENTE
    {
        public CLIENTE()
        {
            this.COTIZACION = new HashSet<COTIZACION>();
        }
    
        public decimal RUT_PERSONA { get; set; }
    
        public virtual PERSONA PERSONA { get; set; }
        public virtual ICollection<COTIZACION> COTIZACION { get; set; }
    }
}
