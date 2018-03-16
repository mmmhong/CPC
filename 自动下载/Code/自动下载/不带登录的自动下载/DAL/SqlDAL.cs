using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace 不带登录的自动下载.DAL
{
    public class SqlDAL
    {
        public void SaveId(List<string> list)
        {
            DButil db = new DButil();
           // string clear = @"truncate table PatientID";
            //db.save(clear, null);
            string sql = @"INSERT INTO Patient
                           (PatientID)
                           VALUES(@ID)";
            foreach (string s in list)
            {
                int result = 0;
                SqlParameter[] parameters =
                {
                    new SqlParameter("ID",s)
                };
                result = db.save(sql, parameters);
            }
        }

        public void SaveField(List<KeyValuePair<string, string>> list, string recoedName)
        {
            DButil db = new DButil();
            string sql = @"INSERT INTO FieldTable
                           (Name, RecordID)
                           SELECT  @Value AS Expr1, TypeID
                           FROM      RecordType
                           WHERE   (RecordName = @Name)";
            foreach (KeyValuePair<string, string> k in list)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("Value",k.Key),
                    new SqlParameter("Name",recoedName)
                };
                db.save(sql, parameters);
            }

        }

        public void SaveData(List<KeyValuePair<string, string>> list, string id, string recordName)
        {
            DButil db = new DButil();
            string sql = @"INSERT INTO Data
                           (FieldValue, PatientID, FieldID)
                           SELECT @FieldValue AS Expr1, @PID  AS Expr2, ID
                           FROM      FieldTable
                           WHERE  (Name = @FieldName ) AND (RecordID =
                           (SELECT  TypeID
                           FROM  RecordType
                           WHERE (RecordName = @RecordName)))";
            foreach (KeyValuePair<string, string> k in list)
            {
                string str = k.Value == null ? "" : k.Value;
                SqlParameter[] parameters =
                {
                    new SqlParameter("FieldValue",str),
                    new SqlParameter("PID",id),
                    new SqlParameter("FieldName",k.Key),
                    new SqlParameter("RecordName",recordName)
                };
                db.save(sql, parameters);
            }
        }
    }
}
