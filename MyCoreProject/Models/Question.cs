using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        public Test Test { get; set; }
        public string Value { get; set; }        
    }
}
