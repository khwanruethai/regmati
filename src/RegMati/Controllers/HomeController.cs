using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegMati.Models;
using Microsoft.AspNetCore.Http;

namespace RegMati.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public IActionResult signin(string username, string password) {

            LoginModel lg = new LoginModel();
            mdModel md = new mdModel();
            lg.username = username;
            md.txt = password;
            md.ConvertMd5();
            lg.password = md.md;
            lg.loginAccount();

            string ctrl = "";
            string act = "";

            if (lg.action == "T")
            {

                HttpContext.Session.SetString("session_emp_id", lg.emp_id);
                HttpContext.Session.SetString("session_emp_name", lg.emp_name);
                HttpContext.Session.SetString("session_emp_img", lg.emp_img);
                HttpContext.Session.SetString("session_emp_position", lg.emp_position);
                HttpContext.Session.SetString("session_emp_comp_id", lg.emp_comp_id);
                HttpContext.Session.SetString("session_emp_code", lg.emp_code);

                ctrl = "Pay";
                act = "Index";
            }
            else if (lg.action == "F") {


                ctrl = "Home";
                act = "Index";
            }
             
            return RedirectToAction(act, ctrl);
        }
        public IActionResult signout() {

            HttpContext.Session.Clear();

            return RedirectToAction("Index","Home");
        }
    }
}
