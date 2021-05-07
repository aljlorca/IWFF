using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Despacho
    {
        public decimal id_despaco { get; set; }
        public DateTime fecha_despacho { get; set; }
        public String estado_despacho { get; set; }
        public decimal id_factura { get; set; }
        public Factura factura { get; set; }
        public decimal id_boleta { get; set; }
        public Boleta boleta { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //Listado
        public List<Despacho> ReadAll()
        {
            return this.db.DESPACHO.Select(d => new Despacho()
            {
                id_despaco = d.ID_DESPACHO,
                fecha_despacho = d.FECHA_DESPACHO,
                estado_despacho = d.ESTADO_DESPACHO,
                id_factura = d.FACTURA_ID_FACTURA,
                factura = new Factura()
                {
                    id_factura = d.FACTURA.ID_FACTURA,
                    cant_prod_factura = d.FACTURA.CANTIDAD_PROD_FACTURA,
                    total_factura = d.FACTURA.TOTAL_FACTURA,
                    fecha_factura = d.FACTURA.FECHA_FACTURA
                },
                id_boleta = d.BOLETA_ID_BOLETA,
                boleta = new Boleta()
                {
                    id_boleta = d.BOLETA.ID_BOLETA,
                    cant_prod_boleta = d.BOLETA.CANTIDAD_PROD_BOLETA,
                    total_boleta = d.BOLETA.TOTAL_BOLETA,
                    fecha_boleta = d.BOLETA.FECHA_BOLETA
                }
                
            }
            ).ToList();

        }

    }

}
