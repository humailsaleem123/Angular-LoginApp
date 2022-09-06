using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace LoginApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public JsonResult Get(string username ,string password)
        {
            Debug.WriteLine(username);
            Debug.WriteLine(password);

            DataTable table = new DataTable();
            string sqlDataSource = _config.GetConnectionString("DefaultConnection");

            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {
               // if (myConn.State == ConnectionState.Open)
                 //   myConn.Close();

                myConn.Open();



                //string query = "SELECT username,password FROM usersList where username='" + username + "'and password ='" + password + "' ";
               // users @username = " + username + ", @password = " + password + " "
                using (SqlCommand myCommand = new SqlCommand("users", myConn))
                {

              
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@username", username);
                    myCommand.Parameters.AddWithValue("@password", password);
                    myCommand.Parameters.AddWithValue("@Query", 1);
                    // myCommand.ExecuteNonQuery();

                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();


                }
            }

            return new JsonResult(table);
        }

        [HttpGet("/allData")]
        public JsonResult Get()
        {

            DataTable tablee = new DataTable();

            string sqlDataSource = _config.GetConnectionString("DefaultConnection");

            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {


                myConn.Open();



               // string query = "SELECT * FROM usersList";


                using (SqlCommand myCommand = new SqlCommand("users", myConn))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                   myCommand.Parameters.AddWithValue("@Query", 2);
                    myReader = myCommand.ExecuteReader();

                    tablee.Load(myReader);

                    myReader.Close();
                    myConn.Close();


                }
            }

            return new JsonResult(tablee);
        }


        [HttpPost("/postData")]
        public JsonResult Post(usersInfo UsersInfo) 
        {
            // Debug.WriteLine(username);
            //Debug.WriteLine(password);
            
           // string query = @"INSERT INTO usersList VALUES('"+UsersInfo.Username+"','"+UsersInfo.Password+@"')";

            DataTable table = new DataTable();

            string sqlDataSource = _config.GetConnectionString("DefaultConnection");

            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDataSource))
            {


                myConn.Open();






                using (SqlCommand myCommand = new SqlCommand("users", myConn))
                {

                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@username", UsersInfo.Username);
                    myCommand.Parameters.AddWithValue("@password", UsersInfo.Password);
                   myCommand.Parameters.AddWithValue("@Query", 3);
                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);

                    myReader.Close();
                    myConn.Close();


                }
            }

            return new JsonResult("Added Successfully!!!");
        }

    }
}
