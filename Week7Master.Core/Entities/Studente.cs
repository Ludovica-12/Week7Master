using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Master.Core.Entities
{
    public class Studente: Persona
    {
        public DateTime DataNascita { get; set; }
        public string TitoloStudio { get; set; }

        //FK
        public string CorsoCodice { get; set; }
        public Corso Corso { get; set; }

        public override string ToString()
        {
            return $"Id: {ID}\t Nome: {Nome}\t Cognome{Cognome}\t Nato il: {DataNascita.ToShortDateString()}\tAltre info: {Email} -{TitoloStudio}";
        }

    }
}
