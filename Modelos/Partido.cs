using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Partido
    {
        public int IdPartido { get; set; }

        public string? PartidoDescripcion { get; set; }

        public Equipo? EquipoLocal { get; set; } 

        public Equipo? EquipoRival { get; set; }
    }
}
