using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Agenda
    {
        public Agenda() { }

        public int Id { get; set; }

        public DateTime? FechaPartido { get; set; }

        public string? Lugar { get; set; }

        public string? HoraPartido { get; set; }

        public string? Sorteado { get; set; }

        public Partido? Partido { get; set; }
    }
}
