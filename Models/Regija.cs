using System;
using System.Collections.Generic;

namespace ProdajaPica.Models
{
    public partial class Regija
    {
        public Regija()
        {
            Podregija = new HashSet<Podregija>();
            Zaposlenik = new HashSet<Zaposlenik>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }

        public virtual ICollection<Podregija> Podregija { get; set; }
        public virtual ICollection<Zaposlenik> Zaposlenik { get; set; }
    }
}
