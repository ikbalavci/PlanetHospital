using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using udemyWeb1.Haberlesme;
using udemyWeb1.Models;

namespace udemyWeb1.Controllers
{
    public class DoktorController : Controller
    
    {
        private readonly IDoktorRepository _doktorRepository;
        private readonly IPoliklinikTuruRepository _poliklinikTuruRepository;

        public DoktorController(IDoktorRepository doktorRepository, IPoliklinikTuruRepository poliklinikTuruRepository)
        {
            _doktorRepository = doktorRepository;
            _poliklinikTuruRepository = poliklinikTuruRepository;
        }
        public IActionResult Index()
        {
            List<Doktor> objDoktor = _doktorRepository.GetAll().ToList();
            IEnumerable<SelectListItem> PoliklinikTuruList = _poliklinikTuruRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text= k.Ad,
                    Value=k.Id.ToString()
                });

            return View(objDoktor);
        }
        public IActionResult Ekle() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Doktor doktor)
        {
            if(ModelState.IsValid) {
                _doktorRepository.Ekle(doktor);
                _doktorRepository.Kaydet();
                TempData["basarili"] = "Yeni Doktor başarıyla oluşturuldu";
                return RedirectToAction("Index","Doktor");
            }
            return View();
        }

        public IActionResult Guncelle(int? id)
        {
            if(id== null || id==0)
            {
                return NotFound();
            }
            Doktor? doktorVT = _doktorRepository.Get(u=>u.Id==id);  //Expression<Func<T, bool>> filtre
            if(doktorVT == null) 
            { 
                return NotFound(); 
            }
            return View(doktorVT);
        }

        [HttpPost]
        public IActionResult Guncelle(Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                _doktorRepository.Guncelle(doktor);
                _doktorRepository.Kaydet();
                TempData["basarili"] = "Doktor başarıyla güncellendi";
                return RedirectToAction("Index", "Doktor");
            }
            return View();
        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Doktor? doktorVT = _doktorRepository.Get(u => u.Id == id);
            if (doktorVT == null)
            {
                return NotFound();
            }
            return View(doktorVT);
        }

        [HttpPost,ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Doktor? doktor = _doktorRepository.Get(u => u.Id == id);
            if (doktor == null)
            {
                return NotFound();
            }
            _doktorRepository.Sil(doktor);
            _doktorRepository.Kaydet();
            TempData["basarili"] = "Doktor başarıyla silindi";
            return RedirectToAction("index", "Doktor");
        }
    }
}
