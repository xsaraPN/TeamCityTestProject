using Dapper;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Data;
using System.IO;
using NUnit.Framework;
using System.Collections.Specialized;

namespace Registration.Models
{
    public static class AccessExcelData
    {        
        public static string TestDataFileConnection()
        {
            // var path = (ConfigurationManager.GetSection("path") as NameValueCollection).Get("TestDataSheetPath");
            var path = AppDomain.CurrentDomain.BaseDirectory + (ConfigurationManager.GetSection("path") as NameValueCollection).Get("TestDataSheetPath");
            var connections = ConfigurationManager.ConnectionStrings[@"Excel_OLEDB"].ConnectionString;
            var filename = ConfigurationManager.AppSettings["filename"]; 
            var con = string.Format(@connections, path + filename);
            return con;
        }

        public static SoftUniUser GetTestDataSoftUniUser(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where Key = '{0}'", keyName);
                var value = connection.Query<SoftUniUser>(query).FirstOrDefault();
                connection.Close();               
                return value;
            }
        }

        public static RegistrationUser GetTestDataRegUser(string keyNameMartialStatus, string keyNameHobby, string keyNameRest)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();               
                RegistrationUser regUser = new RegistrationUser();
                if (keyNameHobby!=null)
                {                    
                    var hobby_query = string.Format("select * from [RegistrationForm_Hobby$] where Key = '{0}'", keyNameHobby);                    
                    OleDbDataAdapter oleDB = new OleDbDataAdapter(hobby_query, connection);                   
                    DataTable dtOleDB = new DataTable();                    
                    oleDB.Fill(dtOleDB);
                    
                    foreach (DataRow row in dtOleDB.Rows)
                    {
                        string[] hobby = new string[dtOleDB.Rows.Count];
                        for (int m = 0; m < hobby.Length; m++)
                            hobby[m] = dtOleDB.Rows[m]["Hobby"].ToString();
                        int[] int_hobby = new int[dtOleDB.Rows.Count];
                        for (int i = 0; i < hobby.Length; i++)
                            int_hobby[i] = int.Parse(hobby[i]);
                        regUser.Hobby = int_hobby;
                    }
                }

                var martialstatus_query = string.Format("select * from [RegistrationForm_MartialStatus$] where Key = '{0}'", keyNameMartialStatus);
                var rest_query = string.Format("select * from [RegistrationFormTests$] where Key = '{0}'", keyNameRest);
                OleDbDataAdapter oleDA = new OleDbDataAdapter(martialstatus_query, connection);
                OleDbDataAdapter oleDC = new OleDbDataAdapter(rest_query, connection);
                DataTable dtOleDA = new DataTable();
                DataTable dtOleDC = new DataTable();
                oleDA.Fill(dtOleDA);
                oleDC.Fill(dtOleDC);

                foreach (DataRow row in dtOleDA.Rows)
                {
                    string[] martial = new string[dtOleDA.Rows.Count];
                    for (int m = 0; m < martial.Length; m++)
                        martial[m] = dtOleDA.Rows[m]["MartialStatus"].ToString();
                    int[] int_martial = new int[dtOleDA.Rows.Count];
                    for (int i = 0; i < martial.Length; i++)
                        int_martial[i] = int.Parse(martial[i]);
                    regUser.MatrialStatus = int_martial;
                }

                foreach (DataRow row in dtOleDC.Rows)
                    {
                        regUser.FirstName = row["FirstName"].ToString();
                        regUser.LastName = row["LastName"].ToString();
                        regUser.Country = row["Country"].ToString();
                        regUser.BirthMonth = row["BirthMonth"].ToString();
                        regUser.BirthDay = row["BirthDay"].ToString();
                        regUser.BirthYear = row["BirthYear"].ToString();
                        regUser.Phone = row["Phone"].ToString();
                        regUser.UserName = row["UserName"].ToString();
                        regUser.Email = row["Email"].ToString();
                        regUser.UploadPicDir = row["UploadPicDir"].ToString();
                        regUser.Description = row["Description"].ToString();
                        regUser.Password = row["Password"].ToString();
                        regUser.ConfirmPassword = row["ConfirmPassword"].ToString();
                    }
                
            connection.Close();
             return regUser;
            }
        }

        public static string[] GetTestDataPasswordRegUser(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                RegistrationUser regUser = new RegistrationUser();

                var query = string.Format("select Password from [RegistrationFormTests$] where Key = '{0}'", keyName);
                OleDbDataAdapter oleDC = new OleDbDataAdapter(query, connection);                
                DataTable dtOleDC = new DataTable();               
                oleDC.Fill(dtOleDC);

                string[] password = new string[dtOleDC.Rows.Count];

                foreach (DataRow row in dtOleDC.Rows)
                {
                    
                    for (int m = 0; m < password.Length; m++)
                        password[m] = dtOleDC.Rows[m]["Password"].ToString();                    
                }
               
                return password;
            }
        }

    }
}
