using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace sistemanovo.Models
{
    public class UsuariosRepository
    {
        // Credenciais de acesso ao Banco de Dados.
        private const String DadosConexao = "Database=cttu; Data Source=localhost; User Id=root;";

        // Operadores de manipulação da tabela Usuários.

        // CRUD

        // public void TestarConexao()
        // {
        //     MySqlConnection Conexao = new MySqlConnection(DadosConexao);

        //     Conexao.Open();

        //     Console.WriteLine("Banco de Dados funcionando!");

        //     Conexao.Close();

        // }

        public void Excluir(Usuarios usu)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Delete from usuarios where id_usuario = @id_usuario";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@id_usuario", usu.id_usuario);
            Comando.ExecuteNonQuery();
            Conexao.Close();

        }

        public void Alterar(Usuarios usu)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Update usuarios set bar_code=@bar_code, cpf=@cpf, rg_n=@rg_n, rg_emissor=@rg_emissor, rg_uf=@rg_uf, rg_data_emissao=@rg_data_emissao, senha=@senha, matricula=@matricula, nome_completo=@nome_completo, nome_usuario=@nome_usuario, empresa=@empresa, atendente=@atendente, ativo=@ativo, operador=@operador, agente=@agente, email=@email, telefone1=@telefone1, telefone2=@telefone2, data_nasc=@data_nasc, fator_rh=@fator_rh, data_adm=@data_adm, endereco=@endereco, endereco_numero=@endereco_numero, endereco_cep=@endereco_cep, endereco_comp=@endereco_comp, bairro=@bairro, cidade=@cidade, estado_sigla=@estado_sigla, genero=@genero, nome_pai=@nome_pai, nome_mae=@nome_mae, nacionalidade=@nacionalidade, naturalidade=@naturalidade, habilitado=@habilitado, habilitacao_numero=@habilitacao_numero, habilitacao_categoria=@habilitacao_categoria where id_usuario=@id_usuario";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@id_usuario", usu.id_usuario);
            Comando.Parameters.AddWithValue("@bar_code", usu.bar_code);
            Comando.Parameters.AddWithValue("@cpf", usu.cpf);
            Comando.Parameters.AddWithValue("@rg_n", usu.rg_n);
            Comando.Parameters.AddWithValue("@rg_emissor", usu.rg_emissor);
            Comando.Parameters.AddWithValue("@rg_uf", usu.rg_uf);
            Comando.Parameters.AddWithValue("@rg_data_emissao", usu.rg_data_emissao);
            Comando.Parameters.AddWithValue("@senha", usu.senha);
            Comando.Parameters.AddWithValue("@matricula", usu.matricula);
            Comando.Parameters.AddWithValue("@nome_completo", usu.nome_completo);
            Comando.Parameters.AddWithValue("@nome_usuario", usu.nome_usuario);
            Comando.Parameters.AddWithValue("@empresa", usu.empresa);
            Comando.Parameters.AddWithValue("@atendente", usu.atendente);
            Comando.Parameters.AddWithValue("@ativo", usu.ativo);
            Comando.Parameters.AddWithValue("@operador", usu.operador);
            Comando.Parameters.AddWithValue("@agente", usu.agente);
            Comando.Parameters.AddWithValue("@email", usu.email);
            Comando.Parameters.AddWithValue("@telefone1", usu.telefone1);
            Comando.Parameters.AddWithValue("@telefone2", usu.telefone2);
            Comando.Parameters.AddWithValue("@data_nasc", usu.data_nasc);
            Comando.Parameters.AddWithValue("@fator_rh", usu.fator_rh);
            Comando.Parameters.AddWithValue("@data_adm", usu.data_adm);
            Comando.Parameters.AddWithValue("@endereco", usu.endereco);
            Comando.Parameters.AddWithValue("@endereco_numero", usu.endereco_numero);
            Comando.Parameters.AddWithValue("@endereco_cep", usu.endereco_cep);
            Comando.Parameters.AddWithValue("@endereco_comp", usu.endereco_comp);
            Comando.Parameters.AddWithValue("@bairro", usu.bairro);
            Comando.Parameters.AddWithValue("@cidade", usu.cidade);
            Comando.Parameters.AddWithValue("@estado_sigla", usu.estado_sigla);
            Comando.Parameters.AddWithValue("@genero", usu.genero);
            Comando.Parameters.AddWithValue("@nome_pai", usu.nome_pai);
            Comando.Parameters.AddWithValue("@nome_mae", usu.nome_mae);
            Comando.Parameters.AddWithValue("@nacionalidade", usu.nacionalidade);
            Comando.Parameters.AddWithValue("@naturalidade", usu.naturalidade);
            Comando.Parameters.AddWithValue("@habilitado", usu.habilitado);
            Comando.Parameters.AddWithValue("@habilitacao_numero", usu.habilitacao_numero);
            Comando.Parameters.AddWithValue("@habilitacao_categoria", usu.habilitacao_categoria);

            Comando.ExecuteNonQuery();
            Conexao.Close();

        }

        public void Inserir(Usuarios usu)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Insert into usuarios (bar_code, cpf, rg_n, rg_emissor, rg_uf, rg_data_emissao, senha, matricula, nome_completo, nome_usuario, empresa, atendente, ativo, operador, agente, email, telefone1, telefone2, data_nasc, fator_rh, data_adm, endereco, endereco_numero, endereco_cep, endereco_comp, bairro, cidade, estado_sigla, genero, nome_pai, nome_mae, nacionalidade, naturalidade, habilitado, habilitacao_numero, habilitacao_categoria) values (@bar_code,  @cpf,  @rg_n,  @rg_emissor,  @rg_uf,  @rg_data_emissao,  @senha,  @matricula,  @nome_completo,  @nome_usuario,  @empresa,  @atendente,  @ativo,  @operador,  @agente,  @email,  @telefone1,  @telefone2,  @data_nasc,  @fator_rh,  @data_adm,  @endereco,  @endereco_numero,  @endereco_cep,  @endereco_comp,  @bairro,  @cidade,  @estado_sigla,  @genero,  @nome_pai,  @nome_mae,  @nacionalidade,  @naturalidade,  @habilitado,  @habilitacao_numero,  @habilitacao_categoria)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@id_usuario", usu.id_usuario);
            Comando.Parameters.AddWithValue("@bar_code", usu.bar_code);
            Comando.Parameters.AddWithValue("@cpf", usu.cpf);
            Comando.Parameters.AddWithValue("@rg_n", usu.rg_n);
            Comando.Parameters.AddWithValue("@rg_emissor", usu.rg_emissor);
            Comando.Parameters.AddWithValue("@rg_uf", usu.rg_uf);
            Comando.Parameters.AddWithValue("@rg_data_emissao", usu.rg_data_emissao);
            Comando.Parameters.AddWithValue("@senha", usu.senha);
            Comando.Parameters.AddWithValue("@matricula", usu.matricula);
            Comando.Parameters.AddWithValue("@nome_completo", usu.nome_completo);
            Comando.Parameters.AddWithValue("@nome_usuario", usu.nome_usuario);
            Comando.Parameters.AddWithValue("@empresa", usu.empresa);
            Comando.Parameters.AddWithValue("@atendente", usu.atendente);
            Comando.Parameters.AddWithValue("@ativo", usu.ativo);
            Comando.Parameters.AddWithValue("@operador", usu.operador);
            Comando.Parameters.AddWithValue("@agente", usu.agente);
            Comando.Parameters.AddWithValue("@email", usu.email);
            Comando.Parameters.AddWithValue("@telefone1", usu.telefone1);
            Comando.Parameters.AddWithValue("@telefone2", usu.telefone2);
            Comando.Parameters.AddWithValue("@data_nasc", usu.data_nasc);
            Comando.Parameters.AddWithValue("@fator_rh", usu.fator_rh);
            Comando.Parameters.AddWithValue("@data_adm", usu.data_adm);
            Comando.Parameters.AddWithValue("@endereco", usu.endereco);
            Comando.Parameters.AddWithValue("@endereco_numero", usu.endereco_numero);
            Comando.Parameters.AddWithValue("@endereco_cep", usu.endereco_cep);
            Comando.Parameters.AddWithValue("@endereco_comp", usu.endereco_comp);
            Comando.Parameters.AddWithValue("@bairro", usu.bairro);
            Comando.Parameters.AddWithValue("@cidade", usu.cidade);
            Comando.Parameters.AddWithValue("@estado_sigla", usu.estado_sigla);
            Comando.Parameters.AddWithValue("@genero", usu.genero);
            Comando.Parameters.AddWithValue("@nome_pai", usu.nome_pai);
            Comando.Parameters.AddWithValue("@nome_mae", usu.nome_mae);
            Comando.Parameters.AddWithValue("@nacionalidade", usu.nacionalidade);
            Comando.Parameters.AddWithValue("@naturalidade", usu.naturalidade);
            Comando.Parameters.AddWithValue("@habilitado", usu.habilitado);
            Comando.Parameters.AddWithValue("@habilitacao_numero", usu.habilitacao_numero);
            Comando.Parameters.AddWithValue("@habilitacao_categoria", usu.habilitacao_categoria);

            Comando.ExecuteNonQuery();
            Conexao.Close();

        }

        public List<Usuarios> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Select * From usuarios";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Usuarios> Lista = new List<Usuarios>();

            while (Reader.Read())
            {
                Usuarios usuarioEncontrado = new Usuarios
                {
                    // essa parte talvez precise de um IsDBNull assim:
                    // if(!Reader.IsDBNull(Reader.GetOrdinal("bar_code")))
                    // data e valor nao precisa fazer essa verificação
                    // string precisa fazer a verificação para nao vir informação inválida
                    // verificar se tem not null (talvez seja isso)

                    id_usuario = Reader.GetInt32("id_usuario"),
                    bar_code = Reader.GetString("bar_code"),
                    cpf = Reader.GetInt32("cpf"),
                    rg_n = Reader.GetInt32("rg_n"),
                    rg_emissor = Reader.GetString("rg_emissor"),
                    rg_uf = Reader.GetString("rg_uf"),
                    rg_data_emissao = Reader.GetDateTime("rg_data_emissao"),
                    senha = Reader.GetString("senha"),
                    matricula = Reader.GetInt32("matricula"),
                    nome_completo = Reader.GetString("nome_completo"),
                    nome_usuario = Reader.GetString("nome_usuario"),
                    empresa = Reader.GetString("empresa"),
                    atendente = Reader.GetBoolean("atendente"),
                    ativo = Reader.GetBoolean("ativo"),
                    operador = Reader.GetBoolean("operador"),
                    agente = Reader.GetBoolean("agente"),
                    email = Reader.GetString("email"),
                    telefone1 = Reader.GetInt32("telefone1"),
                    telefone2 = Reader.GetInt32("telefone2"),
                    data_nasc = Reader.GetDateTime("data_nasc"),
                    fator_rh = Reader.GetString("fator_rh"),
                    data_adm = Reader.GetDateTime("data_adm"),
                    endereco = Reader.GetString("endereco"),
                    endereco_numero = Reader.GetString("endereco_numero"),
                    endereco_cep = Reader.GetInt32("endereco_cep"),
                    endereco_comp = Reader.GetString("endereco_comp"),
                    bairro = Reader.GetString("bairro"),
                    cidade = Reader.GetString("cidade"),
                    estado_sigla = Reader.GetString("estado_sigla"),
                    genero = Reader.GetString("genero"),
                    nome_pai = Reader.GetString("nome_pai"),
                    nome_mae = Reader.GetString("nome_mae"),
                    nacionalidade = Reader.GetString("nacionalidade"),
                    naturalidade = Reader.GetString("naturalidade"),
                    habilitado = Reader.GetBoolean("habilitado"),
                    habilitacao_numero = Reader.GetInt32("habilitacao_numero"),
                    habilitacao_categoria = Reader.GetString("habilitacao_categoria")
                };

                Lista.Add(usuarioEncontrado);
            }

            Conexao.Close();
            return Lista;

        }

         public Usuarios  BuscarPorId(int id_usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Select * From usuarios where id_usuario=@id_usuario";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@id_usuario", id_usuario);
            MySqlDataReader Reader = Comando.ExecuteReader();
            Usuarios usuarioEncontrado = new Usuarios();

            if (Reader.Read())
            {
                 // essa parte talvez precise de um IsDBNull assim:
                // if(!Reader.IsDBNull(Reader.GetOrdinal("bar_code")))
                // data e valor nao precisa fazer essa verificação
                // string precisa fazer a verificação para nao vir informação inválida
                // verificar se tem not null (talvez seja isso)

                usuarioEncontrado.id_usuario = Reader.GetInt32("id_usuario");
                usuarioEncontrado.bar_code = Reader.GetString("bar_code");
                usuarioEncontrado.cpf = Reader.GetInt32("cpf");
                usuarioEncontrado.rg_n = Reader.GetInt32("rg_n");
                usuarioEncontrado.rg_emissor = Reader.GetString("rg_emissor");
                usuarioEncontrado.rg_uf = Reader.GetString("rg_uf");
                usuarioEncontrado.rg_data_emissao = Reader.GetDateTime("rg_data_emissao");
                usuarioEncontrado.senha = Reader.GetString("senha");
                usuarioEncontrado.matricula = Reader.GetInt32("matricula");
                usuarioEncontrado.nome_completo = Reader.GetString("nome_completo");
                usuarioEncontrado.nome_usuario = Reader.GetString("nome_usuario");
                usuarioEncontrado.empresa = Reader.GetString("empresa");
                usuarioEncontrado.atendente = Reader.GetBoolean("atendente");
                usuarioEncontrado.ativo = Reader.GetBoolean("ativo");
                usuarioEncontrado.operador = Reader.GetBoolean("operador");
                usuarioEncontrado.agente = Reader.GetBoolean("agente");
                usuarioEncontrado.email = Reader.GetString("email");
                usuarioEncontrado.telefone1 = Reader.GetInt32("telefone1");
                usuarioEncontrado.telefone2 = Reader.GetInt32("telefone2");
                usuarioEncontrado.data_nasc = Reader.GetDateTime("data_nasc");
                usuarioEncontrado.fator_rh = Reader.GetString("fator_rh");
                usuarioEncontrado.data_adm = Reader.GetDateTime("data_adm");
                usuarioEncontrado.endereco = Reader.GetString("endereco");
                usuarioEncontrado.endereco_numero = Reader.GetString("endereco_numero");
                usuarioEncontrado.endereco_cep = Reader.GetInt32("endereco_cep");
                usuarioEncontrado.endereco_comp = Reader.GetString("endereco_comp");
                usuarioEncontrado.bairro = Reader.GetString("bairro");
                usuarioEncontrado.cidade = Reader.GetString("cidade");
                usuarioEncontrado.estado_sigla = Reader.GetString("estado_sigla");
                usuarioEncontrado.genero = Reader.GetString("genero");
                usuarioEncontrado.nome_pai = Reader.GetString("nome_pai");
                usuarioEncontrado.nome_mae = Reader.GetString("nome_mae");
                usuarioEncontrado.nacionalidade = Reader.GetString("nacionalidade");
                usuarioEncontrado.naturalidade = Reader.GetString("naturalidade");
                usuarioEncontrado.habilitado = Reader.GetBoolean("habilitado");
                usuarioEncontrado.habilitacao_numero = Reader.GetInt32("habilitacao_numero");
                usuarioEncontrado.habilitacao_categoria = Reader.GetString("habilitacao_categoria");
            }

            Conexao.Close();
            return usuarioEncontrado;


        }



        
         public Usuarios ValidarLogin(Usuarios usu)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "Select * from usuarios where bar_code=@bar_code and senha=@senha";
            
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@bar_code", usu.bar_code);
            Comando.Parameters.AddWithValue("@senha", usu.senha);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuarios usuarioEncontrado = null;

            if (Reader.Read())
            {
                usuarioEncontrado = new Usuarios
                {
                    // {
                    // essa parte talvez precise de um IsDBNull assim:
                    // if(!Reader.IsDBNull(Reader.GetOrdinal("bar_code")))
                    // data e valor nao precisa fazer essa verificação
                    // string precisa fazer a verificação para nao vir informação inválida
                    // verificar se tem not null (talvez seja isso)

                    //     id_usuario = Reader.GetInt32("id_usuario")
                    // };
                    //essa parte anterior é a simplificação sugerida pelo vscode da linha abaixo:
                    id_usuario = Reader.GetInt32("id_usuario")
                };

                // if (!Reader.IsDBNull(Reader.GetOrdinal("bar_code")))
                // usuarioEncontrado.bar_code = Reader.GetString("bar_code");

                // usuarioEncontrado.cpf = Reader.GetInt32("cpf");
                // usuarioEncontrado.rg_n = Reader.GetInt32("rg_n");
                // usuarioEncontrado.rg_emissor = Reader.GetString("rg_emissor");
                // usuarioEncontrado.rg_uf = Reader.GetString("rg_uf");
                // usuarioEncontrado.rg_data_emissao = Reader.GetDateTime("rg_data_emissao");

                if (!Reader.IsDBNull(Reader.GetOrdinal("senha")))
                usuarioEncontrado.senha = Reader.GetString("senha");
                
                // usuarioEncontrado.matricula = Reader.GetInt32("matricula");
                // usuarioEncontrado.nome_completo = Reader.GetString("nome_completo");
               
                if(!Reader.IsDBNull(Reader.GetOrdinal("nome_usuario")))
                usuarioEncontrado.nome_usuario = Reader.GetString("nome_usuario");
                
                // usuarioEncontrado.empresa = Reader.GetString("empresa");
                // usuarioEncontrado.atendente = Reader.GetBoolean("atendente");
                // usuarioEncontrado.ativo = Reader.GetBoolean("ativo");
                // usuarioEncontrado.operador = Reader.GetBoolean("operador");
                // usuarioEncontrado.agente = Reader.GetBoolean("agente");
                // usuarioEncontrado.email = Reader.GetString("email");
                // usuarioEncontrado.telefone1 = Reader.GetInt32("telefone1");
                // usuarioEncontrado.telefone2 = Reader.GetInt32("telefone2");
                // usuarioEncontrado.data_nasc = Reader.GetDateTime("data_nasc");
                // usuarioEncontrado.fator_rh = Reader.GetString("fator_rh");
                // usuarioEncontrado.data_adm = Reader.GetDateTime("data_adm");
                // usuarioEncontrado.endereco = Reader.GetString("endereco");
                // usuarioEncontrado.endereco_numero = Reader.GetString("endereco_numero");
                // usuarioEncontrado.endereco_cep = Reader.GetInt32("endereco_cep");
                // usuarioEncontrado.endereco_comp = Reader.GetString("endereco_comp");
                // usuarioEncontrado.bairro = Reader.GetString("bairro");
                // usuarioEncontrado.cidade = Reader.GetString("cidade");
                // usuarioEncontrado.estado_sigla = Reader.GetString("estado_sigla");
                // usuarioEncontrado.genero = Reader.GetString("genero");
                // usuarioEncontrado.nome_pai = Reader.GetString("nome_pai");
                // usuarioEncontrado.nome_mae = Reader.GetString("nome_mae");
                // usuarioEncontrado.nacionalidade = Reader.GetString("nacionalidade");
                // usuarioEncontrado.naturalidade = Reader.GetString("naturalidade");
                // usuarioEncontrado.habilitado = Reader.GetBoolean("habilitado");
                // usuarioEncontrado.habilitacao_numero = Reader.GetInt32("habilitacao_numero");
                // usuarioEncontrado.habilitacao_categoria = Reader.GetString("habilitacao_categoria");
            }

            Conexao.Close();
            return usuarioEncontrado;


        }



    }
}