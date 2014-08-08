using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NumbersSite.Models;

namespace NumbersSite.DAL
{
    public class NumbersInitializer : System.Data.Entity .DropCreateDatabaseIfModelChanges<NumbersContext>
    {
        protected override void Seed(NumbersContext context)
        {
            var numbers = new List<Numbers>
            {
                new Numbers{ ID = 1, Value = 1, isPrime = true},
                new Numbers{ ID = 2, Value = 2, isPrime = false},
                new Numbers{ ID = 3, Value = 3, isPrime = true},
                new Numbers{ ID = 4, Value = 4, isPrime = false},
                new Numbers{ ID = 5, Value = 5, isPrime = true},
                new Numbers{ ID = 6, Value = 6, isPrime = false},
                new Numbers{ ID = 7, Value = 7, isPrime = true},
            };

            numbers.ForEach(p => context.Numbers.Add(p));
            context.SaveChanges();
        }
    }
}