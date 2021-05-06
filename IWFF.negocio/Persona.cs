using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Persona
    {
        public String rut_persona { get; set; }
        public String nombre_persona { get; set; }
        public String correo_persona { get; set; }
        public decimal telefono_persona { get; set; }
        public String direccion_persona { get; set; }

        public String id_comuna { get; set; }

        //DAO
        FermEntities db = new FermEntities();
        //Lista
        public List<Persona> ReadAll()
        {
            return this.db.PERSONA.Select(p => new Persona() { 
                rut_persona = p.RUT,
                nombre_persona = p.NOMBRE,
                correo_persona = p.CORREO,
                telefono_persona = (decimal) p.TELEFONO,
                direccion_persona = p.DIRECCION,
                id_comuna = p.ID_COMUNA
            }
            ).ToList();
        }


    }

}
