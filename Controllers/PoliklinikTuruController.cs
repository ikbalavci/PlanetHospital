using Microsoft.AspNetCore.Mvc;
using udemyWeb1.Haberlesme;
using udemyWeb1.Models;

namespace udemyWeb1.Controllers
{
    public class PoliklinikTuruController : Controller
    {
        private readonly UygulamaDbContext _uygulamaDbContext;

        public PoliklinikTuruController(UygulamaDbContext context)
        {
            _uygulamaDbContext = context;
        }
        public IActionResult Index()
        {
            List<PoliklinikTuru> objPoliklinikTuru = _uygulamaDbContext.PoliklinikTurleri.ToList();
            return View(objPoliklinikTuru);
        }
        public IActionResult Ekle() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(PoliklinikTuru poliklinikTuru)
        {
            if(ModelState.IsValid) { 
            _uygulamaDbContext.PoliklinikTurleri.Add(poliklinikTuru);
            _uygulamaDbContext.SaveChanges();
            TempData["basarili"] = "Yeni Poliklinik Türü başarıyla oluşturuldu";
            return RedirectToAction("Index","PoliklinikTuru");
            }
            return View();
        }

        public IActionResult Guncelle(int? id)
        {
            if(id== null || id==0)
            {
                return NotFound();
            }
            PoliklinikTuru? poliklinikTuruVT = _uygulamaDbContext.PoliklinikTurleri.Find(id);
            if(poliklinikTuruVT == null) 
            { 
                return NotFound(); 
            }
            return View(poliklinikTuruVT);
        }

        [HttpPost]
        public IActionResult Guncelle(PoliklinikTuru poliklinikTuru)
        {
            if (ModelState.IsValid)
            {
                _uygulamaDbContext.PoliklinikTurleri.Update(poliklinikTuru);
                _uygulamaDbContext.SaveChanges();
                TempData["basarili"] = "Poliklinik Türü başarıyla güncellendi";
                return RedirectToAction("Index", "PoliklinikTuru");
            }
            return View();
        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            PoliklinikTuru? poliklinikTuruVT = _uygulamaDbContext.PoliklinikTurleri.Find(id);
            if (poliklinikTuruVT == null)
            {
                return NotFound();
            }
            return View(poliklinikTuruVT);
        }

        [HttpPost,ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            PoliklinikTuru? poliklinikTuru = _uygulamaDbContext.PoliklinikTurleri.Find(id);
            if(poliklinikTuru == null)
            {
                return NotFound();
            }
            _uygulamaDbContext.PoliklinikTurleri.Remove(poliklinikTuru);
            _uygulamaDbContext.SaveChanges();
            TempData["basarili"] = "Poliklinik Türü başarıyla silindi";
            return RedirectToAction("index", "PoliklinikTuru");
        }
    }
}
