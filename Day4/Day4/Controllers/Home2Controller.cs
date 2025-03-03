﻿using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Day4.Controllers
{
    public class Home2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult profile()
        {
            TempData["hide"] = HttpContext.Session.GetString("mail");

            string nmail = HttpContext.Session.GetString("mail");
            string npass = HttpContext.Session.GetString("pass");
            string nfname = HttpContext.Session.GetString("fname");
            string nlname = HttpContext.Session.GetString("lname");


            TempData["data0"] = nfname;
            TempData["data1"] = nlname;
            TempData["data2"] = nmail;
            TempData["data3"] = npass;


            return View();

        }
        [HttpPost]
        public IActionResult new_profile(string log3 , string log4)
        {

            TempData["loction"] = log4;
            TempData["phone"] = log3;
            return RedirectToAction("profile" , "Home2");
        }
    }
}
