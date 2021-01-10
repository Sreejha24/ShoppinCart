using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccsessLayer
{
    public class UpdateOrderAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public DataTable UpdateOrder()
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "update OrdersOfTheCustomers set Order_No=@Order_No,Purchase_amount=@Purchase_amount,OrderDate=@OrderDate,Customer_ID=@Customer_ID,Salesman_Id=@Salesman_Id  where Customer_ID=@Customer_ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {


                    Console.WriteLine("Enter Order_No,Purchase_amount,OrderDate,Customer_ID,Salesman_Id ");
                    int Order_No = int.Parse(Console.ReadLine());
                    long Purchase_amount = long.Parse(Console.ReadLine());
                    string OrderDate = Console.ReadLine();
                    int Customer_ID = int.Parse(Console.ReadLine());
                    int Salesman_Id = int.Parse(Console.ReadLine());
                    conn.Open();

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
