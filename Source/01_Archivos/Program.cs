using System;
using System.IO;

namespace _01_Archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demo acceso a archivos.");

            //Discos
            //Obtener el listado de los discos duros
            DriveInfo[] misDiscos = DriveInfo.GetDrives();

            foreach (var disco in misDiscos)
            {
                Console.WriteLine($"Nombre:{disco.Name}");
                Console.WriteLine($"Tipo de disco:{disco.DriveType}");
                //Nos permite saber si el disco está disponible
                if (disco.IsReady)
                {
                    Console.WriteLine($"Espacio total: {disco.TotalSize}");
                    Console.WriteLine($"Espacio libre: {disco.TotalFreeSpace}");
                    Console.WriteLine($"Formato: {disco.DriveFormat}");
                    Console.WriteLine($"Label: {disco.VolumeLabel}");
                }
            }

            int i = 1;
            foreach (var disco in misDiscos)
            {
                Console.WriteLine($"{i}.{disco.Name}");
                i++;
            }
            Console.Write("¿Que disco desea ver?:");
            int indiceDisco = Convert.ToInt32(Console.ReadLine());

            if (indiceDisco >= 0 && indiceDisco < misDiscos.Length)
            {
                MostrarSubdirectorio(misDiscos[indiceDisco - 1]);
            }

            Console.Read();
        }

        private static void MostrarSubdirectorio(DriveInfo driveInfo)
        {
            //Mostrar las subcarpetas del disco
            Console.Clear();
            Console.WriteLine($"Mostrando el disco:{driveInfo.Name}");

            DirectoryInfo root = driveInfo.RootDirectory;

            foreach (var internalDirectory in root.GetDirectories())
            {
                Console.WriteLine($"Nombre: {internalDirectory.Name}");
                Console.WriteLine($"Modificado en:{internalDirectory.LastWriteTime}");
            }

            //Creación de carpetas
            string nuevaRuta = root.Name + "DemoArchivos";
            DirectoryInfo newFolder = new DirectoryInfo(nuevaRuta);
            if (newFolder.Exists)
            {
                newFolder.Delete(recursive: true);
            }

            //Crear la carpeta
            newFolder.Create();

            //Crear el archivo
            string newFileName = newFolder.FullName + "\\" + "Data.txt";
            FileInfo newFile = new FileInfo(newFileName);

            if (newFile.Exists)
            {
                newFile.Delete();
            }
            else
            {
                using (StreamWriter writer = newFile.CreateText())
                {
                    for (int i = 0; i < 20; i++)
                    {
                        writer.WriteLine($"Estudiante {i + 1}");
                    }
                }
            }
        }
    }
}
