using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace 不带登录的自动下载
{
    public class DButil
    {
        public int save(string sql,SqlParameter[] parameters)
        {
            string conn = "Data Source=CANDY;Initial Catalog=Patient;Persist Security Info=True;User ID=sa;Password=123456";
            SqlConnection SqlConn = new SqlConnection(conn);
            int result = -1;
            try
            {
                SqlConn.Open();
                SqlCommand cmd = new SqlCommand(sql, SqlConn);
                if(parameters!=null&&parameters.Length>0)
                {
                    foreach(SqlParameter p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                }

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (SqlConn.State == ConnectionState.Open)
                {
                    SqlConn.Close();
                }
            }
            return result;
        }
    }
}
