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
        private ApplicationDbContext db = new ApplicationDbContext();
        public PaymentController()
        {
            ViewData["Genres"] = db.Genres.ToList();
        }
        public ActionResult PaymentMethod(FormDetails CustomInfo)
        {
            if (Session["Email"] == null && CustomInfo.UserType == 2)
            {
                return RedirectToAction("Login","Account");
            }
            else if(Session["Email"] != null && CustomInfo.UserType == 2)
            {
                return View(CustomInfo);
            }
            else if(Session["Email"] != null && CustomInfo.UserType == 1)
            {
                return View(CustomInfo);
            }
            else
            {
                return View(CustomInfo);
            }
            
        }
        public ActionResult Receipt(FormDetails FD)
        {
            List<MovieDisplayViewModel> CartList = HttpContext.Session["ShoppingCart"] != null ? (List<MovieDisplayViewModel>)HttpContext.Session["ShoppingCart"] : new List<MovieDisplayViewModel>();
            List<MovieDisplayViewModel> Cart = new List<MovieDisplayViewModel>();
            foreach (var item in CartList)
            {
                Cart.Add(item);
            }
            ViewData["ShoppingCart"] = Cart;
            List<FormDetails> info = new List<FormDetails>();
            info.Add(FD);
            ViewData["CustomDetails"] = info;
            decimal TotalPrice = 0;
            foreach (var item in CartList)
            {
                if (item.IsOnSale == true)
                {
                    TotalPrice += decimal.Parse(item.NewPrice);
                }
                else
                {
                    TotalPrice += item.Movie.MoviePrice;
                }

            }
            ViewBag.Sum = TotalPrice;
            ((List<MovieDisplayViewModel>)HttpContext.Session["ShoppingCart"]).Clear();
            return View(CartList);
        }
    }
}