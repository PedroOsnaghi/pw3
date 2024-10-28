using System;
using System.Collections.Generic;

namespace ModeloParcial.Datos.EF
{
    public partial class Escuderium
    {
        public Escuderium()
        {
            Pilotos = new HashSet<Piloto>();
        }

        public int IdEscuderia { get; set; }
        public string NombreEscuderia { get; set; } = null!;

        public virtual ICollection<Piloto> Pilotos { get; set; }
    }
}
