using System;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		GestorProyectos gestor = new GestorProyectos();
		gestor.CargarProyectos();

		while (true)
		{
			Console.WriteLine("\nMenu:");
			Console.WriteLine("1. Agregar Proyecto");
			Console.WriteLine("2. Mostrar Proyectos");
			Console.WriteLine("3. Modificar Proyecto");
			Console.WriteLine("4. Eliminar Proyecto");
			Console.WriteLine("5. Guardar Proyectos");
			Console.WriteLine("6. Salir");
			Console.Write("Seleccione una opción: ");
			var opcion = Console.ReadLine();

			switch (opcion)
			{
				case "1":
					Console.Write("Ingrese el nombre del proyecto: ");
					string nombre = Console.ReadLine();
					Console.Write("Ingrese el tipo de proyecto (Web/Movil): ");
					string tipo = Console.ReadLine();
					Console.Write("Ingrese el estado del proyecto: ");
					var estado = (EstadoProyecto)Enum.Parse(typeof(EstadoProyecto), Console.ReadLine());
					Console.Write("Ingrese la cantidad de desarrolladores: ");
					int desarrolladores = int.Parse(Console.ReadLine());
					Console.Write("Ingrese la fecha de inicio (yyyy-mm-dd): ");
					DateTime fechaInicio = DateTime.Parse(Console.ReadLine());

					if (tipo.Equals("Web", StringComparison.OrdinalIgnoreCase))
					{
						Console.Write("Ingrese la tecnología: ");
						string tecnologia = Console.ReadLine();
						ProyectoWeb nuevoProyectoWeb = new ProyectoWeb
						{
							Nombre = nombre,
							Estado = estado,
							Desarrolladores = desarrolladores,
							FechaInicio = fechaInicio,
							Tecnologia = tecnologia
						};
						gestor.AgregarProyecto(nuevoProyectoWeb);
					}
					else if (tipo.Equals("Movil", StringComparison.OrdinalIgnoreCase))
					{
						Console.Write("Ingrese las plataformas (separadas por comas): ");
						var plataformas = Console.ReadLine().Split(',').Select(p => p.Trim()).ToList();
						ProyectoMovil nuevoProyectoMovil = new ProyectoMovil
						{
							Nombre = nombre,
							Estado = estado,
							Desarrolladores = desarrolladores,
							FechaInicio = fechaInicio,
							Plataformas = plataformas
						};
						gestor.AgregarProyecto(nuevoProyectoMovil);
					}
					break;

				case "2":
					gestor.MostrarProyectos();
					break;

				case "3":
					Console.Write("Ingrese el nombre del proyecto a modificar: ");
					gestor.ModificarProyecto(Console.ReadLine());
					break;

				case "4":
					Console.Write("Ingrese el nombre del proyecto a eliminar: ");
					gestor.EliminarProyecto(Console.ReadLine());
					break;

				case "5":
					gestor.GuardarProyectos();
					break;

				case "6":
					return;

				default:
					Console.WriteLine("Opción no válida.");
					break;
			}
		}
	}
}