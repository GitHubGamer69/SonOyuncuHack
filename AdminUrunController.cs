using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tema_Giydirme.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Tema_Giydirme.Controllers
{
    public class AdminUrunController : Controller
    {
        public IActionResult Index()
        {
			var db = new EntityDbContext();
			var liste = db.Urunler.ToList();

			return View(liste);
        }

        public IActionResult EkleGuncelle(int? Id)
        {
            EntityDbContext context = new EntityDbContext();
			var urunler = context.Kategoriler;
			ViewBag.urunler = urunler.Select(i => new SelectListItem { Text = i.Ad, Value = i.Id.ToString() }).ToList();
			if (Id != null && Id > 0)
            {
                var model = context.Urunler.FirstOrDefault(k => k.Id == Id);
                return View(model);
            }
            else
            {
                Urun urun = new Urun();
                return View(urun);
            }
        }

        [HttpPost]
        public IActionResult EkleGuncelle(Urun model, IFormFile? fotograf)
        {
            if (ModelState.IsValid)
            {
                var db = new EntityDbContext();
                if (fotograf != null)
                {
                    var yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", fotograf.FileName);
                    fotograf.CopyTo(new FileStream(yol, FileMode.Create));
                    model.Gorsel = yol;
				}
                if (model.Id > 0)
                {
                    db.Urunler.Update(model);
                    db.SaveChanges();
                    ViewBag.sonuc = "İşlem Başarıyla Güncellendi";
                }
                else
                {
                    db.Urunler.Add(model);
                    db.SaveChanges();
                    ViewBag.sonuc = "İşlem Başarıyla Eklendi";
                }
            }

            return View(model);
        }

        public IActionResult Sil(int id)
        {
            var db = new EntityDbContext();
            var model = db.Urunler.First(x => x.Id == id);
            if (model != null)
            {
                db.Urunler.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
