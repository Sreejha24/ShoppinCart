using System;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Details...!");
           // new Methods().UpdateEmployee(19, "Gurram");
            //new Methods().InsertEmployeeRecord();
            new Methods().DeleteEmployeeRecord();
            var data = new Methods().GetEmployees();
         
            foreach (var i in data)
            {
                Console.WriteLine(i.EmployeeID + " \t|\t  " + i.FirstName + "   \t|\t  " + i.LastName);
            }
        }
    }
}
