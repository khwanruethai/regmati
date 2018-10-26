using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RegMati.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Calendar()
        {
            return View();
        }
        public IActionResult sick() {

            return View();
        }
        public IActionResult busy()
        {

            return View();
        }
        public IActionResult stop()
        {

            return View();
        }
        public IActionResult other()
        {

            return View();
        }
        public IActionResult cancel()
        {

            return View();
        }
        public IActionResult follow()
        {

            return View();
        }
    }
}
