using CrudEFbyMigration.Data;
using CrudEFbyMigration.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudEFbyMigration.Controllers
{
    public class AccountController : Controller
    {
        public readonly ApplicationDbContext _dbcontext;
        public AccountController(ApplicationDbContext dbcontext)
        {
            _dbcontext= dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUP()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User user)
        {
           
            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User User)
        {
           bool isvalid= _dbcontext.Users.Any(x => x.Email == User.Email && x.Password == User.Password);
            ModelState.AddModelError(key:"", errorMessage:"Invalid UserName and Password");
            if(isvalid ==true)
            return RedirectToAction("Create", controllerName:"Employee"); 
            else
                return RedirectToAction("Index", controllerName: "Employee");


        }
    }
}
