using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Empleado 
    {
        public Persona persona { get; set; }
        public decimal id_empleado { get; set; }
        public String rut_empleado { get; set; }
        public decimal cargo_empleado { get; set; }
        public String nombre_empleado { get; set; }
        public String apellido_empleado { get; set; }

        //DAO
        FermEntities db = new FermEntities();

        //Listado
        public List<Empleado> ReadAll() {

            return this.db.EMPLEADO.Select(e => new Empleado()
            {
                persona = new Persona() { 
                    
                    rut_persona = e.PERSONA.RUT,
                    nombre_persona = e.PERSONA.NOMBRE,
                    correo_persona = e.PERSONA.CORREO,
                    telefono_persona = (decimal) e.PERSONA.TELEFONO,
                    direccion_persona = e.PERSONA.DIRECCION,
                    id_comuna = e.PERSONA.ID_COMUNA,

                },
                id_empleado = e.ID_EMPLEADO,
                rut_empleado = e.PERSONA_RUT,
                nombre_empleado = e.NOMBRE,
                apellido_empleado = e.APELLIDO,
                cargo_empleado = (decimal) e.ID_CARGO

                
            }).ToList();


        }




    }
}
