using Microsoft.AspNetCore.Mvc;
using Tema_Giydirme.Models;

namespace Tema_Giydirme.Controllers
{
    public class AdminIletisimController : Controller
    {
        public IActionResult Index()
        {
			var db = new EntityDbContext();
			var liste = db.Iletisim.ToList();

			return View(liste);
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
