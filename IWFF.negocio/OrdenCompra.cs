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
        public Cotizacion cotizacion { get; set; }
        public decimal id_proveedor { get; set; }
        public decimal id_boleta { get; set; }
        public Boleta boleta { get; set; }
        public decimal id_factura { get; set; }
        public Factura factura { get; set; }
        public decimal rut_persona { get; set; }
        public Persona persona { get; set; }
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
                cotizacion = new Cotizacion()
                {
                    id_cotizacion = o.COTIZACION.ID_COTIZACION,
                    fecha_cotizacion = o.COTIZACION.FECHA_COTIZACION,
                    total_cotizacion = o.COTIZACION.TOTAL_COTIZACION,
                    empleado_cargo_id = o.COTIZACION.EMPLEADO_CARGO_ID,
                    proveedor_id = o.COTIZACION.PROVEEDOR_ID,
                    cliente_id = o.COTIZACION.CLIENTE_RUT,
                    empleado_id = o.COTIZACION.EMPLEADO_ID
                },
                boleta = new Boleta()
                {
                  id_boleta = o.BOLETA.ID_BOLETA,
                  cant_prod_boleta = o.BOLETA.CANTIDAD_PROD_BOLETA,
                  total_boleta = o.BOLETA.TOTAL_BOLETA,
                  fecha_boleta = o.BOLETA.FECHA_BOLETA
                },
                id_proveedor = o.COTIZACION_PROVEEDOR_ID,
                id_boleta = o.BOLETA_ID_BOLETA,
                id_factura = o.FACTURA_ID_FACTURA,
                factura = new Factura()
                {
                    id_factura = o.FACTURA.ID_FACTURA,
                    cant_prod_factura = o.FACTURA.CANTIDAD_PROD_FACTURA,
                    total_factura = o.FACTURA.TOTAL_FACTURA,
                    fecha_factura = o.FACTURA.FECHA_FACTURA
                },
                rut_persona = o.COTIZACION_CLIENTE_RUT_PERSONA,
            
            }
            ).ToList();

        }
    }
}
