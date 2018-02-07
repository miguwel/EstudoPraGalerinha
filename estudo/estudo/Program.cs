using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudo
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Estudo;Integrated Security=SSPI");
            SqlCommand x = new SqlCommand();
            x.Connection = conn;

            Class1 c = new Class1();

            int op = 42;

            while (op != 0)
            {
                op = int.Parse(Console.ReadLine());

                if (op == 1)
                    c.Insert(x);

                else if (op == 2)
                    c.Delete(x);

                else if (op == 3)
                    c.Update_Money(x);

                else if (op == 4)
                    c.Select(x);

                else
                    Console.WriteLine("Some DAQUIE");

            }
        }
    }
}
