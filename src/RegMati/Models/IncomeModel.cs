using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegMati.Models
{
    public class IncomeModel
    {
        public string pay_id { get; set; }
        public string pay_ref_income_id { get; set; }
        public string pay_amount { get; set; }
        public string pay_ref_emp_id { get; set; }
        public string pay_admin_id { get; set; }
        public string pay_submit_date { get; set; }
        public string pay_start_date { get; set; }
        public string pay_end_date { get; set; }
        public string pay_status { get; set; }
        public string event_status { get; set; }
        public string income_id { get; set; }
        public string income_name { get; set; }
        public string income_submit_date { get; set; }
        public string income_admin_id { get; set; }
        public string chk_fix { get; set; }
        public string chk_per { get; set; }
        public string chk_ot { get; set; }
        public string chk_sso { get; set; }
        public string chk_pvf { get; set; }
        public string chk_bonus { get; set; }
        public string chk_tax { get; set; }
        public string mod_up { get; set; }
        public string round_up { get; set; } 
        public string sp_type_id { get; set; }
        public string sp_type_code { get; set; }
        public string ep_id { get; set; }
        public string bg { get; set; }
        public double summary { get; set; }
        public List<string> list_color { get; set; }

        DataBaseClass db = new DataBaseClass();

        public void list_custom() {

            list_color = new List<string>();

            list_color.Add("bg-yellow");
            list_color.Add("bg-green");
            list_color.Add("bg-red");
            list_color.Add("bg-blue");
            list_color.Add("bg-purple");
            list_color.Add("bg-orange"); 

        }


        public List<IncomeModel> income_list() {

            list_custom();

            List<IncomeModel> obj = new List<IncomeModel>();


            int i = 0;
            db.dbConnect();
            db.cmd = new System.Data.SqlClient.SqlCommand("select * from tab_emp_pay "+
                                                          "  inner join tab_info_income cm on cm.income_id = pay_ref_income_id"+
                                                          "  where pay_ref_emp_id = '"+ep_id+"' and pay_end_date >= GETDATE() and cm.chk_fix = 'Y'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {

                IncomeModel nc = new IncomeModel();

              nc.pay_id  = db.rdr["pay_id"].ToString();
              nc.pay_ref_income_id   = db.rdr["pay_ref_income_id"].ToString();
              nc.pay_amount  = Convert.ToDouble(db.rdr["pay_amount"]).ToString("0,0.00");
              nc.pay_ref_emp_id   = db.rdr["pay_ref_emp_id"].ToString();
              nc.pay_admin_id   = db.rdr["pay_admin_id"].ToString();
              nc.pay_submit_date  = db.rdr["pay_submit_date"].ToString();
              nc.pay_start_date  = db.rdr["pay_start_date"].ToString();
              nc.pay_end_date  = db.rdr["pay_end_date"].ToString();
              nc.pay_status  = db.rdr["pay_status"].ToString();
              nc.event_status  = db.rdr["event_status"].ToString();
              nc.income_id  = db.rdr["income_id"].ToString();
              nc.income_name  = db.rdr["income_name"].ToString();
              nc.income_submit_date  = db.rdr["income_submit_date"].ToString();
              nc.income_admin_id  = db.rdr["income_admin_id"].ToString();
              nc.chk_fix  = db.rdr["chk_fix"].ToString();
              nc.chk_per  = db.rdr["chk_per"].ToString();
              nc.chk_ot  = db.rdr["chk_ot"].ToString();
              nc.chk_sso  = db.rdr["chk_sso"].ToString();
              nc.chk_pvf  = db.rdr["chk_pvf"].ToString();
              nc.chk_bonus  = db.rdr["chk_bonus"].ToString();
              nc.chk_tax  = db.rdr["chk_tax"].ToString();
              nc.mod_up  = db.rdr["mod_up"].ToString();
              nc.round_up   = db.rdr["round_up"].ToString();
              nc.event_status  = db.rdr["event_status"].ToString();
              nc.sp_type_id   = db.rdr["sp_type_id"].ToString();
              nc.sp_type_code = db.rdr["sp_type_code"].ToString();
                nc.bg = list_color[i];


                summary += Convert.ToDouble(db.rdr["pay_amount"]);

             obj.Add(nc);

                i++;
            }
            db.dbClosed();

            return obj;
        }
    }
}
