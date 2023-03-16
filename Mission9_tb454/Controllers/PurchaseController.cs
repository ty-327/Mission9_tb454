﻿using Microsoft.AspNetCore.Mvc;
using Mission9_tb454.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_tb454.Controllers
{
    public class PurchaseController : Controller
    {

        private IPurchaseRepository repo { get; set; }
        private Cart cart { get; set; }

        public PurchaseController (IPurchaseRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new BookPurchase());
        }

        [HttpPost]
        public IActionResult Checkout(BookPurchase bookPurchase)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                bookPurchase.Lines = cart.Items.ToArray();
                repo.SavePurchase(bookPurchase);
                cart.ClearCart();

                return RedirectToPage("/PurchaseCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
