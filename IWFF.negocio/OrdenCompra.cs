using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class OrdenCompra
    {
        public decimal id_orden_compra { get; set; }
        public String estado_orden_compra { get; set; }
        public decimal id_cotizacion { get; set; }
        public decimal id_proveedor { get; set; }
        public decimal id_boleta { get; set; }
        public decimal id_factura { get; set; }
        public decimal rut_persona { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //Listado
        public List<OrdenCompra> ReadAll()
        {
            return this.db.ORDEN_COMPRA.Select(o => new OrdenCompra()
            {
                id_orden_compra = o.ID_ORDEN_COMPRA,
                estado_orden_compra = o.ESTADO,
                id_cotizacion = o.COTIZACION_ID,
                id_proveedor = o.COTIZACION_PROVEEDOR_ID,
                id_boleta = o.BOLETA_ID_BOLETA,
                id_factura = o.FACTURA_ID_FACTURA,
                rut_persona = o.COTIZACION_CLIENTE_RUT_PERSONA
            }
            ).ToList();

        }
    }
}
