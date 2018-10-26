using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RegMati.Models
{
    public class slipModel
    {
        public string file_name { get; set; }
        public string ep_id { get; set; }
        public string period_date { get; set; }

        public string ep_salary_id { get; set; }
        public string period_id { get; set; } 
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

        DataBaseClass db = new DataBaseClass();

        CultureInfo th = new CultureInfo("TH");
        CultureInfo en = new CultureInfo("EN");

        public void select_slip()
        {

            checkVal ck = new checkVal();

            db.dbConnect();
            db.cmd = new System.Data.SqlClient.SqlCommand("select s.ep_salary_id, s.ep_id, period_id,  s.period_date, s.comp_id, comp.T_Company as comp_name,  " +
                  "              s.ep_code, s.ep_name, s.comp_id, s.sect_id, s.dept_id, s.post_id, s.type_salary,                 " +
                  "              s.item_no, s.salary1_rate, s.salary2_rate, s.salary3_rate, s.income_sum, s.tax_sum,              " +
                  "              s.sso_sum, s.pvf_sum, s.income_total, s.minus_total, s.net_amount,                               " +
                  "              sect.section_code, dept.dept_code, sect.section_name, dept.dept_name,                            " +
                  "              sum(tmp.A01) as A01, sum(tmp.A02) as A02, sum(tmp.A03) as A03, sum(tmp.A04) as A04, sum(tmp.A05) as A05, " +
                  "              sum(tmp.A06) as A06, sum(tmp.A07) as A07, sum(tmp.A08) as A08, sum(tmp.A09) as A09, sum(tmp.A10) as A10, " +
                  "              sum(tmp.A11) as A11, sum(tmp.A12) as A12, sum(tmp.A13) as A13, sum(tmp.A14) as A14, sum(tmp.A15) as A15, " +
                  "              sum(tmp.D01) as D01, sum(tmp.D02) as D02, sum(tmp.D03) as D03, sum(tmp.D04) as D04, sum(tmp.D05) as D05, " +
                  "              sum(tmp.D06) as D06, sum(tmp.D07) as D07                                   " +
                  "   from tab_emp_salary s, tab_section sect, tab_department dept,  tab_company comp ,                        " +
                  "   (                                                                                     " +
                  "   select s_det.ep_salary_id,                                                            " +
                  "          case when s_det.sp_type_code = 'A01' then s_det.amount else 0 end as A01,      " +
                  "          case when s_det.sp_type_code = 'A02' then s_det.amount else 0 end as A02,      " +
                  "          case when s_det.sp_type_code = 'A03' then s_det.amount else 0 end as A03,      " +
                  "          case when s_det.sp_type_code = 'A04' then s_det.amount else 0 end as A04,      " +
                  "          case when s_det.sp_type_code = 'A05' then s_det.amount else 0 end as A05,      " +
                  "          case when s_det.sp_type_code = 'A06' then s_det.amount else 0 end as A06,      " +
                  "          case when s_det.sp_type_code = 'A07' then s_det.amount else 0 end as A07,      " +
                  "          case when s_det.sp_type_code = 'A08' then s_det.amount else 0 end as A08,      " +
                  "          case when s_det.sp_type_code = 'A09' then s_det.amount else 0 end as A09,      " +
                  "          case when s_det.sp_type_code = 'A10' then s_det.amount else 0 end as A10,      " +
                  "          case when s_det.sp_type_code = 'A11' then s_det.amount else 0 end as A11,      " +
                  "          case when s_det.sp_type_code = 'A12' then s_det.amount else 0 end as A12,      " +
                  "          case when s_det.sp_type_code = 'A13' then s_det.amount else 0 end as A13,      " +
                  "          case when s_det.sp_type_code = 'A14' then s_det.amount else 0 end as A14,      " +
                  "          case when s_det.sp_type_code = 'A15' then s_det.amount else 0 end as A15,      " +
                  "          case when s_det.sp_type_code = 'D01' then s_det.amount else 0 end as D01,      " +
                  "          case when s_det.sp_type_code = 'D02' then s_det.amount else 0 end as D02,      " +
                  "          case when s_det.sp_type_code = 'D03' then s_det.amount else 0 end as D03,      " +
                  "          case when s_det.sp_type_code = 'D04' then s_det.amount else 0 end as D04,      " +
                  "          case when s_det.sp_type_code = 'D05' then s_det.amount else 0 end as D05,      " +
                  "          case when s_det.sp_type_code = 'D06' then s_det.amount else 0 end as D06,      " +
                  "          case when s_det.sp_type_code = 'D07' then s_det.amount else 0 end as D07       " +
                  "   from tab_emp_salary_det s_det, tab_emp_salary salary                                  " +
                  "   where s_det.ep_salary_id = salary.ep_salary_id                                        " +
                  "     and salary.period_date = '" + period_date + "'                                               " +
                  "     and salary.ep_id = '" + ep_id + "'                                                       " +
                  "     and s_det.event_status <> 'D'                                                       " +
                  "     and salary.event_status <> 'D'                                                      " +
                  "     and s_det.sp_type_code <> 'D00'                                                     " +
                  "     and s_det.sp_type_code <> 'A00'                                                     " +
                  "   )tmp                                                                                  " +
                  "   where s.sect_id = sect.section_id                                                     " +
                  "     and s.dept_id = dept.dept_id                                                        " +
                  "     and s.ep_salary_id = tmp.ep_salary_id                                               " +
                  "     and s.period_date = '" + period_date + "'                                                    " +
                  "     and s.ep_id = '" + ep_id + "'                                                            " +
                  "     and s.event_status <> 'D'     and  comp.comp_id = s.comp_id                                                         " +
                  "     Group by s.ep_salary_id, s.ep_id, period_id,  s.period_date, s.comp_id,             " +
                  "                s.ep_code,  s.ep_name,  s.comp_id,  s.sect_id,  s.dept_id,  s.post_id, s.type_salary," +
                  "                s.item_no,  s.salary1_rate,  s.salary2_rate,  s.salary3_rate,  s.income_sum,  s.tax_sum," +
                  "                s.sso_sum,  s.pvf_sum,  s.income_total,  s.minus_total,  s.net_amount," +
                  "               sect.section_code, dept.dept_code, sect.section_name, dept.dept_name, comp.T_Company " +
                  "   order by sect.section_code, dept.dept_code, s.sect_id,  s.dept_id, s.item_no, s.ep_code", db.conn);
            db.rdr = db.cmd.ExecuteReader();
            while (db.rdr.Read())
            {

                ep_salary_id = db.rdr["ep_salary_id"].ToString();
                ep_id = db.rdr["ep_id"].ToString();
                period_id = db.rdr["period_id"].ToString();
                period_date = Convert.ToDateTime(db.rdr["period_date"]).ToString("dd/MM/yyyy", th);
                comp_id = db.rdr["comp_id"].ToString();

                if (comp_id == "1")
                {

                    logo = "logo_ma.bmp";
                }
                else if (comp_id == "2")
                {
                    logo = "logo_ks1.jpg";

                }
                else if (comp_id == "3")
                {

                    logo = "logo_nd.jpg";
                }


                comp_name = db.rdr["comp_name"].ToString();
                ep_code = db.rdr["ep_code"].ToString();
                ep_name = db.rdr["ep_name"].ToString();
                sect_id = db.rdr["sect_id"].ToString();
                dept_id = db.rdr["dept_id"].ToString();
                post_id = db.rdr["post_id"].ToString();
                type_salary = db.rdr["type_salary"].ToString();
                item_no = db.rdr["item_no"].ToString();
                salary1_rate = db.rdr["salary1_rate"].ToString();
                salary2_rate = db.rdr["salary2_rate"].ToString();
                salary3_rate = db.rdr["salary3_rate"].ToString();

                income_sum = ck.check_num_summary(db.rdr["income_sum"].ToString());
                tax_sum = ck.check_num_summary(db.rdr["tax_sum"].ToString());
                sso_sum = ck.check_num_summary(db.rdr["sso_sum"].ToString());
                pvf_sum = ck.check_num_summary(db.rdr["pvf_sum"].ToString());
                income_total = ck.check_num_summary(db.rdr["income_total"].ToString());
                minus_total = ck.check_num_summary(db.rdr["minus_total"].ToString());
                net_amount = ck.check_num_summary(db.rdr["net_amount"].ToString());


                section_code = db.rdr["section_code"].ToString();
                dept_code = db.rdr["dept_code"].ToString();
                section_name = db.rdr["section_name"].ToString();
                dept_name = db.rdr["dept_name"].ToString();

                A01 = ck.check_zero_to_empty(db.rdr["A01"].ToString());
                A02 = ck.check_zero_to_empty(db.rdr["A02"].ToString());
                A03 = ck.check_zero_to_empty(db.rdr["A03"].ToString());
                A04 = ck.check_zero_to_empty(db.rdr["A04"].ToString());
                A05 = ck.check_zero_to_empty(db.rdr["A05"].ToString());
                A06 = ck.check_zero_to_empty(db.rdr["A06"].ToString());
                A07 = ck.check_zero_to_empty(db.rdr["A07"].ToString());
                A08 = ck.check_zero_to_empty(db.rdr["A08"].ToString());
                A09 = ck.check_zero_to_empty(db.rdr["A09"].ToString());
                A10 = ck.check_zero_to_empty(db.rdr["A10"].ToString());
                A11 = ck.check_zero_to_empty(db.rdr["A11"].ToString());
                A12 = ck.check_zero_to_empty(db.rdr["A12"].ToString());
                A13 = ck.check_zero_to_empty(db.rdr["A13"].ToString());
                A14 = ck.check_zero_to_empty(db.rdr["A14"].ToString());
                A15 = ck.check_zero_to_empty(db.rdr["A15"].ToString());
                D01 = ck.check_zero_to_empty(db.rdr["D01"].ToString());
                D02 = ck.check_zero_to_empty(db.rdr["D02"].ToString());
                D03 = ck.check_zero_to_empty(db.rdr["D03"].ToString());
                D04 = ck.check_zero_to_empty(db.rdr["D04"].ToString());
                D05 = ck.check_zero_to_empty(db.rdr["D05"].ToString());
                D06 = ck.check_zero_to_empty(db.rdr["D06"].ToString());
                D07 = ck.check_zero_to_empty(db.rdr["D07"].ToString());

            }
            db.dbClosed();

        }

        public void creat_slip(string file_name) {


            select_slip();

            CreatePDF pdf = new CreatePDF();

            pdf.step0_setPageSize(PageSize.A5.Rotate(), -50f, -50f,-50f,-50f);
            pdf.step1_setFont();
            pdf.step2_setPathPdf("slip", file_name);
            pdf.step3_open_document();

            pdf.step4_create_table(new float[] { 100f });
            pdf.get_header_logo();
            
            pdf.document.Add(pdf.table);


            pdf.step4_create_table(new float[] { 10f, 40f, 20f, 20f });
            pdf.table.AddCell(pdf.getCell(" ชื่อพนักงาน", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(13), 1, 1, 0, 1, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(ep_code+" "+ep_name, 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell("ประจำวันที่", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(13), 1, 1, 0, 0, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(period_date, 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" ชื่อแผนก", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(13), 1, 0, 1, 1, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(dept_code+" "+dept_name+" "+section_code+" "+section_name+"", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 0, 1, 0, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell("ลำดับที่", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(13), 1, 0, 1, 0, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(item_no, 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 0, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));

            pdf.document.Add(pdf.table);

            pdf.document.Add(new Paragraph("  ", pdf.font_default(3f)));
 

            pdf.step4_create_table(new float[] {50f, 30f, 50f, 30f, 50f, 30f });
            pdf.table.AddCell(pdf.getCell("รายการเงินได้", 1, 0, 1, new CmykColor(1f, 0f, 0f, 0f), pdf.font_bold_white(16), 1, 1, 1, 1, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell("จำนวนเงิน", 1, 0, 1, new CmykColor(1f, 0f, 0f, 0f), pdf.font_bold_white(16), 1, 1, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell("รายการเงินได้", 1, 0, 1, new CmykColor(1f, 0f, 0f, 0f), pdf.font_bold_white(16), 1, 1, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell("จำนวนเงิน", 1, 0, 1, new CmykColor(1f, 0f, 0f, 0f), pdf.font_bold_white(16), 1, 1, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell("รายการเงินหัก", 1, 0, 1, new CmykColor(1f, 0f, 0f, 0f), pdf.font_bold(16), 1, 1, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell("จำนวนเงิน", 1, 0, 1, new CmykColor(1f, 0f, 0f,0f), pdf.font_bold(16), 1, 1, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            
            pdf.table.AddCell(pdf.getCell(" เงินเดือน", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0,1, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A01, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" ค่าเวร", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A09, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" ภาษีหัก ณ ที่จ่าย", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 0, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(D01, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            
            pdf.table.AddCell(pdf.getCell(" ค่าครองชีพ", 0, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A02, 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" ค่ารถ", 0, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A10, 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(D02, 0, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" ", 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            
            pdf.table.AddCell(pdf.getCell(" สวัสดิการอื่น", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A03, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" ค่าโทรศัพท์", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A11, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" เบี้ยประกันหมู่", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(D03, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            
            pdf.table.AddCell(pdf.getCell(" ค่าล่วงเวลา", 0, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A04, 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" โบนัส", 0, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A12, 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" เงินกองทุนสำรองเลี้ยงชีพ", 0, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(D04, 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            
            pdf.table.AddCell(pdf.getCell(" เบี้เลี้ยง/เบี้ยขยัน", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A05, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" เงินชดเชย", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A13, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" เงินกู้กองทุนพนักงาน", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(D05, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            
            pdf.table.AddCell(pdf.getCell(" ตกเบิก", 0, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A06, 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" เงินบำเหน็จ", 0, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A14, 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" ธนาคารอาคารสงเคราะห์", 0, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(D06, 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            
            pdf.table.AddCell(pdf.getCell(" ค่าคอมมิชชั่น", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A07, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" เงินได้อื่นๆ", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A15, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" เงินหักอื่นๆ", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(D07, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            
            pdf.table.AddCell(pdf.getCell(" ค่าเรื่อง/ซัพพลีเมนท์", 0, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 1, 1, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(A08, 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" รวมเงินได้ ", 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_bold(14), 1, 1, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(income_total, 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_bold(14), 1, 1, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" รวมเงินหัก ", 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_bold_blue_dark(14), 1, 1, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(minus_total, 2, 0, 1, new CmykColor(0.13f, 0f, 0f, 0f), pdf.font_bold(14), 1, 1, 1,0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));

             

            pdf.table.AddCell(pdf.getCell(" ", 2, 4, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(14), 1, 0, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(" รายได้สุทธิ", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(14), 1, 0, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            
            pdf.table.AddCell(pdf.getCell(net_amount, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(14), 1, 0, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));



            pdf.document.Add(pdf.table);
            pdf.document.Add(new Paragraph("  ", pdf.font_default(3f)));


            pdf.step4_create_table(new float[] { 15f, 15f, 15f, 15f, 15f, 15f });
            pdf.table.AddCell(pdf.getCell(" เงินได้สะสม", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 1, 0, 1, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(income_sum, 1, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell("ภาษีเงินได้สะสม", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 1, 0, 0, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(tax_sum, 1, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell("ประกันสังคมสะสม", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 1, 0, 0, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(sso_sum, 1, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));

            pdf.table.AddCell(pdf.getCell(" เงินกองทุนสำรองเลี้ยงชีพส่วนของพนักงานสะสม", 0, 2, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 0, 1, 1, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell(pvf_sum, 1, 2, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 0, 1, 0, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell("ผู้รับเงิน", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 0, 1, 0, 0, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));
            pdf.table.AddCell(pdf.getCell("__________________", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 0, 1, 0, 1, new CmykColor(1f, 0.18f, 0.0f, 0.01f)));

            pdf.document.Add(pdf.table);

            pdf.finally_document_close();


        }
        public void creat_slip_ks(string filename)
        {
            select_slip();

            CreatePDF pdf = new CreatePDF();

            pdf.step0_setPageSize(PageSize.A5.Rotate(), -50f, -50f, -50f, -50f);
            pdf.step1_setFont();
            pdf.step2_setPathPdf("slip", filename);
            pdf.step3_open_document();

            pdf.step4_create_table(new float[] { 100f });
            pdf.get_header_logo_ks();

            pdf.document.Add(pdf.table);


            pdf.step4_create_table(new float[] { 10f, 40f, 20f, 20f });
            pdf.table.AddCell(pdf.getCell(" ชื่อพนักงาน", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(13), 1, 1, 0, 1, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(ep_code+" "+ep_name+"", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell("ประจำวันที่", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(13), 1, 1, 0, 0, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(period_date, 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ชื่อแผนก", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(13), 1, 0, 1, 1, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(""+dept_code+" "+dept_name+" "+section_code+" "+section_name+"", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 0, 1, 0, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell("ลำดับที่", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(13), 1, 0, 1, 0, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(item_no, 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 0, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));

            pdf.document.Add(pdf.table);

            pdf.document.Add(new Paragraph("  ", pdf.font_default(3f)));


            pdf.step4_create_table(new float[] { 50f, 30f, 50f, 30f, 50f, 30f });
            pdf.table.AddCell(pdf.getCell("รายการเงินได้", 1, 0, 1, new CmykColor(0f, 0.5f, 0.7f, 0f), pdf.font_bold_white(16), 1, 1, 1, 1, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell("จำนวนเงิน", 1, 0, 1, new CmykColor(0f, 0.5f, 0.7f, 0f), pdf.font_bold_white(16), 1, 1, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell("รายการเงินได้", 1, 0, 1, new CmykColor(0f, 0.5f, 0.7f, 0f), pdf.font_bold_white(16), 1, 1, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell("จำนวนเงิน", 1, 0, 1, new CmykColor(0f, 0.5f, 0.7f, 0f), pdf.font_bold_white(16), 1, 1, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell("รายการเงินหัก", 1, 0, 1, new CmykColor(0f, 0.5f, 0.7f, 0f), pdf.font_bold(16), 1, 1, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell("จำนวนเงิน", 1, 0, 1, new CmykColor(0f, 0.5f, 0.7f, 0f), pdf.font_bold(16), 1, 1, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));

            pdf.table.AddCell(pdf.getCell(" เงินเดือน", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 1, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A01, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ค่าเวร", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A09, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ภาษีหัก ณ ที่จ่าย", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 0, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(D01, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));

            pdf.table.AddCell(pdf.getCell(" ค่าครองชีพ", 0, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A02, 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ค่ารถ", 0, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A10, 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ประกันสังคม", 0, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(D02, 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));

            pdf.table.AddCell(pdf.getCell(" สวัสดิการอื่น", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A03, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ค่าโทรศัพท์", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A11, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เบี้ยประกันหมู่", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(D03, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));

            pdf.table.AddCell(pdf.getCell(" ค่าล่วงเวลา", 0, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A04, 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" โบนัส", 0, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A12, 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เงินกองทุนสำรองเลี้ยงชีพ", 0, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A04, 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));

            pdf.table.AddCell(pdf.getCell(" เบี้เลี้ยง/เบี้ยขยัน", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A05, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เงินชดเชย", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A13, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เงินกู้กองทุนพนักงาน", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(D05, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));

            pdf.table.AddCell(pdf.getCell(" ตกเบิก", 0, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A06, 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เงินบำเหน็จ", 0, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A14, 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ธนาคารอาคารสงเคราะห์", 0, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(D06, 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));

            pdf.table.AddCell(pdf.getCell(" ค่าคอมมิชชั่น", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A07, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เงินได้อื่นๆ", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A15, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เงินหักอื่นๆ", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(D07, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));

            pdf.table.AddCell(pdf.getCell(" ค่าเรื่อง/ซัพพลีเมนท์", 0, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 1, 1, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(A08, 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_default(14), 1, 1, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" รวมเงินได้ ", 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_bold(14), 1, 1, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(income_total, 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_bold(14), 1, 1, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" รวมเงินหัก ", 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_bold_blue_dark(14), 1, 1, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(minus_total, 2, 0, 1, new CmykColor(0f, 0.2f, 0.2f, 0f), pdf.font_bold(14), 1, 1, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));



            pdf.table.AddCell(pdf.getCell(" ", 2, 4, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(14), 1, 0, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(" รายได้สุทธิ", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(14), 1, 0, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));

            pdf.table.AddCell(pdf.getCell(net_amount, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(14), 1, 0, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));



            pdf.document.Add(pdf.table);
            pdf.document.Add(new Paragraph("  ", pdf.font_default(3f)));


            pdf.step4_create_table(new float[] { 15f, 15f, 15f, 15f, 15f, 15f });
            pdf.table.AddCell(pdf.getCell(" เงินได้สะสม", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 1, 0, 1, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(income_sum, 1, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell("ภาษีเงินได้สะสม", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 1, 0, 0, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(tax_sum, 1, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell("ประกันสังคมสะสม", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 1, 0, 0, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(sso_sum, 1, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));

            pdf.table.AddCell(pdf.getCell(" เงินกองทุนสำรองเลี้ยงชีพส่วนของพนักงานสะสม", 0, 2, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 0, 1, 1, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell(pvf_sum, 1, 2, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 0, 1, 0, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell("ผู้รับเงิน", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 0, 1, 0, 0, new CmykColor(0f, 0.5f, 0.8f, 0f)));
            pdf.table.AddCell(pdf.getCell("__________________", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 0, 1, 0, 1, new CmykColor(0f, 0.5f, 0.8f, 0f)));

            pdf.document.Add(pdf.table);

            pdf.finally_document_close();


        }
        public void creat_slip_nd(string filename)
        {
            select_slip();
            CreatePDF pdf = new CreatePDF();

            pdf.step0_setPageSize(PageSize.A5.Rotate(), -50f, -50f, -50f, -50f);
            pdf.step1_setFont();
            pdf.step2_setPathPdf("slip", filename);
            pdf.step3_open_document();

            pdf.step4_create_table(new float[] { 100f });
            pdf.get_header_logo_nd();

            pdf.document.Add(pdf.table);


            pdf.step4_create_table(new float[] { 10f, 40f, 20f, 20f });
            pdf.table.AddCell(pdf.getCell(" ชื่อพนักงาน", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(13), 1, 1, 0, 1, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(ep_code+" "+ep_name+"", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell("ประจำวันที่", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(13), 1, 1, 0, 0, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(period_date, 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ชื่อแผนก", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(13), 1, 0, 1, 1, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(dept_code+" "+dept_name+" "+section_code+" "+section_name+"", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 0, 1, 0, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell("ลำดับที่", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(13), 1, 0, 1, 0, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(item_no, 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 0, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));

            pdf.document.Add(pdf.table);

            pdf.document.Add(new Paragraph("  ", pdf.font_default(3f)));


            pdf.step4_create_table(new float[] { 50f, 30f, 50f, 30f, 50f, 30f });
            pdf.table.AddCell(pdf.getCell("รายการเงินได้", 1, 0, 1, new CmykColor(0.5f, 0f, 0.4f, 0f), pdf.font_bold_white(16), 1, 1, 1, 1, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell("จำนวนเงิน", 1, 0, 1, new CmykColor(0.5f, 0f, 0.4f, 0f), pdf.font_bold_white(16), 1, 1, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell("รายการเงินได้", 1, 0, 1, new CmykColor(0.5f, 0f, 0.4f, 0f), pdf.font_bold_white(16), 1, 1, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell("จำนวนเงิน", 1, 0, 1, new CmykColor(0.5f, 0f, 0.4f, 0f), pdf.font_bold_white(16), 1, 1, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell("รายการเงินหัก", 1, 0, 1, new CmykColor(0.5f, 0f, 0.4f, 0f), pdf.font_bold(16), 1, 1, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell("จำนวนเงิน", 1, 0, 1, new CmykColor(0.5f, 0f, 0.4f, 0f), pdf.font_bold(16), 1, 1, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));

            pdf.table.AddCell(pdf.getCell(" เงินเดือน", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 1, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A01, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ค่าเวร", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A09, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ภาษีหัก ณ ที่จ่าย", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 0, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(D01, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 0, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));

            pdf.table.AddCell(pdf.getCell(" ค่าครองชีพ", 0, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A02, 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ค่ารถ", 0, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A10, 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ประกันสังคม", 0, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(D02, 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));

            pdf.table.AddCell(pdf.getCell(" สวัสดิการอื่น", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A03, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ค่าโทรศัพท์", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A11, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เบี้ยประกันหมู่", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(D03, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));

            pdf.table.AddCell(pdf.getCell(" ค่าล่วงเวลา", 0, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A04, 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" โบนัส", 0, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A12, 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เงินกองทุนสำรองเลี้ยงชีพ", 0, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(D04, 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));

            pdf.table.AddCell(pdf.getCell(" เบี้เลี้ยง/เบี้ยขยัน", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A05, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เงินชดเชย", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A13, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เงินกู้กองทุนพนักงาน", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(D05, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));

            pdf.table.AddCell(pdf.getCell(" ตกเบิก", 0, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A06, 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เงินบำเหน็จ", 0, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A14, 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" ธนาคารอาคารสงเคราะห์", 0, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(D06, 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));

            pdf.table.AddCell(pdf.getCell(" ค่าคอมมิชชั่น", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 1, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A07, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เงินได้อื่นๆ", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A15, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" เงินหักอื่นๆ", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default_blue(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(D07, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(14), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));

            pdf.table.AddCell(pdf.getCell(" ค่าเรื่อง/ซัพพลีเมนท์", 0, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 1, 1, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(A08, 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_default(14), 1, 1, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" รวมเงินได้ ", 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_bold(14), 1, 1, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(income_total, 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_bold(14), 1, 1, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" รวมเงินหัก ", 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_bold_blue_dark(14), 1, 1, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(minus_total, 2, 0, 1, new CmykColor(0.25f, 0f, 0.1f, 0f), pdf.font_bold(14), 1, 1, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));



            pdf.table.AddCell(pdf.getCell(" ", 2, 4, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(14), 1, 0, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(" รายได้สุทธิ", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(14), 1, 0, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));

            pdf.table.AddCell(pdf.getCell(net_amount, 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_bold(14), 1, 0, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));



            pdf.document.Add(pdf.table);
            pdf.document.Add(new Paragraph("  ", pdf.font_default(3f)));


            pdf.step4_create_table(new float[] { 15f, 15f, 15f, 15f, 15f, 15f });
            pdf.table.AddCell(pdf.getCell(" เงินได้สะสม", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 1, 0, 1, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(income_sum, 1, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell("ภาษีเงินได้สะสม", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 1, 0, 0, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(tax_sum, 1, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell("ประกันสังคมสะสม", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 1, 0, 0, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(sso_sum, 1, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 1, 0, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));

            pdf.table.AddCell(pdf.getCell(" เงินกองทุนสำรองเลี้ยงชีพส่วนของพนักงานสะสม", 0, 2, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 0, 1, 1, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell(pvf_sum, 1, 2, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_under_line(13), 1, 0, 1, 0, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell("ผู้รับเงิน", 2, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 0, 1, 0, 0, new CmykColor(0.6f, 0f, 0.5f, 0f)));
            pdf.table.AddCell(pdf.getCell("__________________", 0, 0, 1, new CmykColor(0f, 0f, 0f, 0f), pdf.font_default(13), 1, 0, 1, 0, 1, new CmykColor(0.6f, 0f, 0.5f, 0f)));

            pdf.document.Add(pdf.table);

            pdf.finally_document_close();


        }

    }
}
