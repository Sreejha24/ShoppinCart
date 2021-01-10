using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccsessLayer
{
    public class CustomerssDataAccessDetails
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public DataTable FindCustomerDetails(int customer_ID)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Customerss where customer_ID = @Customer_ID";
                using (SqlCommand cmd = new SqlCommand(sql,connection))
                {
                    cmd.Parameters.AddWithValue("@Customer_ID", customer_ID);
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
    }
}











//--------------------------------------------------------------------------------------------------

//    USE[sprathipati]
//GO

///****** Object:  Table [dbo].[Customerss]    Script Date: 09-01-2021 21:44:40 ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[Customerss](

//[Customer_ID][int] NOT NULL,

//[Customer_name] [varchar](50) NULL,
//	[City] [varchar](50) NULL,
//	[Grade] [varchar](40) NULL,
//	[Salesman_Id] [int] NULL,
//PRIMARY KEY CLUSTERED 
//(

//    [Customer_ID] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
//) ON[PRIMARY]
//GO








