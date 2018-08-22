using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_WindowsForms
{
    public class Estudiante
    {
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public override string ToString()
        {
            return $"{Codigo};{Nombres};{Apellidos}";
        }
    }
}
