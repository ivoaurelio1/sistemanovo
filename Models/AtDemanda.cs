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
        public Usuarios oUsuario { get; set; }
        public String Reclamante { get; set; }
        public String Telefone { get; set; }
        public int IdAssunto { get; set; }

        public AtAssunto atAssunto {get; set;}

        // List<AtAssunto> estava apenas AtAssunto
        public List<AtAssunto> ListaAssunto { get; set; }
        public String Observacao { get; set; }
    }
}