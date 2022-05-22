using System;
using System.Collections.Generic;

namespace ProdajaPica.Models
{
    public partial class Ruta
    {
        public int Id { get; set; }
        public int? Dan { get; set; }
        public int? KupacId { get; set; }
        public int? ProdajniPredstavnikId { get; set; }

        public virtual Zaposlenik ProdajniPredstavnik { get; set; }
    }
}
