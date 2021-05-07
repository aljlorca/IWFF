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
        public Persona persona { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //listado
        public List<Cliente> ReadAll()
        {
            return this.db.CLIENTE.Select(c => new Cliente()
            {
                rut_persona = c.RUT_PERSONA,
                persona = new Persona() { 
                    
                    rut_persona = c.RUT_PERSONA,
                    nombre_persona = c.PERSONA.NOMBRE_PERSONA,
                    correo_persona = c.PERSONA.CONTRASENA_PERSONA,
                    telefono_persona = c.PERSONA.TELEFONO_PERSONA,
                    contrasena_persona = c.PERSONA.CONTRASENA_PERSONA

                }
            }
            ).ToList();
        }


    }
}
