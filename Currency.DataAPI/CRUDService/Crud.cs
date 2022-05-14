using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDService
{
    public class Crud
    {
        private readonly PostgreDbContext db;
        public Crud(PostgreDbContext db)
        {
            this.db = db;
        }

        public void insert(Currency cy)
        {
            var a = db.Currency.FirstOrDefault(x => x.Date == cy.Date && x.CurrencyCode == cy.CurrencyCode);

            if(a != null)
            {
                db.Update(cy);
            }
            else
            {
                db.Currency.Add(cy);
            }

            db.SaveChanges();
        }

        public IQueryable<Currency> getAll(string code)
        {
            return db.Currency.Where(x => x.CurrencyCode.Equals(code)).OrderBy(x=>x.Date);
        }
    }
}
