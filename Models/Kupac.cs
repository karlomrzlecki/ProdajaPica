using System;
using System.Collections.Generic;

namespace ProdajaPica.Models
{
    public partial class Kupac
    {
        public Kupac()
        {
            Anketa = new HashSet<Anketa>();
            Hladnjak = new HashSet<Hladnjak>();
            Narudzba = new HashSet<Narudzba>();
            Zahtjev = new HashSet<Zahtjev>();
        }

        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string NazivObjekta { get; set; }
        public double? OdobreniDug { get; set; }
        public double? Dug { get; set; }
        public int? LokacijaId { get; set; }

        public virtual Lokacija Lokacija { get; set; }
        public virtual ICollection<Anketa> Anketa { get; set; }
        public virtual ICollection<Hladnjak> Hladnjak { get; set; }
        public virtual ICollection<Narudzba> Narudzba { get; set; }
        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
    }
}
