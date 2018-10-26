using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RegMati.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RegMati.Controllers
{
    public class SettingController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public string gdata(string q) {

            LoginModel lg = new LoginModel();
            lg.password = q;
            lg.emp_id = HttpContext.Session.GetString("session_emp_id");

            return lg.check_pw();
        }
        public IActionResult changePassword() {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("session_emp_id")) == true)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Index","Home");
            }
            else {

                if (string.IsNullOrEmpty(HttpContext.Session.GetString("change_pw")) == true) {

                    ViewData["status"] = "N";

                }
                else {

                    ViewData["status"] = HttpContext.Session.GetString("change_pw");
                    HttpContext.Session.Remove("change_pw");
                }

              

                return View();
            }

           
        }
        [HttpPost]
        public IActionResult change(string pw_new) {

            mdModel md = new mdModel();
            md.txt = pw_new;
            md.ConvertMd5();

            LoginModel lg = new LoginModel();
            lg.emp_id = HttpContext.Session.GetString("session_emp_id");
            lg.password = md.md;
            lg.changePass();

            HttpContext.Session.SetString("change_pw","T");

             
            return RedirectToAction("changePassword", "Setting");
        }
    }
}
