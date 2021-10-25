using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;
using Week7Master.Core.InterfaceRepositories;

namespace Week7Master.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {

        //dCHIARO QUALI SONO I REPOSITORY CHE A DISPOSIZIONE
        private readonly IRepositoryCorsi corsiRepo;
        private readonly IRepositoryDocenti docentiRepo;
        private readonly IRepositoryStudenti studentiRepo;
        private readonly IRepositoryLezioni lezioniRepo;

        public MainBusinessLayer(IRepositoryCorsi corsi, IRepositoryDocenti docenti, IRepositoryLezioni lezioni, IRepositoryStudenti studenti )
        {
            corsiRepo = corsi;
            docentiRepo = docenti;
            lezioniRepo = lezioni;
            studentiRepo = studenti;
            
        }



        #region Funzionalità Corsi
        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.GetAll();
        }

        public string InserisciNuovoCorso(Corso newCorso)
        {
            //Controllo input
            //Non deve esiestere un altro corso con lo stesso codice
            var corsoEsistente = corsiRepo.GetByCode(newCorso.CodiceCorso);

            if(corsoEsistente != null)
            {
                return "Errore: Codice corso già presente!!";
            }
            corsiRepo.Add(newCorso);

            return "Corso aggiunto correttamente";

        }

        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione)
        {
            //Controllo i dati
            Corso corsoEsistente = corsiRepo.GetByCode(codiceCorsoDaModificare);
            if(corsoEsistente == null)
            {
                return "Errore: Codice corso errato o non presente!!";
            }
            corsoEsistente.Nome = nuovoNome;
            corsoEsistente.Descrizione = nuovaDescrizione;

            corsiRepo.Update(corsoEsistente);

            return "Congraturazioni il corso è stato modificato con successo!";
        }

        public string EliminaCorso(string codiceCorsoDaEliminare)
        {
            //Controllo i dati
            Corso corsoEsistente = corsiRepo.GetByCode(codiceCorsoDaEliminare);
            if (corsoEsistente == null)
            {
                return "Errore: Codice corso errato o non presente!!";
            }

            corsiRepo.Delete(corsoEsistente);

            return "Complimenti il corso è stato eliminato con successo!";
        }
        #endregion

        #region Funzionalità Studenti

        public List<Studente> GetAllStudenti()
        {
            return studentiRepo.GetAll();
        }

        public string InserisciNuovoStudente(Studente nuovoStudente)
        {
            //controllo input
            Corso corsoEsistente = corsiRepo.GetByCode(nuovoStudente.CorsoCodice);
            if(corsoEsistente == null)
            {
                return "Errore!";
            }
            studentiRepo.Add(nuovoStudente);

            return "Studente inserito correttamente";
        }

        public string ModificaStudente(int idDaModificare, string nuovaEmail)
        {
            Studente studenteEsistente = studentiRepo.GetById(idDaModificare);
            if (studenteEsistente == null)
            {
                return "Errore: ID errato o non presente";
            }
            studenteEsistente.Email = nuovaEmail ;

            studentiRepo.Update(studenteEsistente);

            return "Congraturazioni lo studente è stato modificato con successo!";
        }

        public string EliminaStudente(int studenteDaEliminare)
        {
            Studente studenteEsistente = studentiRepo.GetById(studenteDaEliminare);
            if (studenteEsistente == null)
            {
                return "Errore: ID errato o non presente";
            }

            studentiRepo.Delete(studenteEsistente);

            return "Congraturazioni lo studente è stato eliminato con successo!";
        }

        public List<Studente> VisualizzaStudentiCorso(string CodiceCorso)
        {
            Corso corso = corsiRepo.GetByCode(CodiceCorso);
            if(corso == null)
            {
                return null;
            }
            else
            {
                return studentiRepo.GetAll().Where(s => s.CorsoCodice == corso.CodiceCorso).ToList();
            }

           
        }
        #endregion

        #region Funzionalità Docenti
        public List<Docente> GetAllDocenti()
        {
            return docentiRepo.GetAll();
        }

        public string InserisciNuovoDocente(Docente nuovoDocente)
        {
            Docente docenteEsistente = docentiRepo.GetAll().FirstOrDefault(d => d.Cognome == nuovoDocente.Cognome && d.Nome == nuovoDocente.Nome && d.Email == nuovoDocente.Email);
            if (docenteEsistente != null)
            {
                return "Errore!";
            }

            docentiRepo.Add(nuovoDocente);
            return "Docente inserito correttamente";

        }

        public string ModificaDocente(int idDaModificare, string nuovaEmail)
        {
            Docente docenteEsistente = docentiRepo.GetById(idDaModificare);
            if (docenteEsistente == null)
            {
                return "Errore: ID errato o non presente";
            }
            docenteEsistente.Email = nuovaEmail;

            docentiRepo.Update(docenteEsistente);

            return "Congraturazioni il docente è stato modificato con successo!";
        }

        public string EliminaDocente(int docenteDaEliminare)
        {

            Docente docenteEsistente = docentiRepo.GetById(docenteDaEliminare);
            if (docenteEsistente == null)
            {
                return "Errore: ID errato o non presente";
            }

            docentiRepo.Delete(docenteEsistente);

            return "Congraturazioni il docente è stato eliminato con successo!";
        }
        #endregion

        #region Funzionalità Lezioni
        public List<Lezione> GetAllLezioni()
        {
            return lezioniRepo.GetAll();
        }

        public string AggiungiLezione(Lezione lezione)
        {
            //controllo input
            //controllo se codice corso esiste
            var corso = corsiRepo.GetByCode(lezione.CorsoCodice);
            if (corso == null)
            {
                return "Codice Corso errato o inesistente";
            }

            //e se esiste codice docente
            var docente = docentiRepo.GetById(lezione.DocenteID);
            if (docente == null)
            {
                return "Codice docente inesistente";
            }
            //Si possono eventualmente prevedere altri controlli ad esempio verifica che non esista già
            //una lezione associata allo stesso docente lo stesso giorno..

            lezioniRepo.Add(lezione);
            return "Aggiunta correttamente";
        }

        public string ModificaLezione(int id, string nuovaAula)
        {
            //recupero la Lezione tramite l'id 
            var lezioneDaModificare = lezioniRepo.GetAll().FirstOrDefault(l => l.LezioneID == id);

            if (lezioneDaModificare == null)
            {
                return "Id non valido/ non presente";
            }

            //Modifico il campo Aula con il nuovo valore scritto dall'utente
            lezioneDaModificare.Aula = nuovaAula;

            //aggiorno la lezione
            lezioniRepo.Update(lezioneDaModificare);
            return "Modifica effettuata";
        }

        public string EliminaLezione(int idLezioneDaEliminare)
        {
            //controllo su input
            var lezioneEsistente = lezioniRepo.GetById(idLezioneDaEliminare);
            if (lezioneEsistente == null)
            {
                return "Id non valido.Impossibile eliminare.";
            }
            lezioniRepo.Delete(lezioneEsistente);
            return "Lezione eliminata con successo";
        }

        public IList<Lezione> GetLezioniByCodiceCorso(string codiceCorso)
        {
            //TODO: controllare input
            if (string.IsNullOrEmpty(codiceCorso) == true)
            {
                return null;
            }
            var lezioni = new List<Lezione>();
            lezioni = lezioniRepo.GetAll().Where(l => l.CorsoCodice == codiceCorso).ToList();
            return lezioni;
        }

        public IList<Lezione> GetLezioniByNomeCorso(string nomeCorso)
        {
            var corso = corsiRepo.GetAll().FirstOrDefault(c => c.Nome == nomeCorso);

            if (corso == null)
            {
                return null;
            }

            var lezioni = new List<Lezione>();
            lezioni = lezioniRepo.GetAll().Where(l => l.CorsoCodice == corso.CodiceCorso).ToList();
            return lezioni;
        }
        #endregion

    }
}
