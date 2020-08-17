//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using System.Data;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Data.OleDb;
//using System.IO;
//using Microsoft.Data.SqlClient;


//namespace ITL_MakeId.Web.Controllers
//{
//    public class ExcelFileImportController : Controller
//    {
//        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

//        OleDbConnection Econ;

//        private void ExcelConn(string filepath)

//        {

//            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);

//            Econ = new OleDbConnection(constr);



//        }

//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
