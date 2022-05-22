using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProdajaPica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProdajaPica.ViewModels;
using OfficeOpenXml;
using PdfRpt.Core.Contracts;
using PdfRpt.FluentInterface;
using NLog;

namespace ProdajaPica.Controllers
{
    public class ProizvodController : Controller
    {
        private readonly IS2022Context ctx;

        private const string ExcelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        private readonly AppSettings appSettings;

        public ProizvodController(IS2022Context ctx, IOptionsSnapshot<AppSettings> optionsSnapshot)
        {
            this.ctx = ctx;
            appSettings = optionsSnapshot.Value;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idLast = ctx.Proizvod.OrderBy(p => p.Id).LastOrDefault();
                    proizvod.Id = idLast.Id + 1;
                    ctx.Add(proizvod);
                    ctx.SaveChanges();
                    TempData[Constants.Message] = $"Proizvod {proizvod.Naziv} uspješno dodan.";
                    TempData[Constants.ErrorOccurred] = false;

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.CompleteExceptionMessage());
                    return View(proizvod);
                }
            }
            else
            {
                return View(proizvod);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id, int page = 1, int sort = 1, bool ascending = true)
        {
            var proizvod = ctx.Proizvod.AsNoTracking().Where(o => o.Id == id).FirstOrDefault();
            if (proizvod == null)
            {
                return NotFound($"Ne postoji proizvod s id {id}");
            }
            else
            {
                Logger log = LogManager.GetCurrentClassLogger();
                log.Info("GET: " + Request.QueryString.Value);
                ViewBag.Page = page;
                ViewBag.Sort = sort;
                ViewBag.Ascending = ascending;
                return View(proizvod);
            }
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, int page = 1, int sort = 1, bool ascending = true)
        {
            try
            {
                var proizvod = await ctx.Proizvod.FindAsync(id);
                if (proizvod == null)
                {
                    return NotFound($"Ne postoji proizvod s id {id}");
                }

                ViewBag.Page = page;
                ViewBag.Sort = sort;
                ViewBag.Ascending = ascending;
                bool ok = await TryUpdateModelAsync<Proizvod>(proizvod, "", o => o.Naziv, o => o.Cijena, o => o.Kolicina);
                if (ok)
                {
                    try
                    {
                        await ctx.SaveChangesAsync();
                        Logger log = LogManager.GetCurrentClassLogger();
                        log.Info("POST: " + Request.QueryString.Value);
                        TempData[Constants.Message] = $"Proizvod {proizvod.Naziv} uspješno ažuriana.";
                        TempData[Constants.ErrorOccurred] = false;
                        return RedirectToAction(nameof(Index), new { page, sort, ascending });
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError(string.Empty, e.CompleteExceptionMessage());
                        return View(proizvod);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Podatke o mjeri nije moguće povezati");
                    return View(proizvod);
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
            var proizvod = ctx.Proizvod.Find(Id);
            if (proizvod == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    string naziv = proizvod.Naziv;
                    ctx.Remove(proizvod);
                    ctx.SaveChanges();
                    Logger log = LogManager.GetCurrentClassLogger();
                    log.Info("POST: " + Request.QueryString.Value);
                    TempData[Constants.Message] = $"Proizvod {naziv} uspješno obrisana.";
                    TempData[Constants.ErrorOccurred] = false;
                }
                catch (Exception e)
                {
                    TempData[Constants.Message] = $"Pogreška pri brisanju proizvod: " + e.CompleteExceptionMessage();
                    TempData[Constants.ErrorOccurred] = true;
                }
                return RedirectToAction(nameof(Index), new { page, sort, ascending });
            }
        }

        public IActionResult Index(int page = 1, int sort = 1, bool ascending = true)
        {
            int pagesize = appSettings.PageSize;
            var query = ctx.Proizvod.AsNoTracking();

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

            System.Linq.Expressions.Expression<Func<Proizvod, object>> orderSelector = null;
            switch (sort)
            {
                case 1:
                    orderSelector = o => o.Id;
                    break;
                case 2:
                    orderSelector = o => o.Naziv;
                    break;
                case 3:
                    orderSelector = o => o.Cijena;
                    break;
                case 4:
                    orderSelector = o => o.Kolicina;
                    break;
            }

            if (orderSelector != null)
            {
                query = ascending ? query.OrderBy(orderSelector) : query.OrderByDescending(orderSelector);
            }

            var proizvod = query.Skip((page - 1) * pagesize).Take(pagesize).ToList();

            var model = new ProizvodViewModels
            {
                Proizvod = proizvod,
                PagingInfo = pagingInfo
            };

            Logger log = LogManager.GetCurrentClassLogger();
            log.Info("GET: " + Request.QueryString.Value);

            return View(model);
        }
    }
}