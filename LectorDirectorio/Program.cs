// See https://aka.ms/new-console-template for more information
using System;
Console.Clear();
Console.WriteLine("\n\tLector de Directorio\n");
Console.Write("\tIngrese el nombre del directorio: ");
string? directorio = Console.ReadLine();
while (string.IsNullOrEmpty(directorio) || System.IO.Directory.Exists(directorio) == false)
{
    if (string.IsNullOrEmpty(directorio) || System.IO.Directory.Exists(directorio) == false)
    {
        Console.WriteLine("\tEl nombre del directorio no puede estar vacío. Intente de nuevo.");
        Console.Write("\n\tIngrese el nombre del directorio: ");
        directorio = Console.ReadLine();

    }
}
Console.WriteLine($"\n\tContenido del directorio: {directorio} \n");
string?[] listaDirectorios = System.IO.Directory.GetDirectories(directorio);
foreach (string? dir in listaDirectorios)
{
    Console.WriteLine($"\t> {dir}");
}
string[] nombresArchivos = System.IO.Directory.GetFiles(directorio);
FileInfo[] listaArchivos = new FileInfo[nombresArchivos.Length];

Console.WriteLine("\n\tArchivos:\n");
for (int i = 0; i < nombresArchivos.Length; i++)
{
    listaArchivos[i] = new FileInfo(nombresArchivos[i]);
    Console.WriteLine($"\t> {listaArchivos[i].Name} - {listaArchivos[i].Length} KB ");
}


FileInfo reporte = new(directorio + "/reporte_archivos.csv");
using (StreamWriter sw = File.CreateText(reporte.FullName))
{
    sw.WriteLine($"Nombre del archivo: {reporte.Name}");
    sw.WriteLine($"Tamaño del archivo:" + reporte.Length + " bytes");
    sw.WriteLine($"Fecha de creación: {reporte.LastWriteTime}");
}

Console.WriteLine("\nFin de la lectura...\n");
