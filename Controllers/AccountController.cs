using CrudEFbyMigration.Data;
using CrudEFbyMigration.Models;
using CrudEFbyMigration.Security;
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
            string encryptedPassword = CustomEncryptionHelper.Encrypt(user.Password);
            var objUser = new User
            {
                FirstName=user.FirstName,
                LastName=user.LastName,
                Email=user.Email,
                Gender=user.Gender,
                Password=encryptedPassword,
                ConfirmPassword=user.ConfirmPassword,
            };

            _dbcontext.Users.Add(objUser);
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
            string encryptedPassword = CustomEncryptionHelper.Encrypt(User.Password);

            bool isvalid = _dbcontext.Users.Any(x => x.Email == User.Email && x.Password == encryptedPassword);
            ModelState.AddModelError(key:"", errorMessage:"Invalid UserName and Password");
            if(isvalid ==true)
            return RedirectToAction("Create", controllerName:"Employee"); 
            else
                return RedirectToAction("Index", controllerName: "Employee");


        }

        public IActionResult StorePassword(string password)
        {
            string encryptedPassword = CustomEncryptionHelper.Encrypt(password);
            // Save encryptedPassword to DB
            return Ok(encryptedPassword);
        }

        [HttpGet]
        public IActionResult ShowPassword(string email)
        {

            return View();
        }
        [HttpGet]
        public IActionResult RetrievePassword(string email)
        {
            var user = _dbcontext.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var decryptedPassword = CustomEncryptionHelper.Decrypt(user.Password);
            return Ok(decryptedPassword);
        }
    }
}
