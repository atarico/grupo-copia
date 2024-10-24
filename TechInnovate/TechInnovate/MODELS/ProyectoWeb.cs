using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechInnovate.MODELS
{
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
}
