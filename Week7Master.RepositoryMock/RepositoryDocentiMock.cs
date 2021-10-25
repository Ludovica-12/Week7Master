using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;
using Week7Master.Core.InterfaceRepositories;

namespace Week7Master.RepositoryMock
{
    public class RepositoryDocentiMock : IRepositoryDocenti
    {
        public static List<Docente> Docenti = new List<Docente>()
        {
            new Docente{ID = 1, Nome="Paolo", Cognome = "Gialli", Email = "paolo.gialli@mail.it", Telefono = "3651284779"},
            new Docente{ID = 2, Nome="Luca", Cognome = "Verdi", Email = "luca.verdi@mail.it", Telefono = "3351984779"}
        };

        public Docente Add(Docente docente)
        {

            if (Docenti.Count() == 0)
            {
                docente.ID = 1;
            }
            else
            {
                docente.ID = Docenti.Max(d => d.ID) + 1; //TODO: da errore
            }

            Docenti.Add(docente);
            return docente;
        }

        public bool Delete(Docente docente)
        {
            Docenti.Remove(docente);

            return true;
        }

        public List<Docente> GetAll()
        {
            return Docenti;
        }

        public Docente GetById(int id)
        {
            return Docenti.Find(d => d.ID == id);
        }

        public Docente Update(Docente docente)
        {
            var old = Docenti.Find(d => d.ID == docente.ID);
            old.Email = docente.Email;

            return docente;
        }
    }
}
