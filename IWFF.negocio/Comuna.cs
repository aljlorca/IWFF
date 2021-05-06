using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Comuna
    {

        public decimal id_comuna { get; set; }
        public String nombre_comuna { get; set; }
        public decimal id_region { get; set; }

        //DAO
        FermeEntities db = new FermeEntities();

        //
        public List<Comuna> ReadAll()
        {
            return this.db.COMUNA.Select(c => new Comuna(){
            
                id_comuna = c.ID_COMUNA,
                nombre_comuna = c.NOMBRE_COMUNA,
                id_region = c.REGION_ID_REGION
            }).ToList();
        }

    }
}
