using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVenta.Forms
{
    public class Venta
    {
        public int CodigoVenta { get; set; }
        public DateTime FechaCompra { get; set; }
        public Producto Producto { get; set; }
    }
}
