using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVenta.Forms
{
    public class Compra
    {
        public int CodigoCompra { get; set; }
        public Producto Producto { get; set; }
        public int CantidadComprada { get; set; }
    }
}
