using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegMati.Models
{
    public class checkVal
    {
        public string check_zero_to_empty(string txt) {

            string result = "";

            if (string.IsNullOrEmpty(txt) == false)
            {
                if (txt == "0")
                {

                    result = "";
                }
                else {

                    result = Convert.ToDouble(txt).ToString("0,0.00");
                       
                }

            }
            else {

                result = "";
            }

            return result;
        }
        public string check_num_summary(string txt) {

            string result = "";

            if (string.IsNullOrEmpty(txt) == false)
            {

                result = Convert.ToDouble(txt).ToString("0,0.00");
            }
            else {

                txt = "0";

                result = Convert.ToDouble(txt).ToString("0,0.00");

            }


            return result;
        }
    }
}
