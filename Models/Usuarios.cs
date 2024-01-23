using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemanovo.Models
{
    public class Usuarios
    {
        public int id_usuario{get; set;}
        public String? bar_code {get; set;}
        public int cpf {get; set;}
        public int rg_n {get; set;}
        public String? rg_emissor {get; set;}
        public String? rg_uf {get; set;}
        public DateTime rg_data_emissao {get; set;}
        public String? senha {get; set;}
        public int matricula {get; set;}
        public String? nome_completo {get; set;}
        public String? nome_usuario {get; set;}
        public String? empresa {get; set;}
        public bool atendente {get; set;}
        public bool ativo {get; set;}
        public bool operador {get; set;}
        public bool agente {get; set;}
        public String? email {get; set;}
        public int telefone1 {get; set;}
        public int telefone2 {get; set;}
        public DateTime data_nasc {get; set;}
        public String? fator_rh {get; set;}
        public DateTime data_adm {get; set;}
        public String? endereco {get; set;}
        public String? endereco_numero {get; set;}
        public int endereco_cep {get; set;}
        public String? endereco_comp {get; set;}
        public String? bairro {get; set;}
        public String? cidade {get; set;}
        public String? estado_sigla {get; set;}
        public String? genero {get; set;}
        public String? nome_pai {get; set;}
        public String? nome_mae {get; set;}
        public String? nacionalidade {get; set;}
        public String? naturalidade {get; set;}
        public bool habilitado {get; set;}
        public int habilitacao_numero {get; set;}
        public String? habilitacao_categoria {get; set;}
    }
}