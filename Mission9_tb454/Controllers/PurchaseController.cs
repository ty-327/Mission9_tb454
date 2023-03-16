using Microsoft.AspNetCore.Mvc;
using Mission9_tb454.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_tb454.Controllers
{
    public class PurchaseController : Controller
    {

        public PurchaseController ()
        {

        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new BookPurchase());
        }

        [HttpPost]
        public IActionResult Checkout(BookPurchase bookPurchase)
        {

        }
    }
}
