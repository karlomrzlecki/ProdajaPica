using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProdajaPica.Models;
using ProdajaPica.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ProdajaPica.Controllers
{
    public class NarudzbaController : Controller
    {
        private readonly IS2022Context ctx;

        private readonly AppSettings appSettings;

        public NarudzbaController(IS2022Context ctx, IOptionsSnapshot<AppSettings> optionsSnapshot)
        {
            this.ctx = ctx;
            appSettings = optionsSnapshot.Value;
        }

        [HttpGet]
        public IActionResult Create()
        {
            PrepareDropDownLists();
            return View();
        }

        private void PrepareDropDownLists()
        {
            var kupci = ctx.Kupac.OrderBy(o => o.NazivObjekta).Select(o => new { o.NazivObjekta, o.Id }).ToList();

            ViewBag.Kupci = new SelectList(kupci, nameof(Kupac.Id), "NazivObjekta");

            List<string> status = new List<string>
            { "dostavljen", "cekanje_isporuke", "u_obradi" };
            ViewBag.Status = new SelectList(status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Narudzba narudzba)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idLast = ctx.Narudzba.OrderBy(p => p.Id).LastOrDefault();
                    narudzba.Id = idLast.Id + 1;
                    ctx.Add(narudzba);
                    ctx.SaveChanges();
                    TempData[Constants.Message] = $"Narudzba {narudzba.Id} uspješno dodana.";
                    TempData[Constants.ErrorOccurred] = false;

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.CompleteExceptionMessage());
                    return View(narudzba);
                }
            }
            else
            {
                return View(narudzba);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id, int page = 1, int position = 1, int sort = 1, bool ascending = true, string viewName = nameof(Edit))
        {
            PrepareDropDownLists();
            return Show(id, position, page, sort, ascending, viewName = nameof(Edit));
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, int page = 1, int sort = 1, bool ascending = true)
        {
            try
            {
                var narudzba = await ctx.Narudzba.FindAsync(id);
                if (narudzba == null)
                {
                    return NotFound($"Ne postoji narudzba s id {id}");
                }

                ViewBag.Page = page;
                ViewBag.Sort = sort;
                ViewBag.Ascending = ascending;
                bool ok = await TryUpdateModelAsync<Narudzba>(narudzba, "", n => n.Status, n => n.Datum, n => n.Napomena, n => n.Iznos, n => n.KupacId);
                if (ok)
                {
                    try
                    {
                        await ctx.SaveChangesAsync();

                        var customers = ctx.Database.ExecuteSqlRaw(@"UPDATE narudzba SET iznos = 
                            (SELECT SUM(proizvod.kolicina*proizvod.cijena) 
                                FROM narudzba
                                    JOIN stavka ON (narudzba.id = stavka.narudzbaId)
                                    JOIN proizvod ON (stavka.proivodId = proizvod.id)
                                WHERE narudzbaId = {0}
                                GROUP BY narudzbaId)
                            WHERE id = {0}", narudzba.Id);

                        TempData[Constants.Message] = $"Narudzba {narudzba.Id} uspješno ažurirana.";
                        TempData[Constants.ErrorOccurred] = false;
                        return RedirectToAction(nameof(Show), new { id, page, sort, ascending });
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError(string.Empty, e.CompleteExceptionMessage());
                        return View(narudzba);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Podatke o narudzbi nije moguće povezati");
                    return View(narudzba);
                }
            }
            catch (Exception e)
            {
                TempData[Constants.Message] = e.CompleteExceptionMessage();
                TempData[Constants.ErrorOccurred] = true;
                return RedirectToAction(nameof(Edit), new { id, page, sort, ascending });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id, int page = 1, int sort = 1, bool ascending = true)
        {
            var narudzba = ctx.Narudzba.Find(Id);
            if (narudzba == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    ctx.Remove(narudzba);
                    ctx.SaveChanges();
                    TempData[Constants.Message] = $"Narudzba {narudzba.Id} uspješno obrisana.";
                    TempData[Constants.ErrorOccurred] = false;
                }
                catch (Exception e)
                {
                    TempData[Constants.Message] = $"Pogreška pri brisanju narudzbe: " + e.CompleteExceptionMessage();
                    TempData[Constants.ErrorOccurred] = true;
                }
                return RedirectToAction(nameof(Index), new { page, sort, ascending });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProizvod(Proizvod proizvod, int NarudzbaId, string Naziv, double Cijena, int Kolicina, int page = 1, int sort = 1, bool ascending = true, int position = 1)
        {
            try
            {
                var idLast = ctx.Proizvod.OrderBy(p => p.Id).LastOrDefault();
                proizvod.Id = idLast.Id + 1;
                ctx.Add(proizvod);
                ctx.SaveChanges();
                Proizvod proizvodID = ctx.Proizvod.Where(p => p.Naziv == proizvod.Naziv && p.Cijena == proizvod.Cijena && p.Kolicina == p.Kolicina).FirstOrDefault();
                Stavka stavka = new Stavka();
                var idLastS = ctx.Stavka.OrderBy(s => s.Id).LastOrDefault();
                stavka.Id = idLastS.Id + 1;
                stavka.NarudzbaId = NarudzbaId;
                stavka.ProivodId = proizvodID.Id;
                ctx.Add(stavka);
                ctx.SaveChanges();
                TempData[Constants.Message] = $"Proizvod {proizvod.Naziv} uspješno dodan.";
                TempData[Constants.ErrorOccurred] = false;
            }
            catch (Exception e)
            {
                TempData[Constants.Message] = $"Pogreška pri dodavanju proizvoda: " + e.CompleteExceptionMessage();
                TempData[Constants.ErrorOccurred] = true;
            }
            int id = NarudzbaId;
            return RedirectToAction(nameof(Edit), new { id, position, page, sort, ascending });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProizvod(int Id, int NarudzbaId, int page = 1, int sort = 1, bool ascending = true, int position = 1)
        {
            var proizvod = ctx.Proizvod.Find(Id);
            var stavka = ctx.Stavka.Where(s => s.ProivodId == Id && s.NarudzbaId == NarudzbaId).FirstOrDefault();
            if (proizvod == null || stavka == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    ctx.Remove(stavka);
                    string naziv = proizvod.Naziv;
                    ctx.Remove(proizvod);
                    ctx.SaveChanges();
                    TempData[Constants.Message] = $"Proizvod {naziv} uspješno obrisana.";
                    TempData[Constants.ErrorOccurred] = false;
                }
                catch (Exception e)
                {
                    TempData[Constants.Message] = $"Pogreška pri brisanju proizvoda: " + e.CompleteExceptionMessage();
                    TempData[Constants.ErrorOccurred] = true;
                }
                int id = NarudzbaId;
                return RedirectToAction(nameof(Edit), new { id, position, page, sort, ascending });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProizvod(int Id, int NarudzbaId, string Naziv, double Cijena, int Kolicina, int page = 1, int sort = 1, bool ascending = true, int position = 1)
        {
            int id = NarudzbaId;
            try
            {
                var proizvod = await ctx.Proizvod.FindAsync(Id);
                if (proizvod == null)
                {
                    return NotFound($"Ne postoji proizvod s id {Id}");
                }

                proizvod.Naziv = Naziv;
                proizvod.Cijena = Cijena;
                proizvod.Kolicina = Kolicina;
                bool ok = await TryUpdateModelAsync(proizvod);
                if (ok)
                {
                    try
                    {
                        await ctx.SaveChangesAsync();
                        TempData[Constants.Message] = $"Proizvod {proizvod.Naziv} uspješno ažuriran.";
                        TempData[Constants.ErrorOccurred] = false;
                        return RedirectToAction(nameof(Edit), new { id, position, page, sort, ascending });
                    }
                    catch (Exception e)
                    {
                        TempData[Constants.Message] = $"Pogreška pri ažuriranju proizvoda: " + e.CompleteExceptionMessage();
                        TempData[Constants.ErrorOccurred] = true;
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Podatke o proizvodu nije moguće povezati");
                    TempData[Constants.ErrorOccurred] = true;
                }
            }
            catch (Exception e)
            {
                TempData[Constants.Message] = $"Pogreška pri ažuriranju proizvoda: " + e.CompleteExceptionMessage();
                TempData[Constants.ErrorOccurred] = true;
            }
            return RedirectToAction(nameof(Edit), new { id, position, page, sort, ascending });
        }

        public IActionResult Show(int id, int position, int page = 1, int sort = 1, bool ascending = true, string viewName = nameof(Show))
        {
            ViewBag.Page = page;
            ViewBag.Sort = sort;
            ViewBag.Ascending = ascending;
            ViewBag.Position = position;

            var narudzba = ctx.Narudzba
                .Where(n => n.Id == id)
                .Select(n => new NarudzbaViewModel
                {
                    Id = n.Id,
                    Status = n.Status,
                    Datum = n.Datum,
                    Napomena = n.Napomena,
                    Iznos = n.Iznos,
                    KupacId = n.KupacId
                })
                .FirstOrDefault();
            if (narudzba == null)
            {
                return NotFound($"Narudzba {id} ne postoji");
            }
            else
            {
                SetPreviousAndNext(position, sort, ascending);
                var osobe = ctx.Kupac.ToList();
                narudzba.Kupac = osobe.Where(os => os.Id == narudzba.KupacId).FirstOrDefault();

                var proizvod = ctx.Proizvod.ToList();
                var stavka = ctx.Stavka
                    .Where(s => s.NarudzbaId == narudzba.Id)
                    .ToList();

                List<Proizvod> proizvodList = new List<Proizvod>();
                foreach (var s in stavka)
                {
                    proizvodList.Add(ctx.Proizvod.Where(m => m.Id == s.ProivodId).FirstOrDefault());
                }
                narudzba.Proizvod = proizvodList;

                return View(viewName, narudzba);
            }
        }

        public IActionResult Index(int page = 1, int sort = 1, bool ascending = true)
        {
            int pagesize = appSettings.PageSize;
            var query = ctx.Narudzba.AsNoTracking();

            int count = query.Count();

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                Sort = sort,
                Ascending = ascending,
                ItemsPerPage = pagesize,
                TotalItems = count
            };

            if (page > pagingInfo.TotalPages)
            {
                return RedirectToAction(nameof(Index), new { page = pagingInfo.TotalPages, sort, ascending });
            }

            query = ApplySort(sort, ascending, query);

            var narudzbe = query.Skip((page - 1) * pagesize).Take(pagesize).ToList();

            for (int i = 0; i < narudzbe.Count; i++)
            {
                narudzbe[i].Position = (page - 1) * pagesize + i;
            }

            var kupac = ctx.Kupac.ToList();
            narudzbe.ForEach(k => k.Kupac = kupac.Where(os => os.Id == k.KupacId).FirstOrDefault());

            foreach (Narudzba narudzba in narudzbe)
            {
                var stavka = ctx.Stavka
                    .Where(s => s.NarudzbaId == narudzba.Id)
                    .ToList();

                List<Proizvod> proizvodList = new List<Proizvod>();
                foreach (var s in stavka)
                {
                    proizvodList.Add(ctx.Proizvod.Where(m => m.Id == s.ProivodId).FirstOrDefault());
                }
                var proizvodString = "";
                foreach (var proizvod in proizvodList)
                {
                    proizvodString = proizvodString + proizvod.Naziv + "\n";
                }
                narudzba.Proizvod = proizvodString;


            }

            var model = new NarudzbeViewModels
            {
                Narudzba = narudzbe,
                PagingInfo = pagingInfo
            };
            return View(model);
        }

        private static IQueryable<Narudzba> ApplySort(int sort, bool ascending, IQueryable<Narudzba> query)
        {
            System.Linq.Expressions.Expression<Func<Narudzba, object>> orderSelector = null;
            switch (sort)
            {
                case 1:
                    orderSelector = o => o.Id;
                    break;
                case 2:
                    orderSelector = o => o.Status;
                    break;
                case 3:
                    orderSelector = o => o.Datum;
                    break;
                case 4:
                    orderSelector = o => o.Napomena;
                    break;
                case 5:
                    orderSelector = o => o.Iznos;
                    break;
                case 6:
                    orderSelector = o => o.Kupac.NazivObjekta;
                    break;
            }
            if (orderSelector != null)
            {
                query = ascending ?
                       query.OrderBy(orderSelector) :
                       query.OrderByDescending(orderSelector);
            }

            return query;
        }

        private void SetPreviousAndNext(int position, int sort, bool ascending)
        {
            var query = ctx.Narudzba.AsQueryable();

            query = ApplySort(sort, ascending, query);
            if (position > 0)
            {
                ViewBag.Previous = query.Skip(position - 1).Select(d => d.Id).First();
            }
            if (position < query.Count() - 1)
            {
                ViewBag.Next = query.Skip(position + 1).Select(d => d.Id).First();
            }
        }
    }
}