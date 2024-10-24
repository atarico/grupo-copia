using System;

public abstract class Proyecto
{
    public string Nombre { get; set; }
    public EstadoProyecto Estado { get; set; }
    public int Desarrolladores { get; set; }
    public DateTime FechaInicio { get; set; }

    public abstract double CalcularDuracionEstimada();

    public override string ToString()
    {
        return $"{Nombre} - {Estado} - {Desarrolladores} desarrolladores - Inicio: {FechaInicio.ToShortDateString()} - Duración Estimada: {CalcularDuracionEstimada()} días";
    }
}