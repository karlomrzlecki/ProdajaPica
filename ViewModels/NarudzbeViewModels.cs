using System.Collections.Generic;
using ProdajaPica.Models;
using ProdajaPica.ViewModels;

namespace ProdajaPica.ViewModels
{
    public class NarudzbeViewModels
    {
        public IEnumerable<Narudzba> Narudzba { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}