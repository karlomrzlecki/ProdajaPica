using System.Collections.Generic;
using ProdajaPica.Models;
using ProdajaPica.ViewModels;

namespace ProdajaPica.ViewModels
{
    public class ProizvodViewModels
    {
        public IEnumerable<Proizvod> Proizvod { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}