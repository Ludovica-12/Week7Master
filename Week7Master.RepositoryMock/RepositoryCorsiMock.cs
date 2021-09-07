using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;
using Week7Master.Core.InterfaceRepositories;

namespace Week7Master.RepositoryMock
{
    public class RepositoryCorsiMock : IRepositoryCorsi
    {
        //Dati Finti
        public static List<Corso> Corsi = new List<Corso>()
        {
            new Corso{CodiceCorso="C-01", Nome="Pre-Academy I", Descrizione="Corso base c## livello1"},
            new Corso{CodiceCorso="C-02", Nome="Academy I", Descrizione="Corso base c## livello2"},
        };

        public Corso Add(Corso corso)
        {
            Corsi.Add(corso);

            return corso;
        }

        public bool Delete(Corso corso)
        {
            Corsi.Remove(corso);

            return true;
        }

        public List<Corso> GetAll()
        {
            return Corsi;
        }

        public Corso GetByCode(string code)
        {
            return Corsi.Find(c => c.CodiceCorso == code);
            //return Corsi.FirstOrDefault(c => c.CodiceCorso == code);
        }

        public Corso Update(Corso corso)
        {
            var old = Corsi.Find(c => c.CodiceCorso == corso.CodiceCorso);
            old.Nome = corso.Nome;
            old.Descrizione = corso.Descrizione;

            return corso;
        }
    }
}
