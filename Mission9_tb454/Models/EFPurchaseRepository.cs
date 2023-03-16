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

        IQueryable<BookPurchase> IPurchaseRepository.Purchases { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } //he doesn't have this line

        public IQueryable<BookPurchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchase(BookPurchase bookPurchase)
        {
            context.AttachRange(bookPurchase.Lines.Select(x => x.Book));

            if (bookPurchase.PurchaseId == 0)
            {
                context.Purchases.Add(bookPurchase);
            }

            context.SaveChanges();
        }
    }
}
