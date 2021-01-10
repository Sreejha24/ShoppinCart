using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Linqqq
{
    public class Program
    {
        private static string _constr;

        static void Main(string[] args)
        {
            string constr = "Data Source=192.168.50.95;Initial Catalog=sprathipati;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";

            _constr = constr;

           var employeeDetails = GetDetails();
             var data1 = employeeDetails.Where(d => d.FirstName.StartsWith("S"));
            //var data3 = employeeDetails.Where(d => d.EmployeeID.Equals(5));
            var data2 = employeeDetails.Where(d => d.FirstName.Contains("Sai"));
            //var data2 = employeeDetails.Where(d => d.FirstName.Contains("Sai")).FirstOrDefault();
            //var data = data1.Concat(data3);
            //Console.WriteLine(data.EmployeeID + "   "+data.FirstName);
            //var data = employeeDetails.Where(i => i.FirstName.StartsWith("S")).Distinct();

            // var data = employeeDetails.ElementAtOrDefault(4);

            //var data = data1.Except(data2);



            //var data =  from e in data1 group e by e.FirstName;

            //foreach (var val in data)
            //{


            //    foreach (Employee e in val)
            //    {
            //        Console.WriteLine("Employee Name: {0}",
            //                                   e.FirstName);
            //    }
            //}




            //var data = data1.Intersect(data2);
            //var data = employeeDetails.Last();
            //var data = employeeDetails.LastOrDefault();
            // var data = employeeDetails.Count();
            //var data = employeeDetails.Max(s=>s.EmployeeID);
            // var data = employeeDetails.Min(s => s.EmployeeID);
            // Console.WriteLine(data);
            //Console.WriteLine(data.EmployeeID + "   " + data.FirstName);
            //var data = data1.OrderBy(s => s.FirstName);
            //var data = data1.OrderByDescending(s => s.FirstName);
            // var data = employeeDetails.OrderByDescending(s => s.FirstName).ThenBy((s => s.EmployeeID));
            //var data = employeeDetails.SequenceEqual(data1);
            //Console.WriteLine(data);
            // var data = employeeDetails.Skip(4);
            // var data = employeeDetails.SkipWhile(s => s.EmployeeID==5);  // NOT Working
            var sum = employeeDetails.Sum(s => s.EmployeeID);
            Console.WriteLine(sum);
            //foreach (var i in data)
            //{
            //    Console.WriteLine(i.EmployeeID + " \t|\t" + i.FirstName);
            //}

        }

        static IList<Employee> GetDetails()
        {
            DataTable table = new DataTable();
            using(SqlConnection con = new SqlConnection(_constr))
            {
                var sql = "Select * from Employees";
                using(SqlCommand cmd = new SqlCommand(sql,con))
                {
                    using(SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(table);
                    }
                }
            }

            IList<Employee> employees = new List<Employee>();
            foreach(DataRow i in table.Rows)
            {
                var emp = new Employee()
                {
                    EmployeeID = int.Parse(i["EmployeeId"].ToString()),
                    FirstName = (i["FirstName"]).ToString(),
                    LastName = (i["LastName"]).ToString(),
                    Email = (i["Email"]).ToString(),
                    Mobile = long.Parse((i["Mobile"]).ToString()),
                    City = (i["City"]).ToString()
                };
                employees.Add(emp);
            }

            return employees;
        }
    }
}
