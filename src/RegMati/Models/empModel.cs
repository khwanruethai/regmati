using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegMati.Models
{
    public class empModel
    {
         public string ep_id { get; set;}
         public string  ep_code { get; set; }
        public string  ep_ref_personal_id { get; set; }
        public string  ep_ref_type_id { get; set; }
        public string  ep_start { get; set; }
        public string  ep_end { get; set; }
        public string  ep_status { get; set; }
        public string  ep_submit_date { get; set; }
        public string  ep_ref_admin_id { get; set; }
        public string  event_status { get; set; }
        public string  ep_age_year { get; set; }
        public string  ep_age_day { get; set; }
        public string  ep_gen_pw { get; set; }
        public string  ep_pw { get; set; } 
        public string  prefix_name_th { get; set; }
        public string  prefix_name_en { get; set; }
        public string  ps_name_th { get; set; }
        public string  ps_lastname_th { get; set; }
        public string  ps_name_en { get; set; }
        public string  ps_lastname_en { get; set; } 
        public string  type_name { get; set; } 
        public string  ps_name_full { get; set; }
        public string  position_posit_id { get; set; }
        public string  post_name { get; set; }
        public string  position_comp_id { get; set; }
        public string  T_Company { get; set; }
        public string  position_sect_id { get; set; }
        public string  Section_name { get; set; }
        public string  position_dept_id { get; set; }
        public string  dept_name { get; set; }
        public string  position_active { get; set; }
        public string  position_status { get; set; }
        public string  position_start_date { get; set; }
        public string  position_resign_date { get; set; }
        public string  contact_id { get; set; }
        public string  contact_email { get; set; }
        public string  contact_table { get; set; }
        public string  contact_phone { get; set; }
        public string  contact_mobile1 { get; set; }
        public string  contact_mobile2 { get; set; }
        public string  contact_personal_id { get; set; }
        public string  ps_gender { get; set; }
        public string  ps_blood { get; set; }
        public string  ps_national_id { get; set; }
        public string  ps_national_date_start { get; set; }
        public string  ps_national_date_end { get; set; }
        public string  ps_birthday { get; set; }
        public string  ps_nationality { get; set; }
        public string  ps_race { get; set; }
        public string  ps_religion { get; set; }
        public string  ps_status_marital { get; set; }
        public string  img_id { get; set; }
        public string  img_name { get; set; }
        public string  img_ref_emp_id { get; set; }
        public string  img_ref_person_id { get; set; }
        public string  img_ref_admin_id { get; set; }
        public string  img_submit_date { get; set; }

        DataBaseClass db = new DataBaseClass();

        public void select_emp() {

            db.dbConnect();
            db.cmd = new System.Data.SqlClient.SqlCommand("SELECT * FROM tab_emp ep "+
                                                            " INNER JOIN  view_employee vm on vm.ep_id = ep.ep_id"+
                                                            " LEFT JOIN tab_emp_profile_img mg on mg.img_ref_emp_id = ep.ep_id"+
                                                            "  where  vm.position_active = 'Y' and ep.ep_id = '"+ep_id+"'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {

              ep_id   = db.rdr["ep_id"].ToString();
              ep_code   = db.rdr["ep_code"].ToString();
              ep_ref_personal_id  = db.rdr["ep_ref_personal_id"].ToString();
              ep_ref_type_id  = db.rdr["ep_ref_type_id"].ToString();
              ep_start  = db.rdr["ep_start"].ToString();
              ep_end  = db.rdr["ep_end"].ToString();
              ep_status  = db.rdr["ep_status"].ToString();
              ep_submit_date  = db.rdr["ep_submit_date"].ToString();
              ep_ref_admin_id  = db.rdr["ep_ref_admin_id"].ToString();
              event_status  = db.rdr["event_status"].ToString();
              ep_age_year  = db.rdr["ep_age_year"].ToString();
              ep_age_day  = db.rdr["ep_age_day"].ToString();
              ep_gen_pw   = db.rdr["ep_gen_pw"].ToString();
              ep_pw   = db.rdr["ep_pw"].ToString();
              ep_id   = db.rdr["ep_id"].ToString();
              ep_code   = db.rdr["ep_code"].ToString();
              ep_ref_personal_id  = db.rdr["ep_ref_personal_id"].ToString();
              prefix_name_th  = db.rdr["prefix_name_th"].ToString();
              prefix_name_en  = db.rdr["prefix_name_en"].ToString();
              ps_name_th   = db.rdr["ps_name_th"].ToString();
              ps_lastname_th   = db.rdr["ps_lastname_th"].ToString();
              ps_name_en    = db.rdr["ps_name_en"].ToString();
              ps_lastname_en   = db.rdr["ps_lastname_en"].ToString();
              ep_ref_type_id   = db.rdr["ep_ref_type_id"].ToString();
              type_name   = db.rdr["type_name"].ToString();
              ep_start    = db.rdr["ep_start"].ToString();
              ep_submit_date   = db.rdr["ep_submit_date"].ToString();
              ep_ref_admin_id   = db.rdr["ep_ref_admin_id"].ToString();
              ps_name_full   = db.rdr["ps_name_full"].ToString();
              position_posit_id  = db.rdr["position_posit_id"].ToString();
              post_name   = db.rdr["post_name"].ToString();
              position_comp_id    = db.rdr["position_comp_id"].ToString();
              T_Company   = db.rdr["T_Company"].ToString();
              position_sect_id   = db.rdr["position_sect_id"].ToString();
              Section_name   = db.rdr["Section_name"].ToString();
              position_dept_id   = db.rdr["position_dept_id"].ToString();
              dept_name   = db.rdr["dept_name"].ToString();
              position_active   = db.rdr["position_active"].ToString();
              position_status  = db.rdr["position_status"].ToString();
              position_start_date  = db.rdr["position_start_date"].ToString();
              position_resign_date   = db.rdr["position_resign_date"].ToString();
              contact_id   = db.rdr["contact_id"].ToString();
              contact_email   = db.rdr["contact_email"].ToString();
              contact_table    = db.rdr["contact_table"].ToString();
              contact_phone   = db.rdr["contact_phone"].ToString();
              contact_mobile1  = db.rdr["contact_mobile1"].ToString();
              contact_mobile2   = db.rdr["contact_mobile2"].ToString();
              contact_personal_id  = db.rdr["contact_personal_id"].ToString();
              ps_gender   = db.rdr["ps_gender"].ToString();
              ps_blood    = db.rdr["ps_blood"].ToString();
              ps_national_id   = db.rdr["ps_national_id"].ToString();
              ps_national_date_start   = db.rdr["ps_national_date_start"].ToString();
              ps_national_date_end  = db.rdr["ps_national_date_end"].ToString();
              ps_birthday   = db.rdr["ps_birthday"].ToString();
              ps_nationality  = db.rdr["ps_nationality"].ToString();
              ps_race  = db.rdr["ps_race"].ToString();
              ps_religion  = db.rdr["ps_religion"].ToString();
              ps_status_marital   = db.rdr["ps_status_marital"].ToString();
              img_id   = db.rdr["img_id"].ToString();
              img_name   = db.rdr["img_name"].ToString();
              img_ref_emp_id   = db.rdr["img_ref_emp_id"].ToString();
              img_ref_person_id   = db.rdr["img_ref_person_id"].ToString();
              img_ref_admin_id  = db.rdr["img_ref_admin_id"].ToString();
              img_submit_date   = db.rdr["img_submit_date"].ToString();
              event_status = db.rdr["event_status"].ToString();

            }
            db.dbClosed();

        }

    }
}
