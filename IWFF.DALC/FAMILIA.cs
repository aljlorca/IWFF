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
    
    public partial class FAMILIA
    {
        public FAMILIA()
        {
            this.PRODUCTO = new HashSet<PRODUCTO>();
        }
    
        public decimal ID_FAMILIA { get; set; }
        public string NOMBRE_FAMILIA { get; set; }
    
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }
    }
}
