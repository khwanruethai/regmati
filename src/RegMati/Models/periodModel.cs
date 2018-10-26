using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RegMati.Models
{
    public class periodModel
    {
        public string date_txt { get; set; } 
        public string ep_id { get; set; }

        public string ep_salary_id { get; set; } 
        public string period_id { get; set; }
        public string period_date { get; set; }
        public string comp_id { get; set; }
        public string comp_name { get; set; }
        public string ep_code { get; set; }
        public string ep_name { get; set; } 
        public string sect_id { get; set; }
        public string dept_id { get; set; }
        public string post_id { get; set; }
        public string type_salary { get; set; }
        public string item_no { get; set; }
        public string salary1_rate { get; set; }
        public string salary2_rate { get; set; }
        public string salary3_rate { get; set; }
        public string income_sum { get; set; }
        public string tax_sum { get; set; }
        public string sso_sum { get; set; }
        public string pvf_sum { get; set; }
        public string income_total { get; set; }
        public string minus_total { get; set; }
        public string net_amount { get; set; }
        public string section_code { get; set; }
        public string dept_code { get; set; }
        public string section_name { get; set; }
        public string dept_name { get; set; }
        public string A01 { get; set; }
        public string A02 { get; set; }
        public string A03 { get; set; }
        public string A04 { get; set; }
        public string A05 { get; set; }
        public string A06 { get; set; }
        public string A07 { get; set; }
        public string A08 { get; set; }
        public string A09 { get; set; }
        public string A10 { get; set; }
        public string A11 { get; set; }
        public string A12 { get; set; }
        public string A13 { get; set; }
        public string A14 { get; set; }
        public string A15 { get; set; }
        public string D01 { get; set; }
        public string D02 { get; set; }
        public string D03 { get; set; }
        public string D04 { get; set; }
        public string D05 { get; set; }
        public string D06 { get; set; }
        public string D07 { get; set; }
        public string logo { get; set; }
        public string year_th { get; set; }
        public string year { get; set; }

        public string m { get; set; }
        public string y { get; set; }

        CultureInfo th = new CultureInfo("TH");
        CultureInfo en = new CultureInfo("EN");

        DataBaseClass db = new DataBaseClass();

        public void select_period_date_on_search() {

            db.dbConnect();
            db.cmd = new System.Data.SqlClient.SqlCommand("select  sl.period_date from tab_emp_salary sl where sl.ep_id = '"+ep_id+"' and YEAR(sl.period_date) = '"+y+"' and MONTH(sl.period_date) = '"+m+"' and sl.event_status != 'D'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {

                if (string.IsNullOrEmpty(db.rdr["period_date"].ToString()) == false)
                {

                    period_date = Convert.ToDateTime(db.rdr["period_date"]).ToString("yyyy-MM-dd",en);
                }
                else {

                    period_date = "N";
                }
            }
            db.dbClosed();

            if (string.IsNullOrEmpty(period_date) == true) {

                period_date = "N";
            }


        }

        public List<SelectListItem> year_list(string selected) {

            List<SelectListItem> item = new List<SelectListItem>();

            int i = 1;

            db.dbConnect();
            db.cmd = new System.Data.SqlClient.SqlCommand("select YEAR(sl.period_date) as result, YEAR(sl.period_date)+543 as result_th"+
                                                           "  from tab_emp_salary sl"+
                                                           "  where sl.ep_id = '"+ep_id+"' and sl.event_status != 'D'"+
                                                           "  group by YEAR(sl.period_date)"+
                                                           "  order by YEAR(sl.period_date) desc", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {


                if (string.IsNullOrEmpty(selected) == false)
                {
                    if (selected == db.rdr["result"].ToString())
                    {

                        item.Add(new SelectListItem { Text = db.rdr["result_th"].ToString(), Value = db.rdr["result"].ToString(), Selected=true });
                    }
                    else {

                        item.Add(new SelectListItem { Text = db.rdr["result_th"].ToString(), Value = db.rdr["result"].ToString() });

                    }

                }
                else {

                    if (i == 1)
                    {

                        item.Add(new SelectListItem { Text = db.rdr["result_th"].ToString(), Value = db.rdr["result"].ToString(), Selected=true });
                    }
                    else {

                        item.Add(new SelectListItem { Text = db.rdr["result_th"].ToString(), Value = db.rdr["result"].ToString() });
                    }

                  
                }

                i++;

            }
            db.dbClosed();

            return item;
        }

        public void get_max_period_date() {

            db.dbConnect();
            db.cmd = new System.Data.SqlClient.SqlCommand("select MAX(sl.period_date) as result from tab_emp_salary sl"+
                                                           " inner join tab_period_salary ps on ps.period_id = sl.period_id"+
                                                           " where sl.ep_id = '"+ep_id+"' and sl.event_status != 'D'", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {

                period_date = Convert.ToDateTime(db.rdr["result"]).ToString("yyyy-MM-dd", en);

            }
            db.dbClosed();

        }

        public List<periodModel> period_list()
        {

            List<periodModel> obj = new List<periodModel>();

            db.dbConnect();
            db.cmd = new System.Data.SqlClient.SqlCommand("select TOP 5 period_date, net_amount from tab_emp_salary sl" +
                                                          "  inner join tab_period_salary ps on ps.period_id = sl.period_id" +
                                                          "  where sl.ep_id = '" + ep_id + "'  and sl.event_status != 'D'" +
                                                          "  group by period_date, net_amount order by period_date desc", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                periodModel pd = new periodModel();

                pd.date_txt = Convert.ToDateTime(db.rdr["period_date"]).ToString("MMMM yyyy", th);
                pd.period_date = Convert.ToDateTime(db.rdr["period_date"]).ToString("yyyy-MM-dd", en);
                pd.net_amount = Convert.ToDouble(db.rdr["net_amount"]).ToString("0,0.00");

                obj.Add(pd);
            }
            db.dbClosed();


            return obj;
        }
        public void select_slip() {

            checkVal ck = new checkVal();

            db.dbConnect();
            db.cmd = new System.Data.SqlClient.SqlCommand("select s.ep_salary_id, s.ep_id, period_id,  s.period_date, s.comp_id, comp.T_Company as comp_name,  " +
                  "              s.ep_code, s.ep_name, s.comp_id, s.sect_id, s.dept_id, s.post_id, s.type_salary,                 "+
                  "              s.item_no, s.salary1_rate, s.salary2_rate, s.salary3_rate, s.income_sum, s.tax_sum,              "+
                  "              s.sso_sum, s.pvf_sum, s.income_total, s.minus_total, s.net_amount,                               "+
                  "              sect.section_code, dept.dept_code, sect.section_name, dept.dept_name,                            "+
                  "              sum(tmp.A01) as A01, sum(tmp.A02) as A02, sum(tmp.A03) as A03, sum(tmp.A04) as A04, sum(tmp.A05) as A05, "+
                  "              sum(tmp.A06) as A06, sum(tmp.A07) as A07, sum(tmp.A08) as A08, sum(tmp.A09) as A09, sum(tmp.A10) as A10, "+
                  "              sum(tmp.A11) as A11, sum(tmp.A12) as A12, sum(tmp.A13) as A13, sum(tmp.A14) as A14, sum(tmp.A15) as A15, "+
                  "              sum(tmp.D01) as D01, sum(tmp.D02) as D02, sum(tmp.D03) as D03, sum(tmp.D04) as D04, sum(tmp.D05) as D05, "+
                  "              sum(tmp.D06) as D06, sum(tmp.D07) as D07                                   "+
                  "   from tab_emp_salary s, tab_section sect, tab_department dept,  tab_company comp ,                        " +
                  "   (                                                                                     "+
                  "   select s_det.ep_salary_id,                                                            "+
                  "          case when s_det.sp_type_code = 'A01' then s_det.amount else 0 end as A01,      "+
                  "          case when s_det.sp_type_code = 'A02' then s_det.amount else 0 end as A02,      "+
                  "          case when s_det.sp_type_code = 'A03' then s_det.amount else 0 end as A03,      "+
                  "          case when s_det.sp_type_code = 'A04' then s_det.amount else 0 end as A04,      "+
                  "          case when s_det.sp_type_code = 'A05' then s_det.amount else 0 end as A05,      "+
                  "          case when s_det.sp_type_code = 'A06' then s_det.amount else 0 end as A06,      "+
                  "          case when s_det.sp_type_code = 'A07' then s_det.amount else 0 end as A07,      "+
                  "          case when s_det.sp_type_code = 'A08' then s_det.amount else 0 end as A08,      "+
                  "          case when s_det.sp_type_code = 'A09' then s_det.amount else 0 end as A09,      "+
                  "          case when s_det.sp_type_code = 'A10' then s_det.amount else 0 end as A10,      "+
                  "          case when s_det.sp_type_code = 'A11' then s_det.amount else 0 end as A11,      "+
                  "          case when s_det.sp_type_code = 'A12' then s_det.amount else 0 end as A12,      "+
                  "          case when s_det.sp_type_code = 'A13' then s_det.amount else 0 end as A13,      "+
                  "          case when s_det.sp_type_code = 'A14' then s_det.amount else 0 end as A14,      "+
                  "          case when s_det.sp_type_code = 'A15' then s_det.amount else 0 end as A15,      "+
                  "          case when s_det.sp_type_code = 'D01' then s_det.amount else 0 end as D01,      "+
                  "          case when s_det.sp_type_code = 'D02' then s_det.amount else 0 end as D02,      "+
                  "          case when s_det.sp_type_code = 'D03' then s_det.amount else 0 end as D03,      "+
                  "          case when s_det.sp_type_code = 'D04' then s_det.amount else 0 end as D04,      "+
                  "          case when s_det.sp_type_code = 'D05' then s_det.amount else 0 end as D05,      "+
                  "          case when s_det.sp_type_code = 'D06' then s_det.amount else 0 end as D06,      "+
                  "          case when s_det.sp_type_code = 'D07' then s_det.amount else 0 end as D07       "+
                  "   from tab_emp_salary_det s_det, tab_emp_salary salary                                  "+
                  "   where s_det.ep_salary_id = salary.ep_salary_id                                        "+
                  "     and salary.period_date = '"+period_date+"'                                               "+
                  "     and salary.ep_id = '"+ep_id+"'                                                       "+
                  "     and s_det.event_status <> 'D'                                                       "+
                  "     and salary.event_status <> 'D'                                                      "+
                  "     and s_det.sp_type_code <> 'D00'                                                     "+
                  "     and s_det.sp_type_code <> 'A00'                                                     "+
                  "   )tmp                                                                                  "+
                  "   where s.sect_id = sect.section_id                                                     "+
                  "     and s.dept_id = dept.dept_id                                                        "+
                  "     and s.ep_salary_id = tmp.ep_salary_id                                               "+
                  "     and s.period_date = '"+period_date+"'                                                    "+
                  "     and s.ep_id = '"+ep_id+"'                                                            "+
                  "     and s.event_status <> 'D'     and  comp.comp_id = s.comp_id                                                         " +
                  "     Group by s.ep_salary_id, s.ep_id, period_id,  s.period_date, s.comp_id,             "+
                  "                s.ep_code,  s.ep_name,  s.comp_id,  s.sect_id,  s.dept_id,  s.post_id, s.type_salary,"+
                  "                s.item_no,  s.salary1_rate,  s.salary2_rate,  s.salary3_rate,  s.income_sum,  s.tax_sum,"+
                  "                s.sso_sum,  s.pvf_sum,  s.income_total,  s.minus_total,  s.net_amount,"+
                  "               sect.section_code, dept.dept_code, sect.section_name, dept.dept_name, comp.T_Company " +
                  "   order by sect.section_code, dept.dept_code, s.sect_id,  s.dept_id, s.item_no, s.ep_code", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read()) {

               ep_salary_id  = db.rdr["ep_salary_id"].ToString();
               ep_id  = db.rdr["ep_id"].ToString(); 
               period_id  = db.rdr["period_id"].ToString();
               period_date  = Convert.ToDateTime(db.rdr["period_date"]).ToString("dd/MM/yyyy",th);
               comp_id  = db.rdr["comp_id"].ToString();

                if (comp_id == "1")
                {

                    logo = "logo_ma.bmp";
                }
                else if (comp_id == "2")
                {
                    logo = "logo_ks1.jpg";

                }
                else if (comp_id == "3") {

                    logo = "logo_nd.jpg";
                }


               comp_name = db.rdr["comp_name"].ToString();
               ep_code  = db.rdr["ep_code"].ToString();
               ep_name   = db.rdr["ep_name"].ToString();
               sect_id  = db.rdr["sect_id"].ToString();
               dept_id  = db.rdr["dept_id"].ToString();
               post_id  = db.rdr["post_id"].ToString();
               type_salary  = db.rdr["type_salary"].ToString();
               item_no  = db.rdr["item_no"].ToString();
               salary1_rate  = db.rdr["salary1_rate"].ToString();
               salary2_rate  = db.rdr["salary2_rate"].ToString();
               salary3_rate  = db.rdr["salary3_rate"].ToString();

               income_sum  = ck.check_num_summary(db.rdr["income_sum"].ToString());
               tax_sum  = ck.check_num_summary(db.rdr["tax_sum"].ToString());
               sso_sum  = ck.check_num_summary(db.rdr["sso_sum"].ToString());
               pvf_sum  = ck.check_num_summary(db.rdr["pvf_sum"].ToString());
               income_total  = ck.check_num_summary(db.rdr["income_total"].ToString());
               minus_total  = ck.check_num_summary(db.rdr["minus_total"].ToString());
               net_amount  = ck.check_num_summary(db.rdr["net_amount"].ToString());


               section_code  = db.rdr["section_code"].ToString();
               dept_code  = db.rdr["dept_code"].ToString();
               section_name  = db.rdr["section_name"].ToString();
               dept_name  = db.rdr["dept_name"].ToString();

               A01  = ck.check_zero_to_empty(db.rdr["A01"].ToString());
               A02  = ck.check_zero_to_empty(db.rdr["A02"].ToString());
               A03  = ck.check_zero_to_empty(db.rdr["A03"].ToString());
               A04  = ck.check_zero_to_empty(db.rdr["A04"].ToString());
               A05  = ck.check_zero_to_empty(db.rdr["A05"].ToString());
               A06  = ck.check_zero_to_empty(db.rdr["A06"].ToString());
               A07  = ck.check_zero_to_empty(db.rdr["A07"].ToString());
               A08  = ck.check_zero_to_empty(db.rdr["A08"].ToString());
               A09  = ck.check_zero_to_empty(db.rdr["A09"].ToString());
               A10  = ck.check_zero_to_empty(db.rdr["A10"].ToString());
               A11  = ck.check_zero_to_empty(db.rdr["A11"].ToString());
               A12  = ck.check_zero_to_empty(db.rdr["A12"].ToString());
               A13  = ck.check_zero_to_empty(db.rdr["A13"].ToString());
               A14  = ck.check_zero_to_empty(db.rdr["A14"].ToString());
               A15  = ck.check_zero_to_empty(db.rdr["A15"].ToString());
               D01  = ck.check_zero_to_empty(db.rdr["D01"].ToString());
               D02  = ck.check_zero_to_empty(db.rdr["D02"].ToString());
               D03  = ck.check_zero_to_empty(db.rdr["D03"].ToString());
               D04  = ck.check_zero_to_empty(db.rdr["D04"].ToString());
               D05  = ck.check_zero_to_empty(db.rdr["D05"].ToString());
               D06  = ck.check_zero_to_empty(db.rdr["D06"].ToString());
               D07 = ck.check_zero_to_empty(db.rdr["D07"].ToString());

            }
            db.dbClosed();

        }

    }
}
