using Project_G3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Project_G3.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult PaymentMethod()
        {
            return View();
        }
        public ActionResult Receipt()
        {
            List<Movie> CartList = HttpContext.Session["ShoppingCart"] != null ? (List<Movie>)HttpContext.Session["ShoppingCart"] : new List<Movie>();
            ViewData["ShoppingCart"] = CartList;
            decimal TotalPrice = 0;
            foreach (var item in CartList) { TotalPrice += item.MoviePrice; }
            ViewBag.Sum = TotalPrice;
            return View(CartList);
        }
    }
}