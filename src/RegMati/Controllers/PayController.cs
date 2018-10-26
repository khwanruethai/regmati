using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegMati.Models;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Drawing;
using System.IO;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RegMati.Controllers
{
    public class PayController : Controller
    {
        protected static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
        public IActionResult Index()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("session_emp_id")) == true)
            {

                return RedirectToAction("Index","Home");
            }
            else {

                empModel mp = new empModel();
                mp.ep_id = HttpContext.Session.GetString("session_emp_id");
                mp.select_emp();

                ViewData["emp_username"] = mp.ps_name_full;
                ViewData["emp_name"] = mp.prefix_name_th + mp.ps_name_full;
                ViewData["emp_code"] = mp.ep_code;
                ViewData["emp_post"] = mp.post_name;
                ViewData["emp_dept"] = mp.dept_name;
                ViewData["emp_sect"] = mp.Section_name;
                ViewData["emp_comp"] = mp.T_Company;
                 
             
                ViewData["emp_img"] = "http://10.10.20.42/profile/" + mp.img_name;

                IncomeModel nc = new IncomeModel();
                nc.ep_id = mp.ep_id;
                ViewData["income"] = nc.income_list();
                ViewData["summary"] = nc.summary.ToString("0,0.00");

                periodModel pd = new periodModel();
                pd.ep_id = mp.ep_id;
                ViewData["period"] = pd.period_list();
                pd.get_max_period_date();

                gdataSlip(pd.period_date);
                
                return View();

            }
             
        }
        public void gdataSlip(string dt) {

            CultureInfo th = new CultureInfo("TH");

            periodModel pd = new periodModel();
            pd.period_date = dt;


            DateTime d =  DateTime.ParseExact(pd.period_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            ViewData["file_name"] = Convert.ToDateTime(d).ToString("yyMM", th) + HttpContext.Session.GetString("session_emp_code") + ".pdf";
            string file = Convert.ToDateTime(d).ToString("yyMM", th) + HttpContext.Session.GetString("session_emp_code");

            try
            {
                download(file, pd.period_date);
            }
            catch {


            }

            pd.ep_id = HttpContext.Session.GetString("session_emp_id");
            pd.select_slip();

            ViewData["logo"] = pd.logo;
            ViewData["comp_name"] = pd.comp_name;
            ViewData["ep_code"] = pd.ep_code;
            ViewData["ep_name"] = pd.ep_name;
            ViewData["period_date"] = pd.period_date;
            ViewData["dept_code"] = pd.dept_code;
            ViewData["dept_name"] = pd.dept_name;
            ViewData["section_code"] = pd.section_code;
            ViewData["section_name"] = pd.section_name;
            ViewData["item_no"] = pd.item_no;
            ViewData["a01"] = pd.A01;
            ViewData["a02"] = pd.A02;
            ViewData["a03"] = pd.A03;
            ViewData["a04"] = pd.A04;
            ViewData["a05"] = pd.A05;
            ViewData["a06"] = pd.A06;
            ViewData["a07"] = pd.A07;
            ViewData["a08"] = pd.A08;
            ViewData["a09"] = pd.A09;
            ViewData["a10"] = pd.A10;
            ViewData["a11"] = pd.A11;
            ViewData["a12"] = pd.A12;
            ViewData["a13"] = pd.A13;
            ViewData["a14"] = pd.A14;
            ViewData["a15"] = pd.A15;
            ViewData["d01"] = pd.D01;
            ViewData["d02"] = pd.D02;
            ViewData["d03"] = pd.D03;
            ViewData["d04"] = pd.D04;
            ViewData["d05"] = pd.D05;
            ViewData["d06"] = pd.D06;
            ViewData["d07"] = pd.D07;
            ViewData["income_total"] = pd.income_total;
            ViewData["minus_total"] = pd.minus_total;
            ViewData["net_amount"] = pd.net_amount;
            ViewData["income_sum"] = pd.income_sum;
            ViewData["tax_sum"] = pd.tax_sum;
            ViewData["sso_sum"] = pd.sso_sum;
            ViewData["pvf_sum"] = pd.pvf_sum;

          


        }
        public IActionResult gslip(string dt) {

            periodModel pd = new periodModel();

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("session_emp_id")) == false)
            {

                if (string.IsNullOrEmpty(dt) == false)
                {

                    HttpContext.Session.SetString("session_period_date", dt); 
                    HttpContext.Session.SetString("session_file_download", dt);

                }
                else
                {

                    pd.ep_id = HttpContext.Session.GetString("session_emp_id");
                    pd.get_max_period_date();
                 

                    HttpContext.Session.SetString("session_period_date", pd.period_date); 
                }


                return RedirectToAction("slip", "Pay");

            }
            else {


                return RedirectToAction("Index", "Home");

            } 
        }
        public IActionResult slip() {

            periodModel pd = new periodModel();

            CultureInfo th = new CultureInfo("TH");

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("session_emp_id")) == false)
            {
               

                if (string.IsNullOrEmpty(HttpContext.Session.GetString("session_period_date")) == true)
                {
                    pd.ep_id = HttpContext.Session.GetString("session_emp_id");
                    ViewData["year"] = pd.year_list("");
                    pd.get_max_period_date();
                    ViewData["btn_action"] = Convert.ToDateTime(pd.period_date).ToString("MM");
                    gdataSlip(pd.period_date);
                  

                }
                else
                {

                    pd.period_date = HttpContext.Session.GetString("session_period_date");
                    pd.ep_id = HttpContext.Session.GetString("session_emp_id");
                    ViewData["year"] = pd.year_list("");
                    ViewData["btn_action"] = Convert.ToDateTime(pd.period_date).ToString("MM");
                    gdataSlip(pd.period_date);
                    
                }

                return View();
            }
            else {

                return RedirectToAction("Index","Home");
            }


          
        }
        public string schdata(string y, string m) {

            string result = "";

            periodModel pd = new periodModel();
            pd.y = y;
            pd.m = m;
            pd.ep_id = HttpContext.Session.GetString("session_emp_id");
            pd.select_period_date_on_search();

            if (pd.period_date != "N")
            {
                result = pd.period_date;

            }
            else {

                result = "N";
            }


            return result;
        }
        public void download(string q, string date) {

            slipModel sl = new slipModel();

            sl.period_date = date;
            sl.ep_id = HttpContext.Session.GetString("session_emp_id");

            string comp = HttpContext.Session.GetString("session_emp_comp_id");
            string file_name = q;

            if (comp == "1")
            {
                sl.creat_slip(file_name);
            }
            else if (comp == "2")
            {
                sl.creat_slip_ks(file_name);
            }
            else if (comp == "3") {

                sl.creat_slip_nd(file_name);
            }

            // sl.creat_slip();
            // sl.creat_slip_ks(); 
          
        }
    }
}
