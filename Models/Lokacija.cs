using System;
using System.Collections.Generic;

namespace ProdajaPica.Models
{
    public partial class Lokacija
    {
        public Lokacija()
        {
            Kupac = new HashSet<Kupac>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Lokacija1 { get; set; }
        public int? PodregijaId { get; set; }

        public virtual Podregija Podregija { get; set; }
        public virtual ICollection<Kupac> Kupac { get; set; }
    }
}
