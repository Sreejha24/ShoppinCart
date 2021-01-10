using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework
{
    public class Methods
    {
        private static ContextClass _context;

        public Methods()
        {
            _context = new ContextClass();
        }
        public  IList<Employees> GetEmployees()
        {

            var Data = _context.Employees.ToList();
            return Data;

        }

        public  void  InsertEmployeeRecord()
        {
           

            var data = new Employees()
            {
                
                FirstName = "Roshini",
                LastName = "Pandhi",
                City = "Uppal Depo",
                Mobile = 8008000737,
                Email = "roshinipandhi@gmail.com"
            };
            _context.Employees.Add(data);
            _context.SaveChanges();
        }

        public  void UpdateEmployee(int EmpId,string lastName)
        {
            var data = _context.Employees.Where(s => s.EmployeeID == EmpId).FirstOrDefault();
            if(data!=null)
            {
                data.LastName = lastName;
                _context.SaveChanges();
            }

        }

        public void DeleteEmployeeRecord()
        {
            var data = _context.Employees.Where(s => s.EmployeeID == 19).FirstOrDefault();
            if(data!=null)
            {
                _context.Employees.Remove(data);
                _context.SaveChanges();



            }
        }
    }
}
