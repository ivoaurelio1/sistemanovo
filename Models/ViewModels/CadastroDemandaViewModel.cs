using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// namespace sistemanovo.Models.ViewModels <<<<<<<<<<<<<<<<< esse negocio tava assim completo, mas a gnete tirou um pedaço
namespace sistemanovo.Models.ViewModels
{
    public class CadastroDemandaViewModel
    {
        public AtDemanda Demandas { get; set; }

        public AtAssunto Assuntos { get; set;}

        public List<AtDemanda> ListaDemandas { get; set; }
        public List<AtAssunto> ListaAssuntos { get; set; }

        public int IdAtDemanda { get; set; }
        public int IdAtAssunto { get; set; }

        public DateTime dataRegistro {get;set;}

    }
}