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
        public decimal rut_persona { get; set; }
        public String nombre_persona { get; set; }
        public String correo_persona { get; set; }
        public decimal telefono_persona { get; set; }
        public String contrasena_persona { get; set; }
        //DAO
        FermeEntities db = new FermeEntities();
        //Lista
        public List<Persona> ReadAll()
        {
            return this.db.PERSONA.Select(p => new Persona() { 
                rut_persona = p.RUT_PERSONA,
                nombre_persona = p.NOMBRE_PERSONA,
                correo_persona = p.CORREO_PERSONA,
                telefono_persona = (decimal) p.TELEFONO_PERSONA,
                contrasena_persona = p.CONTRASENA_PERSONA

            }
            ).ToList();
        }


    }

}
