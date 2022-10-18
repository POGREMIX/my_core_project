using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreProject.Models
{
    public class Answer
    {
        public int Id {get; set; }
        public Question Question { get; set; }
        public int Value { get; set; }
        public bool IsCorrect { get; set; }
    }
}
