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
        public decimal id_empleado { get; set; }
        public decimal rut_empleado { get; set; }
        public Persona persona { get; set; }
        public decimal id_cargo { get; set; }
        public Cargo cargo { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //Listado
        public List<Empleado> ReadAll() {

            return this.db.EMPLEADO.Select(e => new Empleado()
            {
                id_empleado = e.ID_EMPLEADO,
                rut_empleado = e.RUT_PERSONA,      
                persona = new Persona()
                {
                    rut_persona = e.PERSONA.RUT_PERSONA,
                    nombre_persona = e.PERSONA.NOMBRE_PERSONA,
                    contrasena_persona = e.PERSONA.CONTRASENA_PERSONA,
                    correo_persona = e.PERSONA.CORREO_PERSONA,
                    telefono_persona = e.PERSONA.TELEFONO_PERSONA
                },
                id_cargo = e.CARGO_ID_CARGO,
                cargo = new Cargo()
                {
                    id_cargo = e.CARGO.ID_CARGO,
                    nombre_cargo = e.CARGO.NOMBRE_CARGO
                }

            }).ToList();


        }




    }
}
