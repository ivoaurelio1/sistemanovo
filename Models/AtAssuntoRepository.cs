using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;


namespace sistemanovo.Models
{
    public class AtAssuntoRepository
    {
        private const String DadosConexao = "Database=cttu; Data Source=localhost; User Id=root;";

        public void Inserir(AtAssunto ata)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Insert into at_assunto (Assunto,Descricao) values (@Assunto,@Descricao)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Assunto", ata.Assunto);
            Comando.Parameters.AddWithValue("@Descricao", ata.Descricao);

            Comando.ExecuteNonQuery();
            Conexao.Close();

        }


        public void Alterar(AtAssunto ata)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Update at_assunto set Assunto=@Assunto, Descricao=@Descricao where IdAtAssunto=@IdAtAssunto";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@IdAtAssunto", ata.IdAtAssunto);
            Comando.Parameters.AddWithValue("@Assunto", ata.Assunto);
            Comando.Parameters.AddWithValue("@Descricao", ata.Descricao);

            Comando.ExecuteNonQuery();
            Conexao.Close();

        }

        public List<AtAssunto> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Select * From at_assunto";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<AtAssunto> Lista = new List<AtAssunto>();

            while (Reader.Read())
            {
                AtAssunto assuntoEncontrado = new AtAssunto
                {
                    IdAtAssunto = Reader.GetInt32("IdAtAssunto"),
                    Assunto = Reader.GetString("Assunto"),
                    Descricao = Reader.GetString("Descricao"),

                };

                Lista.Add(assuntoEncontrado);
            }

            Conexao.Close();
            return Lista;

        }

          public void Excluir(AtAssunto ata)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Delete from at_assunto where IdAtAssunto=@IdAtAssunto";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@IdAtAssunto", ata.IdAtAssunto);
            Comando.ExecuteNonQuery();
            Conexao.Close();

        }

          public AtAssunto  BuscarPorId(int IdAtAssunto)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Select * From at_assunto where IdAtAssunto=@IdAtAssunto";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@IdAtAssunto", IdAtAssunto);
            MySqlDataReader Reader = Comando.ExecuteReader();
            AtAssunto assuntoEncontrado = new AtAssunto();

            if (Reader.Read())
            {
                assuntoEncontrado.IdAtAssunto = Reader.GetInt32("IdAtAssunto");
                assuntoEncontrado.Assunto = Reader.GetString("Assunto");
                assuntoEncontrado.Descricao = Reader.GetString("Descricao");            
            }

            Conexao.Close();
            return assuntoEncontrado;

        }






    }
}