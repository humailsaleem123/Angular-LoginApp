using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;
using DataTable = System.Data.DataTable;

namespace LoginApii.Models
{
    public class GetExcelData
    {
        public DataTable Import_To_Datatable(string FilePath, string Extension, string isHDR, string conStr)
        {
            conStr = String.Format(conStr, FilePath, isHDR);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();

            DataTable dt = new DataTable();

            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet  

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();

            //Read Data from First Sheet  

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;

            oda.Fill(dt);

            connExcel.Close();

            return dt;
            //Bind Data to GridView  

        }
    }
}
