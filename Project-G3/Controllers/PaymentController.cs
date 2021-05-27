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
        public ActionResult PaymentMethod(FormDetails CustomInfo, int Id)
        {
            if (Session["Email"] == null && Id == 2)
            {
                return RedirectToAction("Login","Account");
            }
            else if(Session["Email"] != null && Id == 2)
            {
                return View(CustomInfo);
            }
            else if(Session["Email"] != null && Id == 1)
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
            ViewData["ShoppingCart"] = CartList;
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
            return View(CartList);
        }
    }
}