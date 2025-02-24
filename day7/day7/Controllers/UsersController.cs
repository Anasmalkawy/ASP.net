using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using day7.Models;

namespace day7.Controllers
{
    public class UsersController : Controller
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }





        public IActionResult Index()
        {
            var user = _context.Users.ToList(); // get data for all user in database in make it in user varible 
            return View(user);
        }








        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            _context.Add(user);// add user to database
            _context.SaveChanges();// save user in database
            return RedirectToAction("Index");
        }







        public IActionResult Edit(int id) // id = the user i want to change 
        {
            var user = _context.Users.Find(id); // search for id user in database
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            _context.Update(user); // updata data for user in database
            _context.SaveChanges(); // save data for user in database
            return RedirectToAction("Index");
        }






        // a page for confrmation  delete
        public IActionResult Delete(int id)


        {
            // اذا بدي احذف بصفحه ثانيه 
            //var user = _context.Users.Find(id);// find the user data by id in database
            //return View(user); // display the data for the user in page 


            // اذا بدي احذف بنفس الصفحه
            var user = _context.Users.Find(id); // find for user data by id in database
            _context.Users.Remove(user); // remove user data from database
            _context.SaveChanges(); // save the delete data for user in database
            return RedirectToAction("Index");
        }


        // اذا بدي اعمل الحذف بصفحه ثانيه 
        //[HttpPost, ActionName("Delete")] // call for delete form in deleteConfirmed 
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    var user = _context.Users.Find(id); // find for user data by id in database
        //    _context.Users.Remove(user); // remove user data from database
        //    _context.SaveChanges(); // save the delete data for user in database
        //    return RedirectToAction("Index"); 
        //}


    }
}
