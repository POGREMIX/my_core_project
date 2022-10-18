using MyCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreProject
{
    public class SampleData
    {
        public static void Initialize(TestContext context)
        {
            if (!context.Tests.Any())
            {
                context.Tests.AddRange(
                    new Test
                    {
                        //Id = 1,
                        Name="Math"
                    },
                    new Test
                    {
                        //Id = 2,
                        Name = "Logic"
                    },
                    new Test
                    {
                        //Id = 3,
                        Name = "IT"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
