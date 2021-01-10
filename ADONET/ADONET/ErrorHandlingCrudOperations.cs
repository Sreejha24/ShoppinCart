using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADONET
{
    public class ErrorHandlingCrudOperations
    {
        private string connectionstring;
        private SqlConnection conn;
        public ErrorHandlingCrudOperations()
        {
            connectionstring = "Data Source=192.168.50.95;Initial Catalog=sprathipati;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            conn = new SqlConnection(connectionstring);
        }
        public void CreateOperation()
        {
            conn.Open();
            var sql = "Select EmployeeID, FirstName, LastName,Email,City,Mobile From Employees";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine(dataReader["EmployeeID"] + "\t" + dataReader["FirstName"] + "\t" + dataReader["LastName"] + "\t" + dataReader["Email"] + "\t" + dataReader["City"] + "\t" + dataReader["Mobile"]);
            }
            conn.Close();
        }
        public void InsertOperation()
        {
            conn.Open();
            var transaction = conn.BeginTransaction();
            try
            {
                Console.WriteLine("ErrorHandling Create Details:");
                //int EmployeeID = int.Parse(Console.ReadLine());
                string FirstName = Console.ReadLine();
                string LastName = Console.ReadLine();
                string Email = Console.ReadLine();
                string City = Console.ReadLine();
                long Mobile = long.Parse(Console.ReadLine());
                
                var sql = "Insert Into Employees Values (@FirstName, @LastName, @Email, @City, @Mobile)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@EmployeeID",EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Mobile", Mobile);
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                conn.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Error Occured" + ex.Message);
            }
            finally
            {
                transaction.Dispose();
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

        }
        public void UpdateOperation()
        {
            conn.Open();
            var transaction = conn.BeginTransaction();
            try
            {
                Console.WriteLine("ErrorHandling Update Details:");
                //int EmployeeID = int.Parse(Console.ReadLine());
                string FirstName = Console.ReadLine();
                string LastName = Console.ReadLine();
                //string Email = Console.ReadLine();
                //string City = Console.ReadLine();
                //long Mobile = long.Parse(Console.ReadLine());
               
                var sql = "Update Employees set LastName = @LastName where FirstName = @FirstName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@EmployeeID",EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                //cmd.Parameters.AddWithValue("@Email", Email);
                //cmd.Parameters.AddWithValue("@City", City);
                //cmd.Parameters.AddWithValue("@Mobile", Mobile);
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                conn.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Error Occured" + ex.Message);
            }
            finally
            {
                transaction.Dispose();
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
        public void DeleteOperation()
        {
            conn.Open();
            var transaction = conn.BeginTransaction();
            try
            {
                Console.WriteLine("ErrorHandling Delete Details:");
                //int EmployeeID = int.Parse(Console.ReadLine());
                string FirstName = Console.ReadLine();
                string LastName = Console.ReadLine();
                //string Email = Console.ReadLine();
                //string City = Console.ReadLine();
                //long Mobile = long.Parse(Console.ReadLine());
                
                var sql = "Delete from Employees where FirstName = @FirstName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@EmployeeID",EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                //cmd.Parameters.AddWithValue("@Email", Email);
                //cmd.Parameters.AddWithValue("@City", City);
                //cmd.Parameters.AddWithValue("@Mobile", Mobile);
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                conn.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Error Occured" + ex.Message);
            }
            finally
            {
                transaction.Dispose();
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
