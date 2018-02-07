using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudo
{
    class Class1
    {
        public void Insert(SqlCommand cmd)
        {
            string nome = Console.ReadLine();
            double dinheiro = double.Parse(Console.ReadLine());
            string cpf = Console.ReadLine();

            cmd.Connection.Open();

            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@money", dinheiro);
            cmd.Parameters.AddWithValue("@pal", cpf);

            cmd.CommandText = @"INSERT INTO Pessoa(Nome, Dinheiro, CPF)
                                       VALUES(@nome, @money, @pal);";

            cmd.ExecuteNonQuery();

            cmd.Connection.Close();
        }

        public void Delete(SqlCommand cmd)
        {
            int Id = int.Parse(Console.ReadLine());

            cmd.Connection.Open();

            cmd.Parameters.AddWithValue("@cu", Id);

            cmd.CommandText = @"DELETE FROM Pessoa WHERE Id = @cu;";

            cmd.ExecuteNonQuery();

            cmd.Connection.Close();
        }

        public void Update_Money(SqlCommand cmd)
        {   
            int Id = int.Parse(Console.ReadLine());
            double dinheiro = double.Parse(Console.ReadLine());
            
            cmd.Connection.Open();

            cmd.Parameters.AddWithValue("@new", dinheiro);
            cmd.Parameters.AddWithValue("@Id", Id);

            cmd.CommandText = @"UPDATE Pessoa SET Dinheiro = @new WHERE Id = @Id;";

            cmd.ExecuteNonQuery();

            cmd.Connection.Close();
        }

        public void Select(SqlCommand cmd)
        {
             cmd.Connection.Open();

             cmd.CommandText = @"SELECT * FROM Pessoa;";

             SqlDataReader reader = cmd.ExecuteReader();

             if(reader.HasRows)
             {
                 while(reader.Read())
                 {
                     string nome = reader.GetString(1);
                     Console.WriteLine("Oi Pessoa: {0}", nome);
                 }
             }

             cmd.Connection.Close();
        }
    }
}
