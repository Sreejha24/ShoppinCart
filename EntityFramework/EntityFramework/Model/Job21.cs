using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFramework.Model
{
  
    public class Job21
    {
       
        public int id { get; set; }
        public string Role { get; set; }


        public int Pid { get; set; }
        [ForeignKey("Pid")]
        public Person21 person { get; set; }
    }
}
