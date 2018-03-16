using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace 解析患者列表
{
    public class save
    {
       public void SaveDate()
        {
            string conn = "Data Source=CANDY;Initial Catalog=Patient;Persist Security Info=True;User ID=sa;Password=123456";
            SqlConnection SqlConn = new SqlConnection(conn);

            try
            {
                string sql = "select * from Data";

                SqlConn.Open();
                SqlCommand cmd = new SqlCommand(sql, SqlConn);
                int r = cmd.ExecuteNonQuery();
                Console.WriteLine(r);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(SqlConn.State==ConnectionState.Open)
                {
                    SqlConn.Close();
                }
            }
        }
    }
}
