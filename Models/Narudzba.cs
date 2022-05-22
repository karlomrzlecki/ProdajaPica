using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProdajaPica.Models
{
    public partial class Narudzba
    {
        public int Id { get; set; }
        public int? KupacId { get; set; }
        public string Status { get; set; }
        public DateTime? Datum { get; set; }
        public string Napomena { get; set; }
        public double? Iznos { get; set; }
        [NotMapped]
        public string Proizvod { get; set; }
        [NotMapped]
        public int Position { get; set; }
        public virtual Kupac Kupac { get; set; }
        [NotMapped]
        public virtual ICollection<Stavka> Stavka { get; set; }
    }
}
