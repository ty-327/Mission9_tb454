using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_tb454.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context;
        
        public EFPurchaseRepository (BookstoreContext temp)
        {
            context = temp;
        }

        // public IQueryable<BookPurchase> Purchases { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } <--was this6
        public IQueryable<BookPurchase> Purchases => context.Purchases.Include(x => x.Lines);

        public void SavePurchase(BookPurchase bookPurchase)
        {
            throw new NotImplementedException();
        }
    }
}
