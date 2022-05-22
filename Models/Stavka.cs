using System;
using System.Collections.Generic;

namespace ProdajaPica.Models
{
    public partial class Stavka
    {
        public int Id { get; set; }
        public int? NarudzbaId { get; set; }
        public int? ProivodId { get; set; }
        public int? Kolicina { get; set; }

        public virtual Narudzba Narudzba { get; set; }
        public virtual Proizvod Proivod { get; set; }
    }
}
