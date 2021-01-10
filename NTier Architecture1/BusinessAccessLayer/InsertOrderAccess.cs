using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccsessLayer
{
    public class InsertOrderAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public DataTable InsertOrders()
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "Insert Into OrdersOfTheCustomers(Order_No,Purchase_amount,OrderDate,Customer_ID,Salesman_Id)values(@Order_No,@Purchase_amount,@OrderDate,@Customer_ID,@Salesman_Id)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    Console.WriteLine("Enter Order_No,Purchase_amount,OrderDate,Customer_ID,Salesman_Id ");
                    int Order_No = int.Parse(Console.ReadLine());
                    int Purchase_amount = int.Parse(Console.ReadLine());
                    string OrderDate = Console.ReadLine();
                    int Customer_ID = int.Parse(Console.ReadLine());
                    int Salesman_Id = int.Parse(Console.ReadLine());
                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    //conn.Close();
                    cmd.Parameters.AddWithValue("@Order_No", Order_No);
                    cmd.Parameters.AddWithValue("@Purchase_amount", Purchase_amount);
                    cmd.Parameters.AddWithValue("@OrderDate", OrderDate);
                    cmd.Parameters.AddWithValue("@Customer_ID", Customer_ID);
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
