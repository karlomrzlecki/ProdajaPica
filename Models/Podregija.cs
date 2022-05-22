using System;
using System.Collections.Generic;

namespace ProdajaPica.Models
{
    public partial class Podregija
    {
        public Podregija()
        {
            Lokacija = new HashSet<Lokacija>();
            Zaposlenik = new HashSet<Zaposlenik>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public int? RegijaId { get; set; }

        public virtual Regija Regija { get; set; }
        public virtual ICollection<Lokacija> Lokacija { get; set; }
        public virtual ICollection<Zaposlenik> Zaposlenik { get; set; }
    }
}
