using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Proveedor
    {
        public decimal id_proveedor { get; set; }
        public String nombre_proveedor { get; set; }
        public decimal telefono_proveedor { get; set; }
        public String rubro_proveedor { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //Listado proveedores
        public List<Proveedor> ReadAll()
        {
            return this.db.PROVEEDOR.Select(p => new Proveedor()
            {
                id_proveedor = p.ID_PROVEEDOR,
                nombre_proveedor = p.NOMBRE_PROVEEDOR,
                telefono_proveedor = (int) p.TELEFONO_PROVEEDOR,
                rubro_proveedor = p.RUBRO_PROVEEDOR,
            }).ToList();

        }
    }
}
