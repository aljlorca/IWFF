using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Factura
    {
        public decimal id_factura { get; set; }
        public decimal cant_prod_factura { get; set; }
        public decimal total_factura { get; set; }
        public DateTime fecha_factura { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //Listado  
        public List<Factura> ReturnAll()
        {
            return this.db.FACTURA.Select(f => new Factura()
            {
                id_factura = f.ID_FACTURA,
                cant_prod_factura = f.CANTIDAD_PROD_FACTURA,
                total_factura = f.TOTAL_FACTURA,
                fecha_factura = f.FECHA_FACTURA
            }
            ).ToList();
        }
    }
}
