using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RegMati.Models
{
    public class mdModel
    {
        public string txt { get; set; }
        
        public string md { get; set; }


        public void ConvertMd5() {


            dbFile db = new dbFile();

            using (SqlConnection conn = new SqlConnection(db.sqlConnection)) {

                conn.Open();

                SqlCommand cmd = new SqlCommand("Select CONVERT(VARCHAR(32), HashBytes('MD5', '"+txt+"'), 2) as MD5Hash", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {

                    md = rdr["MD5Hash"].ToString();
                    
                }
                
                conn.Close();
            }


        }

    }
}
