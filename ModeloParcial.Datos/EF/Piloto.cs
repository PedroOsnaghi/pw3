using System;
using System.Collections.Generic;

namespace ModeloParcial.Datos.EF
{
    public partial class Piloto
    {
        public int IdPiloto { get; set; }
        public string NombrePiloto { get; set; } = null!;
        public int IdEscuderia { get; set; }
        public bool Eliminado { get; set; }

        public virtual Escuderium IdEscuderiaNavigation { get; set; } = null!;
    }
}
