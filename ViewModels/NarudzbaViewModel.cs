using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProdajaPica.Models;

namespace ProdajaPica.ViewModels
{
    public class NarudzbaViewModel
    {
        [Display(Name = "Id narudzbe")]
        public int Id { get; set; }

        [Display(Name = "Status narudzbe", Prompt = "Unesite status narudzbe")]
        [Required(ErrorMessage = "Vrsta narudzbe je obavezno polje")]
        public string Status { get; set; }

        [Display(Name = "Datum", Prompt = "Unesite datum")]
        [Required(ErrorMessage = "Datum je obavezno polje")]
        public DateTime? Datum { get; set; }

        [Display(Name = "Napomena", Prompt = "Unesite napomenu")]
        [Required(ErrorMessage = "Napomena je obavezno polje")]
        public string Napomena { get; set; }

        [Display(Name = "Iznos", Prompt = "Unesite Iznos")]
        [Required(ErrorMessage = "Iznos je obavezno polje")]
        public double? Iznos { get; set; }


        [Display(Name = "Id kupca")]
        [Required(ErrorMessage = "Id kupca je obavezno polje")]
        public int? KupacId { get; set; }

        public IEnumerable<Proizvod> Proizvod { get; set; }
        public virtual Kupac Kupac { get; set; }

        public NarudzbaViewModel()
        {
            this.Proizvod = new List<Proizvod>();
        }
    }
}