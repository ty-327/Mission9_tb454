using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_tb454.Models
{
    public interface IPurchaseRepository
    {
        IQueryable<BookPurchase> Purchases { get; set; }


        void SavePurchase(BookPurchase bookPurchase);
    }
}
