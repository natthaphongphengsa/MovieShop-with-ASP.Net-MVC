using Project_G3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Project_G3.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public HomeController()
        {
            ViewData["Genres"] = db.Genres.ToList();
        }

        //[Authorize (Roles="Admin")]
        public ActionResult Index()
        {
            List<Movie> CartList = HttpContext.Session["ShoppingCart"] != null ? (List<Movie>)HttpContext.Session["ShoppingCart"] : new List<Movie>();
            //Visa Antal film som finns i varukorg i index sidan
            int amount;
            //Om varukorg är tomt sätt 0
            if (CartList.Count != 0) { amount = CartList.Count; } else { amount = 0; }
            ViewBag.Amount = amount;
            List<Movie> movies = db.Movies.ToList();
            List<MovieDisplayViewModel> dm = GetAllFlashSales();
            foreach (Movie movie in movies)
            {
                if (!dm.Any(m => m.Movie == movie))
                {
                    dm.Add(new MovieDisplayViewModel
                    {
                        Movie = movie,
                        IsOnSale = false
                    });
                }
            }
            dm.OrderBy(m => m.Movie.MovieId);
            return View(dm);
        }
        public ActionResult Cart()
        {
            List<Movie> CartList = HttpContext.Session["ShoppingCart"] != null ? (List<Movie>)HttpContext.Session["ShoppingCart"] : new List<Movie>();
            ViewData["ShoppingCart"] = CartList;
            decimal TotalPrice = 0;
            foreach (var item in CartList) { TotalPrice += item.MoviePrice; }
            ViewBag.Sum = TotalPrice;
            return View(CartList);
        }
        public ActionResult AddToCart(int Id)
        {
            //ApplicationDbContext _db = new ApplicationDbContext();
            List<Movie> CartList = HttpContext.Session["ShoppingCart"] != null ? (List<Movie>)HttpContext.Session["ShoppingCart"] : new List<Movie>();
            Movie movie = db.Movies.First(m => m.MovieId == Id);
            if (!CartList.Any(m => m.MovieId == movie.MovieId)) CartList.Add(movie);
            HttpContext.Session["ShoppingCart"] = CartList;

            return RedirectToAction("Index");
        }
        public ActionResult DeleteFromCart(int Id)
        {
            List<Movie> CartList = HttpContext.Session["ShoppingCart"] != null ? (List<Movie>)HttpContext.Session["ShoppingCart"] : new List<Movie>();
            if (CartList.Any(m => m.MovieId == Id)) CartList.Remove(CartList.First(m => m.MovieId == Id));
            return RedirectToAction("Cart");
        }
        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Info(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Movie movie = db.Movies.FirstOrDefault(m => m.MovieId == id);

            //skapa en lita med all genre
            List<Genre> genres = db.Genres.ToList();
            List<Genre> title = new List<Genre>();
            //leta efter vilken genre och hur många genre som finns i den filmen och lägger in i tomt lista
            foreach (var genre in movie.Genres)
            {
                title.Add(genre);
            }
            //lägger in alla genre i Viewdata med Namn GenreInfo
            ViewData["GenreInfo"] = title;
            return View(movie);
        }
        public ActionResult Genre(int Id)
        {
            List<Movie> movies = db.Genres.First(g => g.GenreId == Id).Movies.ToList();
            List<Genre> genre = db.Genres.ToList();
            ViewData["GenreTitle"] = genre.First(g => g.GenreId == Id).GenreName;
            return View(movies);
        }
        public ActionResult ConfirmAdress(int? SelectedId)
        {
            //List<PaymentOption> method = new List<PaymentOption>();
            //method.Add(new PaymentOption() { PaymentId = 1, PaymentIcon = "https://aux2.iconspalace.com/uploads/master-card-icon-256.png", PaymentName = "Master Card" });
            //method.Add(new PaymentOption() { PaymentId = 2, PaymentIcon = "https://cdn4.iconfinder.com/data/icons/payment-method/160/payment_method_card_visa-256.png", PaymentName = "Visa" });
            //method.Add(new PaymentOption() { PaymentId = 3, PaymentIcon = "https://www.skibike.se/wp-content/uploads/2018/11/Paypal-icon.png", PaymentName = "Paypal" });
            //method.Add(new PaymentOption() { PaymentId = 4, PaymentIcon = "https://redlight.se/wp-content/uploads/2015/12/produkt-swish-2.png", PaymentName = "Swish" });
            //ViewData["PaymentList"] = method;
            ViewBag.Name = "Please select your payment!";
            ViewBag.ContinueAsGuest = SelectedId;
            return View();
        }

        public List<MovieDisplayViewModel> GetAllFlashSales()
        {
            List<MovieDisplayViewModel> movies = new List<MovieDisplayViewModel>();
            List<FlashSale> flashsales = db.FlashSales.ToList();
            foreach (FlashSale item in flashsales)
            {
                decimal newPrice;
                bool isprocentedbased = item.FlashSaleDiscount[item.FlashSaleDiscount.Length - 1] == '%';
                foreach (Movie movie in item.Movies)
                {
                    decimal discount;
                    if (isprocentedbased)
                    {
                        discount = Decimal.Parse(item.FlashSaleDiscount.Substring(0, item.FlashSaleDiscount.Length - 1)) / 100;
                        newPrice = movie.MoviePrice - movie.MoviePrice * discount;
                    }
                    else
                    {
                        discount = decimal.Parse(item.FlashSaleDiscount);
                        newPrice = movie.MoviePrice - discount;
                    }
                    MovieDisplayViewModel Mo = movies.Find(m => m.Movie.MovieId == movie.MovieId);
                    if (Mo == null)
                    {
                        movies.Add(new MovieDisplayViewModel
                        {
                            Movie = movie,
                            IsOnSale = true,
                            NewPrice = newPrice.ToString("#.#0"),
                            FlashSale = item.FlashSaleDiscount
                        });
                    }
                    else if (Mo.Movie.MoviePrice > movie.MoviePrice)
                    {
                        movies.Remove(Mo);
                        movies.Add(new MovieDisplayViewModel
                        {
                            Movie = movie,
                            IsOnSale = true,
                            NewPrice = newPrice.ToString(),
                            FlashSale = item.FlashSaleDiscount
                        });
                    }
                }
            }
            return movies;
        }

        public ActionResult GetFlashSale()
        {
            return View(GetAllFlashSales());
        }
        public ActionResult News()
        {
            List<Movie> moviesNew = new List<Movie>();
            foreach (var item in db.Movies)
            {
                if (Int32.Parse(item.MovieReleaseYear) > 2018)
                {
                    moviesNew.Add(item);
                }
            }

            return View(moviesNew);
        }
    }
}