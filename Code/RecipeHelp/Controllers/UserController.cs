using Microsoft.AspNetCore.Mvc;
using RecipeHelp.Models;
using RecipeHelp.Models.ViewModels;
using System.Linq;

namespace RecipeHelp.Controllers
{
    public class UserController : Controller
    {
        //FIELDS & PROPERTIES

        private IUserRepo _repository;
        private IRecipeRepo _recipeRepo;

        //CONSTRUCTORS
        public UserController(IUserRepo user, IRecipeRepo recipe)
        {
            _repository = user;
            _recipeRepo = recipe;
        }

        //METHODS

        //CREATE

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegistrationViewModel urvm)
        {
            if (ModelState.IsValid)
            {
                User u = new User();
                u.IsAdmin = false;
                u.Email = urvm.Email;
                u.UserName = urvm.UserName;
                u.Password = urvm.Password;
                u.Name = urvm.Name;
                User newUser = _repository.Create(u);

                if(newUser == null)
                {
                    ModelState.AddModelError("", "The user already exists");
                    return View(urvm);
                }
                else
                {
                    return RedirectToAction("Registered", "User");
                }
            }

            return View(urvm);
        }

        //READ
        public IActionResult Index()
        {
            User u = _repository.GetUserById(_repository.GetLoggedInUserId());
            return View(u);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel ulvm)
        {
            if (ModelState.IsValid)
            {
                User u = new User();
                u.UserName = ulvm.UserName;
                u.Password = ulvm.Password;

                bool loggedIn = _repository.Login(u);

                if (loggedIn == true)
                    //Successful
                    return RedirectToAction("Index", "User");
            }

            return View(ulvm);
        }

        public IActionResult Logout()
        {
            _repository.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AdvancedSearchResults(string keyword, int cooktime, string budget, string difficulty, string course, string cuisine, string diet)
        {
            return View(_recipeRepo.GetRecipesByFilter(keyword, cooktime, budget, difficulty, course, cuisine, diet));
        }
        

        //UPDATE
        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(UserChangePasswordViewModel upvm)
        {
            if (ModelState.IsValid)
            {
                bool success = _repository.ChangePassword(upvm.CurrentPassword, upvm.NewPassword);

                if (success == true)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "We're unable to change your password");
                    return RedirectToAction("PassChangeSuccess", "User");
                }
            }

            return View(upvm);
        }

        //DELETE

        //OTHER

        public IActionResult Registered()
        {
            return View();
        }

        public IActionResult PassChangeSuccess()
        {
            return View();
        }
    }
}
