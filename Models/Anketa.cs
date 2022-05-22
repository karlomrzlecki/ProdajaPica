using System;
using System.Collections.Generic;

namespace ProdajaPica.Models
{
    public partial class Anketa
    {
        public int Id { get; set; }
        public DateTime? Datum { get; set; }
        public int? BrojProizvoda { get; set; }
        public int? Vidljivost { get; set; }
        public int? Popunjenost { get; set; }
        public int? Dostupnost { get; set; }
        public double? Ocjena { get; set; }
        public int? ProdajniPredstavnikId { get; set; }
        public int? KupacId { get; set; }

        public virtual Kupac Kupac { get; set; }
        public virtual Zaposlenik ProdajniPredstavnik { get; set; }
    }
}
