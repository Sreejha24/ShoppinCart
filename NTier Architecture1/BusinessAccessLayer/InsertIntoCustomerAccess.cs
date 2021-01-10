using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccsessLayer
{
    public class InsertIntoCustomerAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public DataTable InsertCustomers()
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "Insert Into Customerss(Customer_ID,Customer_name,City,Grade,Salesman_Id)values(@Customer_ID,@Customer_name,@City,@Grade,@Salesman_Id)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {


                    Console.WriteLine("Enter Customer_ID, Customer_name,City,Grade,Salesman_Id");
                    int Customer_ID = int.Parse(Console.ReadLine());
                    string Customer_name = Console.ReadLine();
                    string City = Console.ReadLine();
                    string Grade = Console.ReadLine();
                    int Salesman_Id = int.Parse(Console.ReadLine());
                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    //conn.Close();
                    cmd.Parameters.AddWithValue("@Customer_Id", Customer_ID);
                    cmd.Parameters.AddWithValue("@Customer_Name", Customer_name);
                    cmd.Parameters.AddWithValue("@City", City);
                    cmd.Parameters.AddWithValue("@Grade", Grade);
                    cmd.Parameters.AddWithValue("@Salesman_Id", Salesman_Id);
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(table);
                    }
                }
            }

            return table;
        }
    }
}
