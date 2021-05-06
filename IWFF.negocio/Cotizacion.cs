using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Cotizacion
    {
        public decimal id_cotizacion { get; set; }
        public DateTime fecha_cotizacion { get; set; }
        public decimal total_cotizacion { get; set; }
        public decimal empleado_cargo_id { get; set; }
        public decimal proveedor_id { get; set; }
        public decimal cliente_id { get; set; }
        public decimal empleado_id { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //Listado
        public List<Cotizacion> ReadAll()
        {
            return this.db.COTIZACION.Select(c => new Cotizacion() { 
            
                id_cotizacion = c.ID_COTIZACION,
                fecha_cotizacion = c.FECHA_COTIZACION,
                total_cotizacion = c.TOTAL_COTIZACION,
                empleado_cargo_id = c.EMPLEADO_CARGO_ID,
                proveedor_id = c.PROVEEDOR_ID,
                cliente_id = c.CLIENTE_RUT,
                empleado_id = c.EMPLEADO_ID

            }
            ).ToList();
        }

    }
}
