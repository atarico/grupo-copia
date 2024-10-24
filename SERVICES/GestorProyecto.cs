using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GestorProyectos
{
	private List<Proyecto> proyectos = new List<Proyecto>();
	private const string archivoProyectos = "proyectos.txt";

	public void AgregarProyecto(Proyecto proyecto)
	{
		proyectos.Add(proyecto);
	}

	public void MostrarProyectos()
	{
		if (proyectos.Count == 0)
		{
			Console.WriteLine("No hay proyectos registrados.");
			return;
		}
		foreach (var proyecto in proyectos)
		{
			Console.WriteLine(proyecto);
		}
	}

	public void ModificarProyecto(string nombre)
	{
		var proyecto = proyectos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
		if (proyecto == null)
		{
			Console.WriteLine("Proyecto no encontrado.");
			return;
		}
		Console.WriteLine("Ingrese el nuevo estado del proyecto:");
		proyecto.Estado = (EstadoProyecto)Enum.Parse(typeof(EstadoProyecto), Console.ReadLine());
		Console.WriteLine("Ingrese la nueva cantidad de desarrolladores:");
		proyecto.Desarrolladores = int.Parse(Console.ReadLine());
		Console.WriteLine("Ingrese la nueva fecha de inicio (yyyy-mm-dd):");
		proyecto.FechaInicio = DateTime.Parse(Console.ReadLine());
		if (proyecto is ProyectoWeb webProyecto)
		{
			Console.WriteLine("Ingrese la nueva tecnología:");
			webProyecto.Tecnologia = Console.ReadLine();
		}
		else if (proyecto is ProyectoMovil movilProyecto)
		{
			Console.WriteLine("Ingrese las nuevas plataformas (separadas por comas):");
			movilProyecto.Plataformas = Console.ReadLine().Split(',').Select(p => p.Trim()).ToList();
		}
	}

	public void EliminarProyecto(string nombre)
	{
		var proyecto = proyectos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
		if (proyecto != null)
		{
			proyectos.Remove(proyecto);
			Console.WriteLine("Proyecto eliminado.");
		}
		else
		{
			Console.WriteLine("Proyecto no encontrado.");
		}
	}

	public void GuardarProyectos()
	{
		using (StreamWriter writer = new StreamWriter(archivoProyectos))
		{
			foreach (var proyecto in proyectos)
			{
				writer.WriteLine(proyecto.ToString());
			}
		}
		Console.WriteLine("Proyectos guardados.");
	}

	public void CargarProyectos()
	{
		if (File.Exists(archivoProyectos))
		{
			string[] lineas = File.ReadAllLines(archivoProyectos);
			foreach (var linea in lineas)
			{
				Console.WriteLine($"Cargar proyecto: {linea}");
				// Lógica para crear objetos de proyecto a partir de la línea
			}
		}
	}
}