using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Cargo
    {
        public String id_cargo { get; set; }
        public String nombre_cargo { get; set; }
        public String descripcion_cargo { get; set; }

        //DAO
        FermEntities db = new FermEntities();

        //Listado
        public List<Cargo> ReadAll()
        {
            return this.db.CARGO.Select(c => new Cargo()
            {
                id_cargo = c.ID_CARGO,
                nombre_cargo = c.NOM_CARGO,
                descripcion_cargo = c.DESCRIPCION_CARGO
            }
            ).ToList();
        }
    }
}
