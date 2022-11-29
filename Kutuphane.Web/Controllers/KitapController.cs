using Kutuphane.Web.Data;
using Kutuphane.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Web.Controllers
{
    public class KitapController : Controller
    {
        private readonly ApplicationDbContext _db;
        public KitapController(ApplicationDbContext db)
        {
            _db= db;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult GetAll()
        {
            return Json(_db.Kitaplar.Include(k=>k.Kategori).OrderByDescending(o=>o.DateModified).ToList());
        }

        public IActionResult Add(Kitap kitap) {
        
            _db.Kitaplar.Add(kitap);
            _db.SaveChanges();
            return Json(kitap);
        }
        public IActionResult Delete(Guid kitapId)
        {
            Kitap kitap = _db.Kitaplar.Find(kitapId);
            if (kitap != null)
            {
                _db.Kitaplar.Remove(kitap);
                _db.SaveChanges();
            }

            return Json(kitap);

        }
        [HttpPost]
        public IActionResult Update(Kitap kitap)
        {
            Kitap ktp = _db.Kitaplar.Find(kitap.Id);
            ktp.ISBN = kitap.ISBN;
            ktp.Name = kitap.Name;
            ktp.Ozet = kitap.Ozet;
            ktp.KategoriId = kitap.KategoriId;
            ktp.Kategori = _db.Kategoriler.Find(kitap.KategoriId);
            ktp.DateModified = DateTime.Now;
            _db.Kitaplar.Update(ktp);
            _db.SaveChanges();
            return Json(ktp);

        }

    }
}
