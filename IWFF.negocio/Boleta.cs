using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Boleta
    {
        public decimal id_boleta { get; set; }
        public decimal cant_prod_boleta { get; set; }
        public decimal total_boleta { get; set; }
        public DateTime fecha_boleta { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //listado
        public List<Boleta> ReadAll()
        {
            return this.db.BOLETA.Select(b => new Boleta()
            {
                id_boleta = b.ID_BOLETA,
                cant_prod_boleta = b.CANTIDAD_PROD_BOLETA,
                total_boleta = b.TOTAL_BOLETA,
                fecha_boleta = b.FECHA_BOLETA,

            }).ToList();
        }
    }
}
