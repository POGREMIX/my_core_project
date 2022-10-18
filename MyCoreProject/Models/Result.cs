using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreProject.Models
{
    public class Result
    {
        public int Id { get; set; }
        public Test Test { get; set; }
        public Question Question { get; set;}
        public Answer Answer { get; set; }
    }
}
