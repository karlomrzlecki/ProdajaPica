using System;
using System.Collections.Generic;

namespace ProdajaPica.Models
{
    public partial class Hladnjak
    {
        public Hladnjak()
        {
            Zahtjev = new HashSet<Zahtjev>();
        }

        public int Id { get; set; }
        public int? Velicina { get; set; }
        public string Napomena { get; set; }
        public string Model { get; set; }
        public int? KupacId { get; set; }

        public virtual Kupac Kupac { get; set; }
        public virtual ICollection<Zahtjev> Zahtjev { get; set; }
    }
}
