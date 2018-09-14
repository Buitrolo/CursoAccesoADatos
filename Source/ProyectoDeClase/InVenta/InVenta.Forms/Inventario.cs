using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVenta.Forms
{
    public class Inventario
    {
        public List<Producto> Productos { get; private set; }
        public List<Venta> Ventas { get; private set; }
        public List<Compra> Compras { get; private set; }
        public List<Existencia> Existencias { get; private set; }

        public void RegistrarProducto(Producto producto)
        {
            //Registrar los datos en el archivo
        }

        public void RegistrarCompra(Compra compra)
        {
            //Registrar los datos en el archivo
        }

        public void RegistrarVenta(Venta venta)
        {
            //Registrar los datos en el archivo
        }

    }
}
