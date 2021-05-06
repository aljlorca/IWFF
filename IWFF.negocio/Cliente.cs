using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Cliente
    {
        public decimal rut_persona { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //listado
        public List<Cliente> ReadAll()
        {
            return this.db.CLIENTE.Select(c => new Cliente()
            {
                rut_persona = c.RUT_PERSONA
            }
            ).ToList();
        }


    }
}
