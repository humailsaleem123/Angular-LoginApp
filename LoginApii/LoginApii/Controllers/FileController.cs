using ExcelDataReader;
using LoginApii.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.Http.Headers;
using System.Security.Policy;
using DataTable = System.Data.DataTable;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace File.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IConfiguration _config;
        public FileController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public JsonResult UploadSingle(string filepath)
        {

            //DataTable myTable;
            //Application excelApp = new Application();
            //DataRow myNewRow;
            //string dirName = AppDomain.CurrentDomain.BaseDirectory;
            //string FilePath = "test.xlsx";

            //if (excelApp == null)
            //{
            //    Console.WriteLine("Excel is not installed!!");

            //}

            ////
            //Workbook excelBook = excelApp.Workbooks.Open(FilePath);
            //_Worksheet excelSheet = (_Worksheet)excelBook.Sheets[1];
            //Range excelRange = excelSheet.UsedRange;

            //int rows = excelRange.Rows.Count;
            //int cols = excelRange.Columns.Count;

            ////Set DataTable Name and Columns Name
            //myTable = new DataTable("MyDataTable");
            //myTable.Columns.Add("FirstName", typeof(string));
            //myTable.Columns.Add("LastName", typeof(string));
            //myTable.Columns.Add("Age", typeof(int));

            //for (int i = 2; i <= rows; i++)
            //{
            //    myNewRow = myTable.NewRow();
            //    myNewRow["FirstName"] = excelRange.Cells[i, 1].ToString(); //string
            //    myNewRow["LastName"] = excelRange.Cells[i, 2].ToString(); //string
            //    myNewRow["Age"] = Convert.ToInt32(excelRange.Cells[i, 3].ToString()); //integer

            //    myTable.Rows.Add(myNewRow);
            //}

            //foreach (DataRow dr in myTable.Rows)
            //{
            //    Console.WriteLine("First Name : {0}\t Last Name : {1} \t Age : {2} \t", dr[0], dr[1], dr[2]);
            //}


            ////after reading, relaase the excel project
            //excelApp.Quit();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            //Console.ReadLine();
            
            DataTable custTable = new DataTable("Customers");
            DataColumn dtColumn;
            DataRow myDataRow;

            // Create id column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "id";
            dtColumn.Caption = "Cust ID";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = true;
            // Add column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);

            // Create Name column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Name";
            dtColumn.Caption = "Cust Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);

            // Create Address column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Address";
            dtColumn.Caption = "Address";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);

            // Make id column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = custTable.Columns["id"];
            custTable.PrimaryKey = PrimaryKeyColumns;

            // Create a new DataSet
            DataSet dtSet = new DataSet();

            // Add custTable to the DataSet.
            dtSet.Tables.Add(custTable);

            // Add data rows to the custTable using NewRow method
            // I add three customers with their addresses, names and ids
            myDataRow = custTable.NewRow();
            myDataRow["id"] = 1001;
            myDataRow["Address"] = "43 Lanewood Road, cito, CA";
            myDataRow["Name"] = "George Bishop";
            custTable.Rows.Add(myDataRow);
            myDataRow = custTable.NewRow();
            myDataRow["id"] = 1002;
            myDataRow["name"] = "Rock joe";
            myDataRow["Address"] = " kind of Prussia, PA";
            custTable.Rows.Add(myDataRow);
            myDataRow = custTable.NewRow();
            myDataRow["id"] = 1003;
            myDataRow["Name"] = "Miranda";
            myDataRow["Address"] = "279 P. Avenue, Bridgetown, PA";
            custTable.Rows.Add(myDataRow);


            //DataTable dt = (DataTable)objex.Import_To_Datatable(FilePath, fi.Extension, "Yes", conStr);
            return new JsonResult(custTable);
            //return Ok(new { status = "success" });
        }

        //[HttpGet]
        //public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        //{
        //    long size = files.Sum(f => f.Length);
           
        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            var filePath = Path.GetTempFileName();

        //            using (var stream = System.IO.File.Create(filePath))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }

        //   // Process uploaded files
        //   // Don't rely on or trust the FileName property without validation.
        //    DataTable myTable;
        //    Application excelApp = new Application();
        //    DataRow myNewRow;

        //    string FilePath = "";

        //    if (excelApp == null)
        //    {
        //        Console.WriteLine("Excel is not installed!!");

        //    }

        //    //
        //    Workbook excelBook = excelApp.Workbooks.Open(FilePath);
        //    _Worksheet excelSheet = (_Worksheet)excelBook.Sheets[1];
        //    Range excelRange = excelSheet.UsedRange;

        //    int rows = excelRange.Rows.Count;
        //    int cols = excelRange.Columns.Count;

        //    //Set DataTable Name and Columns Name
        //    myTable = new DataTable("MyDataTable");
        //    myTable.Columns.Add("FirstName", typeof(string));
        //    myTable.Columns.Add("LastName", typeof(string));
        //    myTable.Columns.Add("Age", typeof(int));



        //    //first row using for heading, start second row for data
        //    for (int i = 2; i <= rows; i++)
        //    {
        //        myNewRow = myTable.NewRow();
        //        myNewRow["FirstName"] = excelRange.Cells[i, 1].ToString(); //string
        //        myNewRow["LastName"] = excelRange.Cells[i, 2].ToString(); //string
        //        myNewRow["Age"] = Convert.ToInt32(excelRange.Cells[i, 3].ToString()); //integer

        //        myTable.Rows.Add(myNewRow);
        //    }

        //    foreach (DataRow dr in myTable.Rows)
        //    {
        //        Console.WriteLine("First Name : {0}\t Last Name : {1} \t Age : {2} \t", dr[0], dr[1], dr[2]);
        //    }


        //    //after reading, relaase the excel project
        //    excelApp.Quit();
        //    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        //    Console.ReadLine();




        //    //DataTable dt = (DataTable)objex.Import_To_Datatable(FilePath, fi.Extension, "Yes", conStr);
        //    // return new JsonResult(myTable);

        //    return Ok(new { count = files.Count, size });
        //}

        
       
    }
}
