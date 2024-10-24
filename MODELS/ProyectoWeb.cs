using System;

public class ProyectoWeb : Proyecto
{
    public string Tecnologia { get; set; }

    public override double CalcularDuracionEstimada()
    {
        return Desarrolladores * 10;
    }

    public override string ToString()
    {
        return base.ToString() + $" - Tecnología: {Tecnologia}";
    }
}