using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;
using Week7Master.Core.InterfaceRepositories;

namespace Week7Master.RepositoryMock
{
    public class RepositoryStudentiMock : IRepositoryStudenti
    {
        public static List<Studente> Studenti = new List<Studente>();



        public Studente Add(Studente studente)
        {
            if(Studenti.Count == 0)
            {
                studente.ID = 1;
            }
            else
            {
                studente.ID = Studenti.Max(s => s.ID) + 1;
            }

            var corso = RepositoryCorsiMock.Corsi.FirstOrDefault(c => c.CodiceCorso == studente.CorsoCodice);
            studente.Corso = corso;

            corso.Studenti.Add(studente);

            Studenti.Add(studente);
            return studente;
            
        }

        public bool Delete(Studente studente)
        {
            Studenti.Remove(studente);

            return true;
        }

        public List<Studente> GetAll()
        {
            return Studenti;
        }

        public Studente GetById(int id)
        {
            return Studenti.Find(s => s.ID == id);
        }

        public Studente Update(Studente studente)
        {
            var old = Studenti.Find(s => s.ID == studente.ID);
            old.Email = studente.Email;

            return studente;
        }
    }
}
