using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RegMati.Models
{
    public class LoginModel
    { 
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string admin_status { get; set; }
        public string emp_id { get; set; }
        public string emp_img { get; set; }
        public string controll { get; set; }
        public string action { get; set; }
        public string emp_name { get; set; }
        public string emp_code { get; set; }
        public string emp_position { get; set; }
        public string emp_dept { get; set; }
        public string emp_sect { get; set; }
        public string emp_comp { get; set; }
        public string emp_type { get; set; }
        public string emp_comp_id { get; set; }

      DataBaseClass db = new DataBaseClass();

        public void changePass() {


            string table = "tab_emp";
            string[] Columns = { "ep_pw" };
            string[] Values = { password };
            string where = "ep_id = '"+emp_id+"'";

            db.update_db(table, Columns, Values, where);

        }
        public string check_pw() {

            string result = "";

            db.dbConnect();
            db.cmd = new SqlCommand("select COUNT(*) AS result from tab_emp where ep_id = '"+emp_id+"' and ep_pw =  CONVERT(VARCHAR(32), HashBytes('MD5', '"+password+"'), 2)", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {

                result = db.rdr["result"].ToString();
            }

            db.dbClosed();

            return result;
        }

        public void loginAccount()
        {
            dbFile db = new dbFile();
            string return_page = "";
            //try
            //{
                using (SqlConnection conn = new SqlConnection(db.sqlConnection))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM tab_emp ep INNER JOIN  view_employee vm on vm.ep_id = ep.ep_id "+
                        "  LEFT JOIN tab_emp_profile_img mg on mg.img_ref_emp_id = ep.ep_id" +
                        " where  vm.position_active = 'Y' and ep.ep_code = '"+username+"' and ep_pw = '"+password+"'", conn);

                    SqlDataReader rdr = cmd.ExecuteReader();


                    Boolean flag = false; // กำหนดให้ flag = เท็จ
                    while (rdr.Read())
                    {
                        user_id = rdr.GetInt32(0);
                        flag = true;

                        username = rdr["ps_name_full"].ToString();
                        emp_id = rdr["ep_id"].ToString();
                        admin_status = rdr["ep_end"].ToString();//  Session["username"] = name;
                        emp_img = rdr["img_name"].ToString();
                        emp_name = rdr["prefix_name_th"] + "" + rdr["ps_name_full"];
                        emp_code = rdr["ep_code"].ToString();
                        emp_type = rdr["type_name"].ToString();
                        emp_position = rdr["post_name"].ToString();
                        emp_dept = rdr["dept_name"].ToString();
                        emp_sect = rdr["Section_name"].ToString();
                        emp_comp = rdr["T_Company"].ToString();
                        emp_comp_id = rdr["position_comp_id"].ToString();


                    }


                    if (flag == true) // ถ้าเป็นจริงให้ทำ...
                    { 
                        action = "T";
                    }
                    else {
                     
                        action = "F";
                    }

                    conn.Close();
               }
           
         
        }
        public void test() {

            //SqlConnection cnn;
           
            //string connectiongstring = ConfigurationSettings.AppSettings["SqlConnectionString"];
           
            //cnn = new SqlConnection(connectiongstring);

        }
     
    }
}
