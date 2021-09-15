using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Project_G3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project_G3.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public AdminController() { }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult MovieList(List<Movie> movies)
        {
            if (movies == null)
            {
                movies = _db.Movies.ToList();
            }
            return View(movies);
        }

        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/CreateUser
        [Authorize(Roles = "Admin")]
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: Admin/CreateUser
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, model.Role);
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }
            return View(model);
        }
        public ActionResult DeleteUser()
        {
            var users = from u in _db.Users
                    where u.UserName != "Admin"
                    select u;
            List<ApplicationUser> user = new List<ApplicationUser>();
            foreach (var item in users)
            {
                user.Add(item);
            }
            return View(user);
        }
        [Authorize(Roles = "Admin")]       
        public ActionResult DeleteU(string Id)
        {
            List<ApplicationUser> users = _db.Users.ToList();

            if (ModelState.IsValid)
            {

                if (users.Any(m => m.Id == Id))
                {
                    _db.Users.Remove(users.First(m => m.Id == Id));
                    _db.SaveChanges();
                }

                return RedirectToAction("MovieList");
            }


            return View(users);
        }
        // GET: Admin/AddMovie
        [Authorize(Roles = "Admin")]
        public ActionResult AddMovie()
        {
            return View();
        }
        // POST: Admin/AddMovie
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(AddMovieModels model)
        {

            if (ModelState.IsValid)
            {
                Movie movie = new Movie
                {
                    MovieTitle = model.MovieTitel,
                    MovieReleaseYear = model.MovieReleaseYear,
                    MovieDuration = model.MovieDuration,
                    MoviePosters = model.MoviePosters,
                    MovieDescription = model.MovieDescription,
                    MoviePrice = model.MoviePrice
                };

                if (!_db.Movies.Any(m => m.MovieTitle == model.MovieTitel)) _db.Movies.Add(movie);


                return RedirectToAction("Index");
            }
            else return View(model);
        }

        // GET: Admin/DeleteMovie
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteMovie(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("MovieList");
            }

            return View(_db.Movies.First(m => m.MovieId == Id));
        }

       // POST: Admin/DeleteMovie
       [Authorize(Roles = "Admin")]
       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult DeleteMovie(int Id)
        {
            List<Movie> movies = _db.Movies.ToList();

            if (ModelState.IsValid)
            {

                if (movies.Any(m => m.MovieId == Id))
                {
                    _db.Movies.Remove(movies.First(m => m.MovieId == Id));
                    _db.SaveChanges();
                }

               return RedirectToAction("MovieList");
            }

            
            return View(movies);
        }

        // GET: Admin/EditMovie
        [Authorize(Roles = "Admin")]
        public ActionResult EditMovie(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("MovieList");
            }

            return View(_db.Movies.First(m => m.MovieId == Id));
            
        }

        // POST: Admin/EditMovie
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMovie (Movie mov)
        {
           Movie oldMovie =_db.Movies.First(m => m.MovieTitle == mov.MovieTitle);
            _db.Movies.Remove(oldMovie);
            _db.Movies.Add(mov);
           

            //_db.Movies.Remove(movies.First(m => m.MovieId == mov.MovieId));
            //_db.Movies.Add(movie);
            _db.SaveChanges();
            


            return RedirectToAction("MovieList");
        }
    }
}