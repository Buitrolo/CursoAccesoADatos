using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02_WindowsForms
{
    public class ControladorDeArchivo
    {
        private const string ARCHIVO = @"D:\archivoestudiantes.txt";

        public static bool Guardar(Estudiante estudiante)
        {
            FileInfo file = new FileInfo(ARCHIVO);

            if (!file.Exists)
            {
                using (StreamWriter writer = file.CreateText())
                {
                    writer.WriteLine(estudiante.ToString());
                    return true;
                }
            }
            else
            {
                using (StreamWriter writer = file.AppendText())
                {
                    writer.WriteLine(estudiante.ToString());
                    return true;
                }
            }
        }

        public static List<Estudiante> Consultar()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            FileInfo file = new FileInfo(ARCHIVO);

            if (file.Exists)
            {
                using (FileStream fileStream = file.OpenRead())
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string data = "";

                        while (string.IsNullOrEmpty(data = reader.ReadLine()) == false)
                        {
                            //codigo;nombres;apellidos
                            string[] datos = data.Split(';');
                            Estudiante estudiante = new Estudiante
                            {
                                Codigo=datos[0],
                                Nombres=datos[1],
                                Apellidos=datos[2]
                            };
                            estudiantes.Add(estudiante);
                        }
                    }
                }
            }

            return estudiantes;
        }
    }
}
