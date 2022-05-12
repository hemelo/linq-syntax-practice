using System;
using Linq.Practice.Shared;
using Linq.Practice.Exercises;
using Microsoft.EntityFrameworkCore;

namespace Linq.Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("");
            ApplicationContext context = new ApplicationContext(optionsBuilder.Options);
            //context.Database.Log = Console.WriteLine;
        }
    }
}