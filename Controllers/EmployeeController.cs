using CrudEFbyMigration.Data;
using CrudEFbyMigration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CrudEFbyMigration.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public EmployeeController(ApplicationDbContext _dbContext , IWebHostEnvironment hostEnvironment)
        {
            dbContext = _dbContext;
            webHostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            List<Employee> lst = dbContext.Employees.ToList();
            return View(lst);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            var files = Request.Form.Files;
            string dbpath = string.Empty;
            if (files.Count > 0)
            {
                string Image=webHostEnvironment.WebRootPath;
                string fullpath = Path.Combine(Image + "\\Image", files[0].FileName);
                dbpath = "Image/" + files[0].FileName;
                FileStream stream = new FileStream(fullpath, FileMode.Create);
                files[0].CopyTo(stream);
            }
            model.Image = dbpath;
            dbContext.Employees.Add(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var del = await dbContext.Employees.SingleOrDefaultAsync(x => x.Id == id);
                dbContext.Employees.Remove(del);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            try
            {
               var emp = await dbContext.Employees.SingleOrDefaultAsync(x => x.Id == Id);
                return View(emp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Update(Employee model)
        {
            var files = Request.Form.Files;
            string dbpath = string.Empty;
            if (files.Count > 0)
            {
                string Image = webHostEnvironment.WebRootPath;
                string fullpath = Path.Combine(Image + "\\Image", files[0].FileName);
                dbpath = "Image/" + files[0].FileName;
                FileStream stream = new FileStream(fullpath, FileMode.Create);
                files[0].CopyTo(stream);
            }
            model.Image = dbpath;
            dbContext.Employees.Update(model);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
           
        }
    }
}
