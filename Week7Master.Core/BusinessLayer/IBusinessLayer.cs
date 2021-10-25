using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;

namespace Week7Master.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        //Aggiungere "l'elenco" delle funzionalità della traccia

        #region Funzionalità Corsi
        //Visualizza corsi
        public List<Corso> GetAllCorsi();
        //Inserire un nuovo corso
        public string InserisciNuovoCorso(Corso newCorso);
        //Modifica il corso
        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione);
        //Elimina corso
        public string EliminaCorso(string codiceCorsoDaEliminare);
        #endregion

        #region Funzionalità Studenti
        //Visializza studenti
        public List<Studente> GetAllStudenti();
        //Inserisci nuovo studente
        public string InserisciNuovoStudente(Studente nuovoStudente);
        //Modifica studente
        public string ModificaStudente(int idDaModificare, string nuovaEmail);
        //Elimina studente
        public string EliminaStudente(int studenteDaEliminare);
        //Visializzo l'elenco degli studenti iscritti ad un corso
        public List<Studente> VisualizzaStudentiCorso(string CodiceCorso);
        #endregion

        #region Funzionalità Docenti
        //visualizza docenti
        public List<Docente> GetAllDocenti();
        //Inserisci nuovo docente
        public string InserisciNuovoDocente(Docente nuovoDocente);
        //Modifica docente
        public string ModificaDocente(int idDaModificare, string nuovaEmail);
        //Elimina docente
        public string EliminaDocente(int docenteDaEliminare);
        #endregion

        #region Funzionalità Lezioni
        //Visializza Lezioni
        public List<Lezione> GetAllLezioni();
        //Inserisci nuova Lezione
        public string AggiungiLezione(Lezione lezione);
        //modifica lezione
        public string ModificaLezione(int id, string nuovaAula);
        //Elimina lezione
        string EliminaLezione(int idLezioneDaEliminare);
        //visualizza tutte lezioni di un corso recuperando il corso in base al codiceCorso
        public IList<Lezione> GetLezioniByCodiceCorso(string codiceCorso);
        //visualizza tutte lezioni di un corso recuperando il corso in base al nome
        public IList<Lezione> GetLezioniByNomeCorso(string nomeCorso);
        #endregion

    }
}
