using BusinessAccessLayer;
using DataAccsessLayer;
using System;
using System.Data;

namespace NTier_Architecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Customer_ID to see the details:");
            var customer_ID = Convert.ToInt32(Console.ReadLine());
             //CustomerssDataAccessDetails customerAccess = new CustomerssDataAccessDetails();
            //var datatable = customerAccess.FindCustomerDetails(customer_ID);

            InsertIntoCustomerAccess insertIntoCustomer = new InsertIntoCustomerAccess();
            var datatable = insertIntoCustomer.InsertCustomers();

            //UpdateCustomerAccess updateCustomer = new UpdateCustomerAccess();
            //var datatable = updateCustomer.UpdateCustomer();

            //OrdersOfCustomerDataAccessDetails orderAccess = new OrdersOfCustomerDataAccessDetails();
            //var table = orderAccess.FindOrders(customer_ID);

            InsertOrderAccess insertOrder = new InsertOrderAccess();
            var table = insertOrder.InsertOrders();

            //UpdateCustomerAccess updateCustomer = new UpdateCustomerAccess();
            //var table = updateCustomer.UpdateCustomer();


            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(datatable);
            dataSet.Tables.Add(table);
            //return dataSet;


            //try
            //{
            //    dataSet = new OrderOfCustomerAccessDetails().OrderCustomerDetails(customer_ID);
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine("Error occured."+ex.Message);

            //}
            //Console.WriteLine("Enter Customer Details:");
            //foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            //{
            //    Console.WriteLine(dataRow["Customer_ID"]+"|"+dataRow["Customer_name"]+"|"+dataRow["City"]);
            //}
            //Console.WriteLine("Enter Order Details:");
            //foreach (DataRow dataRow1 in dataSet.Tables[1].Rows)
            //{
            //    Console.WriteLine(dataRow1["Order_No"]+"|"+dataRow1["Purchase_Amount"]+"|"+dataRow1["Customer_ID"]);
            //}
        }
    }
}
