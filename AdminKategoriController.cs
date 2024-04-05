using Microsoft.AspNetCore.Mvc;
using Tema_Giydirme.Models;

namespace Tema_Giydirme.Controllers
{
    public class AdminKategoriController : Controller
    {
        public IActionResult Index()
        {
			var db = new EntityDbContext();
			var liste = db.Kategoriler.ToList();

			return View(liste);
        }

		public IActionResult EkleGuncelle(int? Id)
		{
			EntityDbContext context = new EntityDbContext();
			if (Id != null && Id > 0)
			{
				var model = context.Kategoriler.FirstOrDefault(k => k.Id == Id);
				return View(model);
			}
			else 
			{
				Kategori kategori = new Kategori();
				return View(kategori); 
			}
		}

		[HttpPost]
		public IActionResult EkleGuncelle(Kategori model)
		{
			var db = new EntityDbContext();
			if (model.Id > 0)
			{
				db.Kategoriler.Update(model);
				db.SaveChanges();
				ViewBag.sonuc = "İşlem Başarıyla Güncellendi";
			}
			else
			{
				db.Kategoriler.Add(model);
				db.SaveChanges();
				ViewBag.sonuc = "İşlem Başarıyla Eklendi";
			}

			return View(model);
		}

		public IActionResult Sil(int id)
		{
			var db = new EntityDbContext();
			var model = db.Kategoriler.First(x => x.Id == id);
			if (model != null)
			{
				db.Kategoriler.Remove(model);
				db.SaveChanges();
			}
			return RedirectToAction("Index");
		}
	}
}
