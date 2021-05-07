using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Direccion
    {
        public decimal id_direccion { get; set; }
        public String direccion { get; set; }
        public decimal id_comuna { get; set; }
        public Comuna comuna { get; set; }
        public decimal id_region { get; set; }
        //DAO
        FermeEntities db = new FermeEntities();
        
        //Listado
        public List<Direccion> ReadAll()
        {
            return this.db.DIRECCIONES.Select(d => new Direccion()
            {
                id_direccion = d.ID_DIRECCION,
                direccion = d.DIRECCION,
                id_comuna = d.COMUNA_ID_COMUNA,
                comuna = new Comuna()
                {
                    id_comuna = d.COMUNA.ID_COMUNA,
                    nombre_comuna = d.COMUNA.NOMBRE_COMUNA
                   
                },
                id_region= d.COMUNA_ID_REGION


            }).ToList();
        }

    }
}
