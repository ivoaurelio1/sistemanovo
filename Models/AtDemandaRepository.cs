using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace sistemanovo.Models.ViewModels
{
    public class AtDemandaRepository
    {
         private const String DadosConexao = "Database=cttu; Data Source=localhost; User Id=root;";

        public void Inserir(CadastroDemandaViewModel atd)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Insert into at_demandas (DataHora, IdUsuario, Reclamante, Telefone, IdAssunto, Observacao) values (@DataHora, @IdUsuario, @Reclamante, @Telefone, @IdAssunto, @Observacao)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@IdAtDemanda", atd.Demandas.IdAtDemanda);
            Comando.Parameters.AddWithValue("@DataHora", atd.Demandas.DataHora);
            Comando.Parameters.AddWithValue("@IdUsuario", atd.Demandas.IdUsuario);
            Comando.Parameters.AddWithValue("@Reclamante", atd.Demandas.Reclamante);
            Comando.Parameters.AddWithValue("@Telefone", atd.Demandas.Telefone);
            AtAssunto atAssunto = new AtAssunto();
            Comando.Parameters.AddWithValue("@IdAssunto", atd.Demandas.IdAssunto); // isso aqui tava atd.IdAtAssunto
            Comando.Parameters.AddWithValue("@Observacao", atd.Demandas.Observacao);

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
            Comando.Parameters.AddWithValue("@IdAssunto", atd.IdAssunto); // 22/01/2024 17:14 - alterei o caminho pra ver se resolve a questão do NullReferenceException: Object reference not set to an instance of an object na View 'Editar'
            Comando.Parameters.AddWithValue("@Observacao", atd.Observacao);

            Comando.ExecuteNonQuery();
            Conexao.Close();

        }

        public List<AtDemanda> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "SELECT d.IdAtDemanda as IdAtDemanda, d.DataHora, u.nome_usuario as NomeUsuario, d.Reclamante, d.Telefone, a.Assunto as Assunto, d.Observacao FROM at_demandas d JOIN at_assunto a JOIN usuarios u ON d.IdAssunto = a.IdAtAssunto AND d.IdUsuario = u.id_usuario ORDER BY IdAtDemanda DESC;";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<AtDemanda> Lista = new List<AtDemanda>();

            while (Reader.Read())
            {
                AtDemanda demanda = new AtDemanda();
                    
                    demanda.IdAtDemanda = Reader.GetInt32("IdAtDemanda");

                    demanda.DataHora = Reader.GetDateTime("DataHora");
                    
                    demanda.oUsuario = new Usuarios();
                    demanda.oUsuario.nome_usuario = Reader.GetString("NomeUsuario");

                    demanda.atAssunto = new AtAssunto();
                    demanda.atAssunto.Assunto = Reader.GetString("Assunto");
                    
                    demanda.Reclamante = Reader.GetString("Reclamante");
                    demanda.Telefone = Reader.GetString("Telefone");
                    demanda.Observacao = Reader.GetString("Observacao");

                    

                ;

                Lista.Add(demanda);
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

        // 22/01/2024 - 17:17 ESSE TRECHO ABAIXO ESTÁ FUNCIONANDO MAS FIZ OUTRO PRA VER SE RESOLVE A QUESTÃO DO NullReferenceException: Object reference not set to an instance of an object
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

        // 22/01/2024 17:18 -  ABAIXO ESTOU TENTANDO CRIAR UM OUTRO 'BuscarPorId' PRA VER SE RESOLVE O PROBLEMA DO NullReferenceException: Object reference not set to an instance of an object



        //   public AtDemanda BuscarPorId(int IdAtDemanda)
        // {
        //     MySqlConnection Conexao = new MySqlConnection(DadosConexao);
        //     Conexao.Open();
        //     String Query = "Select * From at_demandas where IdAtDemanda=@IdAtDemanda";
        //     MySqlCommand Comando = new MySqlCommand(Query, Conexao);
        //     Comando.Parameters.AddWithValue("@IdAtDemanda", IdAtDemanda);
        //     MySqlDataReader Reader = Comando.ExecuteReader();
        //     CadastroDemandaViewModel cad = new CadastroDemandaViewModel(); comentar isso
        //     CadastroDemandaViewModel demandaEncontrada = new CadastroDemandaViewModel();
        //     AtDemanda atDemanda = new AtDemanda();

        //     if (Reader.Read())
        //     {
        //         atDemanda.IdAtDemanda = Reader.GetInt32("IdAtDemanda");
                
        //         atDemanda.DataHora = Reader.GetDateTime("DataHora");
        //         demandaEncontrada.Demandas.DataHora = Reader.GetDateTime("DataHora"); comentar isso
        //         atDemanda.IdUsuario = Reader.GetInt32("IdUsuario");            
        //         atDemanda.Reclamante = Reader.GetString("Reclamante");            
        //         atDemanda.Telefone = Reader.GetString("Telefone");            
        //         demandaEncontrada.Demandas.atAssunto.IdAtAssunto = Reader.GetInt32("IdAssunto"); comentar isso         
        //         atDemanda.Observacao = Reader.GetString("Observacao");           
        //     }

        //     Conexao.Close();
        //     return atDemanda;

        // }

    }
}