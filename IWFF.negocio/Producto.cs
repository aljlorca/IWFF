using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWFF.DALC;

namespace IWFF.negocio
{
    public class Producto
    {
        public decimal id_producto { get; set; }
        public String nombre_producto { get; set; }
        public String descripcion_producto { get; set; }
        public decimal precio_prodcuto { get; set; }
        public DateTime fecha_vencimiento_producto { get; set; }
        public decimal stock_producto { get; set; }
        public decimal stock_critico_producto { get; set; }
        public decimal id_proveedor { get; set; }

        //Conexion a BD por DAO
        FermeEntities db = new FermeEntities();
        
        
        //Listado de Productos
        public List<Producto> ReadAll()
        {
            return this.db.PRODUCTO.Select(p => new Producto() {

                id_producto = p.ID_PRODUCTO,
                nombre_producto = p.NOMBRE_PRODUCTO,
                descripcion_producto = p.DESCRIPCION_PRODUCTO,
                precio_prodcuto = p.PRECIO_PRODUCTO,
                fecha_vencimiento_producto = (DateTime)p.FECHA_VENCIMIENTO,
                stock_producto = p.STOCK_PRODUCTO,
                stock_critico_producto = (decimal) p.STOCK_CRITICO_PRODUCTO,
                id_proveedor = p.PROVEEDOR_ID_PROVEEDOR

            }).ToList();
        }

        
    }
}
