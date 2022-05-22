using System;
using System.Collections.Generic;

namespace ProdajaPica.Models
{
    public partial class Zaposlenik
    {
        public Zaposlenik()
        {
            Anketa = new HashSet<Anketa>();
            InverseSupervizor = new HashSet<Zaposlenik>();
            Ruta = new HashSet<Ruta>();
            ZahtjevProdajniPredstavnikNavigation = new HashSet<Zahtjev>();
            ZahtjevSupevizorNavigation = new HashSet<Zahtjev>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public int? SupervizorId { get; set; }
        public string Uloga { get; set; }
        public int? RegijaId { get; set; }
        public int? PodregijaId { get; set; }

        public virtual Podregija Podregija { get; set; }
        public virtual Regija Regija { get; set; }
        public virtual Zaposlenik Supervizor { get; set; }
        public virtual ICollection<Anketa> Anketa { get; set; }
        public virtual ICollection<Zaposlenik> InverseSupervizor { get; set; }
        public virtual ICollection<Ruta> Ruta { get; set; }
        public virtual ICollection<Zahtjev> ZahtjevProdajniPredstavnikNavigation { get; set; }
        public virtual ICollection<Zahtjev> ZahtjevSupevizorNavigation { get; set; }
    }
}
