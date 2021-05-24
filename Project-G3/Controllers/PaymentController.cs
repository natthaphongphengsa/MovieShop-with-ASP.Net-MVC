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
        public ActionResult PaymentMethod(PaymentOption op)
        {
            if (Session["Email"] != null)
            {
                return RedirectToAction("Login", "Account");
            }
            else if (op.PaymentName is null)
            {
                ViewBag.Name = "Please select your payment!";
                return View();
            }
            else
            {
                string options = null;
                switch (op.PaymentName)
                {
                    case "Master Card":
                        options = "https://aux2.iconspalace.com/uploads/master-card-icon-256.png";
                        break;
                    case "Visa":
                        options = "https://cdn4.iconfinder.com/data/icons/payment-method/160/payment_method_card_visa-256.png";
                        break;
                    case "Paypal":
                        options = "https://www.skibike.se/wp-content/uploads/2018/11/Paypal-icon.png";
                        break;
                    case "Swish":
                        options = "https://redlight.se/wp-content/uploads/2015/12/produkt-swish-2.png";
                        break;
                }
                ViewBag.PaymentIcon = options;
                ViewBag.Name = op.PaymentName.ToString();
                return View();
            }

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