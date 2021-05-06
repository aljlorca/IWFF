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
        public decimal id_cargo { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //Listado
        public List<Empleado> ReadAll() {

            return this.db.EMPLEADO.Select(e => new Empleado()
            {
                id_empleado = e.ID_EMPLEADO,
                rut_empleado = e.RUT_PERSONA,      
                id_cargo = e.CARGO_ID_CARGO,

            }).ToList();


        }




    }
}
