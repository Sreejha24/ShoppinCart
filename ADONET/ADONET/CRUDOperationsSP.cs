using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADONET
{
    public class CRUDOperationsSP
    {
        private string connectionstring;
        private SqlConnection conn;
        public CRUDOperationsSP()
        {
            connectionstring = "Data Source=192.168.50.95;Initial Catalog=sprathipati;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            conn = new SqlConnection(connectionstring);
        }
        public void InsertOperationSP()
        {

            Console.WriteLine("Enter Employee Stored Procedure Details");
            int EmpID = int.Parse(Console.ReadLine());
            string EmpName = Console.ReadLine();
            decimal salary = decimal.Parse(Console.ReadLine());
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_CreateEmployeeDetails", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            cmd.Parameters.AddWithValue("@EmpName", EmpName);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void InsertOperationSPEH()
        {
            conn.Open();
            var transaction = conn.BeginTransaction();
            try
            {
                Console.WriteLine("Enter Employee Stored Procedure Details");
                int EmpID = int.Parse(Console.ReadLine());
                string EmpName = Console.ReadLine();
                decimal salary = decimal.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand("usp_CreateEmployeeDetails", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", EmpID);
                cmd.Parameters.AddWithValue("@EmpName", EmpName);
                cmd.Parameters.AddWithValue("@salary", salary);
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



//---------------------------------------------------------------------------------
//    USE[sprathipati]
//GO
///****** Object:  StoredProcedure [dbo].[usp_CreateEmployeeDetails]    Script Date: 09-01-2021 21:00:14 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//ALTER procedure [dbo].[usp_CreateEmployeeDetails]
//@EmpID as int,
//	@EmpName as nvarchar(50),
//	@salary as money
//as
//begin

//    insert into EmployeeDetails(EmpID, EmpName, salary) values(@EmpID, @EmpName, @salary)
//      --delete EmployeesDetails  where  EmpID=1512 
//	--delete  EmployeeDetails  where  EmpID=1510

//	UPDATE EmployeeDetails SET EmpName=@EmpName, salary = @salary WHERE EmpID=@EmpID
//end