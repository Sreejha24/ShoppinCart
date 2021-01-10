using EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.MyMigration
{
    public class CRUDOperations
    {
        public void InserPersonDetails()
        {
            var context = new CRUDOperationContext();
            var person = new Person21()
            {

               

                FirstName = Console.ReadLine(),

                LastName = Console.ReadLine(),

                Age = int.Parse(Console.ReadLine()),

                Gender = Console.ReadLine(),
                Mobile = long.Parse(Console.ReadLine())
            };
            context.persons.Add(person);
            context.SaveChanges();
            Console.WriteLine("Records successfully installed into Person table.....");

        }

        //public void InsertJobDetails()
        //{
        //    var context = new CRUDOperationContext();
        //    var job = new Job21();
        //    Console.WriteLine("Insert Job details");
        //    Console.WriteLine("Job Id:");
        //    job.id = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Job Role:");
        //    job.Role = Console.ReadLine();
        //    Console.WriteLine("Job PersonId:");
        //    job.Pid = int.Parse(Console.ReadLine());
        //    context.jobs.Add(job);
        //    context.SaveChanges();
        //    Console.WriteLine("Records successfully installed into Job table.....");

        //}
    }
}
