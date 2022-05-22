using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProdajaPica.Models
{
    public partial class Proizvod
    {
        public Proizvod()
        {
            Stavka = new HashSet<Stavka>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public double? Cijena { get; set; }
        public int? Kolicina { get; set; }

        public virtual ICollection<Stavka> Stavka { get; set; }
    }
}
