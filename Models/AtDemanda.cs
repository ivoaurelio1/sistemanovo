using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace sistemanovo.Models
{
    public class AtDemanda
    {
       public int IdAtDemanda { get; set; }
        public DateTime DataHora { get; set; }
        public int IdUsuario { get; set; }
        public Usuarios nome_usuario { get; set; }
        public String Reclamante { get; set; }
        public String Telefone { get; set; }
        public int IdAssunto { get; set; }
        public AtAssunto Assunto { get; set; }
        public String Observacao { get; set; }
    }
}