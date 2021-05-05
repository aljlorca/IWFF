using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Familia
    {
        public decimal id_familia { get; set; }
        public String nombre_familia { get; set; }

        //Conexion a BD por DAO
        FermEntities db = new FermEntities();

        //Listado de Familias
        public List<Familia> ReadAll()
        {
            return this.db.FAMILIA.Select(f => new Familia(){
                id_familia = f.ID_FAMILIA,
                nombre_familia = f.NOM_FAMILIA
            }
            ).ToList();
        }
    }
}
