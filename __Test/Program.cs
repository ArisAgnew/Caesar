using System;
using System.Collections.Generic;
using System.Linq;

using static System.Console;

namespace __Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new OrderClause
            {
                OrderDesc = null,
                OrderField = "LastName"
            };

            var list = new List<OrderClause>
            {
                new OrderClause { OrderDesc = null, OrderField = "" }
            };

            Double? d = new OrderClause();

            dynamic result = d ?? 3.14;
            WriteLine(result);
            ReadLine();
        }
    }

    class OrderClause
    {
        public OrderClause OrderDesc { private get; set; }
        public string OrderField { private get; set; }

        public double PropertyDouble { get; set; }

        public static implicit operator double(OrderClause or) => or.PropertyDouble;
    }
}
