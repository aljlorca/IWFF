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
    
    public partial class PERSONA
    {
        public PERSONA()
        {
            this.CLIENTE = new HashSet<CLIENTE>();
            this.EMPLEADO = new HashSet<EMPLEADO>();
        }
    
        public string RUT { get; set; }
        public string NOMBRE { get; set; }
        public string CORREO { get; set; }
        public Nullable<int> TELEFONO { get; set; }
        public string DIRECCION { get; set; }
        public string ID_COMUNA { get; set; }
    
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }
        public virtual ICollection<EMPLEADO> EMPLEADO { get; set; }
    }
}
