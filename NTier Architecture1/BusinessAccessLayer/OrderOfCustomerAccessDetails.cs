using DataAccsessLayer;
using System;
using System.Data;

namespace BusinessAccessLayer
{
    public class OrderOfCustomerAccessDetails
    {
        public DataSet OrderCustomerDetails(int customer_ID)
        {
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
            return dataSet;

        }
       
    }
}
