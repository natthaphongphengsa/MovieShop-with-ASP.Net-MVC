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

        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult AdminPage()
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

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            return View(model);
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
                Movie movie = new Movie { MovieTitle=model.MovieTitel,
                    MovieReleaseYear=model.MovieReleaseYear, 
                    MovieDuration=model.MovieDuration, 
                    MoviePosters=model.MoviePosters, 
                    MovieDescription=model.MovieDescription, 
                    MoviePrice=model.MoviePrice};

                _db.Movies.Add(movie);

               return RedirectToAction("Index");
            }
            else return View(model); 
        }

    }

}