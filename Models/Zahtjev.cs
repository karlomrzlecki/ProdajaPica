using System;
using System.Collections.Generic;

namespace ProdajaPica.Models
{
    public partial class Zahtjev
    {
        public int Id { get; set; }
        public DateTime? Datum { get; set; }
        public string Status { get; set; }
        public int? HladnjakId { get; set; }
        public int? KupacId { get; set; }
        public int? ProdajniPredstavnik { get; set; }
        public int? Supevizor { get; set; }

        public virtual Hladnjak Hladnjak { get; set; }
        public virtual Kupac Kupac { get; set; }
        public virtual Zaposlenik ProdajniPredstavnikNavigation { get; set; }
        public virtual Zaposlenik SupevizorNavigation { get; set; }
    }
}
