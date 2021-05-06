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
        public Producto producto { get; set; }

        //DAO
        FermEntities db = new FermEntities();

        //Listado proveedores
        public List<Proveedor> ReadAll()
        {
            return this.db.PROVEEDOR.Select(p => new Proveedor()
            {
                id_proveedor = p.ID_NOM_PROVEEDOR,
                nombre_proveedor = p.NOM_PROVEEDOR,
                telefono_proveedor = (int) p.TELEFONO,
                rubro_proveedor = p.RUBRO,
            }).ToList();

        }
    }
}
