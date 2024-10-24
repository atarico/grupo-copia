using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechInnovate.MODELS
{
    public class ProyectoMovil : Proyecto
    {
        public List<string> Plataformas { get; set; } = new List<string>();

        public override double CalcularDuracionEstimada()
        {
            return Desarrolladores * 15;
        }

        public override string ToString()
        {
            return base.ToString() + $" - Plataformas: {string.Join(", ", Plataformas)}";
        }
    }
}
