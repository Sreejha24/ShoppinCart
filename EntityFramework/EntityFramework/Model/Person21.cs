using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFramework.Model
{
   
    public class Person21
    {
       
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public long Mobile { get; set; }
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Personid { get; set; }
        public ICollection<Job21> job { get; set; }
    }
}
