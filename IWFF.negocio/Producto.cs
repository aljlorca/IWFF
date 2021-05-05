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
        public decimal id_familia { get; set; }
        public Familia familia_producto { get; set; }
        public decimal id_proveedor { get; set; }
        public String nombre_producto { get; set; }
        public String descripcion_producto { get; set; }
        public decimal precio_compra_producto { get; set; }
        public decimal precio_venta_prodcuto { get; set; }
        public DateTime fecha_vencimiento_producto { get; set; }
        public decimal stock_producto { get; set; }
        public decimal stock_critico_producto { get; set; }


        //Conexion a BD por DAO
        FermEntities db = new FermEntities();
        
        
        //Listado de Productos
        public List<Producto> ReadAll()
        {
            return this.db.PRODUCTO.Select(p => new Producto(){
                id_producto = p.ID_PRODUCTO,
                id_familia = (decimal) p.ID_FAMILIA,
                id_proveedor = (decimal) p.ID_PROVEEDOR,
                familia_producto = new Familia()
                {
                    id_familia = p.FAMILIA.ID_FAMILIA,
                    nombre_familia = p.FAMILIA.NOM_FAMILIA

                },
                nombre_producto = p.NOM_PRODUCTO,
                descripcion_producto = p.DESCRIPCION,
                precio_compra_producto = (decimal) p.PRECIO_COMPRA,
                precio_venta_prodcuto = (decimal) p.PRECIO_VENTA,
                fecha_vencimiento_producto = (DateTime) p.FECHA_VENC,
                stock_producto = (decimal) p.STOCK,
                stock_critico_producto = (decimal) p.STOCK_CRITICO
                
            }).ToList();
        }

        
    }
}
