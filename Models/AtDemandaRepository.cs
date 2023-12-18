using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace sistemanovo.Models
{
    public class AtDemandaRepository
    {
         private const String DadosConexao = "Database=cttu; Data Source=localhost; User Id=root;";

        public void Inserir(AtDemanda atd)
        {
            



            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Insert into at_demandas (DataHora, IdUsuario, Reclamante, Telefone, IdAssunto, Observacao) values (@DataHora, @IdUsuario, @Reclamante, @Telefone, @IdAssunto, @Observacao)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@IdAtDemanda", atd.IdAtDemanda);
            Comando.Parameters.AddWithValue("@DataHora", atd.DataHora);
            Comando.Parameters.AddWithValue("@IdUsuario", atd.IdUsuario);
            Comando.Parameters.AddWithValue("@Reclamante", atd.Reclamante);
            Comando.Parameters.AddWithValue("@Telefone", atd.Telefone);
            Comando.Parameters.AddWithValue("@IdAssunto", atd.IdAssunto);
            Comando.Parameters.AddWithValue("@Observacao", atd.Observacao);

            Comando.ExecuteNonQuery();
            Conexao.Close();

        }


        public void Alterar(AtDemanda atd)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Update at_demandas set Reclamante=@Reclamante, Telefone=@Telefone, IdAssunto=@IdAssunto, Observacao=@Observacao where IdAtDemanda=@IdAtDemanda";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            
            Comando.Parameters.AddWithValue("@IdAtDemanda", atd.IdAtDemanda);
            Comando.Parameters.AddWithValue("@Reclamante", atd.Reclamante);
            Comando.Parameters.AddWithValue("@Telefone", atd.Telefone);
            Comando.Parameters.AddWithValue("@IdAssunto", atd.IdAssunto);
            Comando.Parameters.AddWithValue("@Observacao", atd.Observacao);

            Comando.ExecuteNonQuery();
            Conexao.Close();

        }

        public List<AtDemanda> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Select * From at_demandas";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<AtDemanda> Lista = new List<AtDemanda>();

            while (Reader.Read())
            {
                AtDemanda demandaEncontrada = new AtDemanda
                {
                    IdAtDemanda = Reader.GetInt32("IdAtDemanda"),
                    DataHora = Reader.GetDateTime("DataHora"),
                    IdUsuario = Reader.GetInt32("IdUsuario"),
                    Reclamante = Reader.GetString("Reclamante"),
                    Telefone = Reader.GetString("Telefone"),
                    IdAssunto = Reader.GetInt32("IdAssunto"),
                    Observacao = Reader.GetString("Observacao"),

                };

                Lista.Add(demandaEncontrada);
            }

            Conexao.Close();
            return Lista;

        }

          public void Excluir(AtDemanda atd)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Delete from at_demandas where IdAtDemanda=@IdAtDemanda";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@IdAtDemanda", atd.IdAtDemanda);
            Comando.ExecuteNonQuery();
            Conexao.Close();

        }

          public AtDemanda BuscarPorId(int IdAtDemanda)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Select * From at_demandas where IdAtDemanda=@IdAtDemanda";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@IdAtDemanda", IdAtDemanda);
            MySqlDataReader Reader = Comando.ExecuteReader();
            AtDemanda demandaEncontrada = new AtDemanda();

            if (Reader.Read())
            {
                demandaEncontrada.IdAtDemanda = Reader.GetInt32("IdAtDemanda");
                demandaEncontrada.DataHora = Reader.GetDateTime("DataHora");
                demandaEncontrada.IdUsuario = Reader.GetInt32("IdUsuario");            
                demandaEncontrada.Reclamante = Reader.GetString("Reclamante");            
                demandaEncontrada.Telefone = Reader.GetString("Telefone");            
                demandaEncontrada.IdAssunto = Reader.GetInt32("IdAssunto");            
                demandaEncontrada.Observacao = Reader.GetString("Observacao");            
            }

            Conexao.Close();
            return demandaEncontrada;

        }

    }
}