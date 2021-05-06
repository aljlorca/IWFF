using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Region
    {
        public decimal id_region { get; set; }
        public String nombre_region { get; set; }

        //DAO  
        FermeEntities db = new FermeEntities();

        //Listado
        public List<Region> ReadAll()
        {
            return this.db.REGION.Select(r => new Region(){ 
                
                id_region = r.ID_REGION,
                nombre_region = r.NOMBRE_REGION,

            
            }).ToList();
        }

    }
}
