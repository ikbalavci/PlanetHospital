﻿using udemyWeb1.Haberlesme;

namespace udemyWeb1.Models
{
    public class RandevuRepository : Repository<Randevu>, IRandevuRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public RandevuRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Randevu randevu)
        {
            _uygulamaDbContext.Update(randevu);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
