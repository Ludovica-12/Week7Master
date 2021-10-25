using System;
using Week7Master.Core.BusinessLayer;
using Week7Master.Core.Entities;
using Week7Master.RepositoryEF.RepositoryEF;
//using Week7Master.RepositoryMock;

namespace Week7Master
{
    class Program
    {
        //private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiMock(), new RepositoryDocentiMock(), new RepositoryLezioniMock(), new RepositoryStudentiMock());
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiEF(), new RepositoryDocentiEF(), new RepositoryLezioniEF(), new RepositoryStudentiEF());

        static void Main(string[] args)
        {
            bool continua = true;

            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static int SchermoMenu()
        {
            Console.WriteLine("******************Menu****************");
            //Funzionalità su Corsi
            Console.WriteLine("\nFunzionalità CORSI");
            Console.WriteLine("1. Visualizza Corsi");
            Console.WriteLine("2. Inserisci nuovo Corso");
            Console.WriteLine("3. Modifica Corso");
            Console.WriteLine("4. Elimina Corso");
            //Funzionalità su Docenti
            Console.WriteLine("\nFunzionalità Docenti");
            Console.WriteLine("5. Visualizza Docenti");
            Console.WriteLine("6. Inserisci nuovo Docente");
            Console.WriteLine("7. Modifica Docente");
            Console.WriteLine("8. Elimina Docente");
            //Funzionalità su Lezioni
            Console.WriteLine("\nFunzionalità Lezioni");
            Console.WriteLine("9. Visualizza elenco delle lezioni completo");
            Console.WriteLine("10. Inserimento nuova lezione");
            Console.WriteLine("11. Modifica lezione");//per semplicità solo modifica Aula
            Console.WriteLine("12. Elimina lezione");
            Console.WriteLine("13. Visualizza le Lezioni di un Corso ricercando per Codice del Corso");
            Console.WriteLine("14. Visualizza le Lezioni di un Corso ricercando per Nome del Corso");
            //Funzionalità su Studenti
            Console.WriteLine("\nFunzionalità Studenti");
            Console.WriteLine("15. Visualizza l'elenco completo degli studenti");
            Console.WriteLine("16. Inserimento nuovo Studente");
            Console.WriteLine("17. Modifica Studente");//per semplicità solo email
            Console.WriteLine("18. Elimina Studente");
            Console.WriteLine("19. Visualizza l'elenco degli studenti iscritti ad un corso");

            //Exit
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("********************************************");


            int scelta;
            Console.Write("Inserisci scelta: ");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 19)
            {
                Console.Write("\nScelta errata. Inserisci scelta corretta: ");
            }
            return scelta;


        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                //Corsi
                case 1:
                    VisualizzaCorsi();
                    break;
                case 2:
                    InserisciNuovoCorso();
                    break;
                case 3:
                    ModificaCorso();
                    break;
                case 4:
                    EliminaCorso();
                    break;
                //Docenti
                case 5:
                    VisualizzaDocenti();
                    break;
                case 6:
                    InserisciNuovoDocente();
                    break;
                case 7:
                    ModificaDocente();
                    break;
                case 8:
                    EliminaDocente();
                    break;
                //Lezioni
                case 9:
                    VisualizzaLezioni();
                    break;
                case 10:
                    InserisciNuovaLezione();
                    break;
                case 11:
                    ModificaLezione();
                    break;
                case 12:
                    EliminaLezione();
                    break;
                case 13:
                    VisializzaLezionePerCodiceCorso();
                    break;
                case 14:
                    VisualizzaLezionePerNomeCorso();
                    break;
                 //Studenti
                case 15:
                    VisualizzaStudenti();
                    break;
                case 16:
                    InserisciNuovoStudente();
                    break;
                case 17:
                    ModificaStudente();
                    break;
                case 18:
                    EliminaStudente();
                    break;
                case 19:
                    VisualizzaStudentiIscrittiCorso();
                    break;
                case 0:
                    return false;
            }
            return true;
        }



        #region Lezioni
        private static void VisualizzaLezionePerNomeCorso()
        {
            Console.WriteLine("Inserisci il nome del corso:");
            string nomeCorso = Console.ReadLine();

            var lezioni = bl.GetLezioniByNomeCorso(nomeCorso);

            if (lezioni == null)
            {
                Console.WriteLine("Errore. Non esiste nessun corso con questo nome");
            }
            else if (lezioni.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item);
                }
            }
        }
        private static void VisializzaLezionePerCodiceCorso()
        {
            Console.WriteLine("Inserisci il codice del corso:");
            string corsoCode = Console.ReadLine();

            var lezioni = bl.GetLezioniByCodiceCorso(corsoCode);
            if (lezioni == null)
            {
                Console.WriteLine("Codice corso errato.");
            }
            else if (lezioni.Count == 0)
            {
                Console.WriteLine("Lista vuota.");
            }
            else
            {
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item);
                }
            }
        }
        private static void EliminaLezione()
        {
            //Interazione con utente            
            Console.WriteLine("Elenco completo delle lezioni disponibili:");

            VisualizzaElencoLezioni();

            Console.WriteLine("Quale lezione vuoi eliminare? Inserisci l'id");
            int idLezioneDaEliminare = int.Parse(Console.ReadLine());

            string esito = bl.EliminaLezione(idLezioneDaEliminare);
            Console.WriteLine(esito);
        }
        private static void ModificaLezione()
        {
            //Supponiamo che si può modificare solo l'aula della lezione (per semplicità)
            VisualizzaElencoLezioni();

            Console.WriteLine("Per quale lezione vuoi modificare l'aula? Inserisci l'id della lezione");
            int idLezioneDaModificare = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci la nuova Aula:");
            string nuovaAula = Console.ReadLine();

            string esito = bl.ModificaLezione(idLezioneDaModificare, nuovaAula);
            Console.WriteLine(esito);
        }
        private static void VisualizzaElencoLezioni()
        {
            var lezioni = bl.GetAllLezioni();
            if (lezioni.Count == 0)
            {
                Console.WriteLine("Nessuna Lezione presente");
            }
            else
            {
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item);
                }
            }
        }
        private static void InserisciNuovaLezione()
        {
            //chiedo le info che mi servono per creare la lezione 
            Console.WriteLine("Inserisci i dati della lezione:");

            Console.Write("Data e ora di inizio (formato gg-mm-aaaa hh:mm): ");
            DateTime dataOraInizio = DateTime.Parse(Console.ReadLine()); //Aggiungere Eventuali controlli (es. do-while..)

            Console.Write("\nDurata (in gg): ");
            int durataGG = int.Parse(Console.ReadLine());//Aggiungere eventuali controlli

            Console.Write("\nAula: ");
            string aula = Console.ReadLine();

            Console.Write("\nCodice Corso a cui si vuole Associare: ");

            VisualizzaCorsi();

            string codiceCorso = Console.ReadLine();
            Console.WriteLine("Elenco docenti disponibili:");

            VisualizzaDocenti();

            Console.Write("\nId Docente che terrà la lezione: ");
            int docenteId = int.Parse(Console.ReadLine());

            //la creo
            Lezione nuovaLezione = new Lezione();
            nuovaLezione.DataOraInizio = dataOraInizio;
            nuovaLezione.Durata = durataGG;
            nuovaLezione.Aula = aula;
            nuovaLezione.CorsoCodice = codiceCorso;
            nuovaLezione.DocenteID = docenteId;

            //la passo a business layer per i controlli
            string esito = bl.AggiungiLezione(nuovaLezione);
            //stampo esito
            Console.WriteLine(esito); 
        }
        private static void VisualizzaLezioni()
        {
            var lezioni = bl.GetAllLezioni();
            if (lezioni.Count == 0)
            {
                Console.WriteLine("Lezioni non presenti");
            }
            else
            {
                Console.WriteLine("***Le lezioni disponibili sono:***\n");
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        #endregion

        #region Docenti
        private static void EliminaDocente()
        {
            Console.WriteLine("Elenco dei Docenti presenti");
            VisualizzaDocenti();
            Console.WriteLine("Quale docente vuoi eliminare? inserisci l'ID");
            int id = int.Parse(Console.ReadLine());

            var esito = bl.EliminaDocente(id);
            Console.WriteLine(esito);
        }
        private static void ModificaDocente()
        {
            Console.WriteLine("Elenco Docenti:");
            VisualizzaDocenti();
            Console.WriteLine("Quale Docente vuoi modificare? inserisci l'ID del docente");
            int idDaModificare = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci l'email:");
            string nuovaEmail = Console.ReadLine();

            var esito = bl.ModificaDocente(idDaModificare, nuovaEmail);
            Console.WriteLine(esito);
        }
        private static void InserisciNuovoDocente()
        {
            Console.WriteLine("Inserisci Nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Inserisci Cognome:");
            string cognome = Console.ReadLine();

            Console.WriteLine("Inserisci l'email:");
            string email = Console.ReadLine();

            Console.WriteLine("Inserisci Cellulare:");
            string telefono = Console.ReadLine();

            Docente nuovoDocente = new Docente();
            nuovoDocente.Nome = nome;
            nuovoDocente.Cognome = cognome;
            nuovoDocente.Email = email;
            nuovoDocente.Telefono = telefono;

            var esito = bl.InserisciNuovoDocente(nuovoDocente);
            Console.WriteLine(esito);

        }
        private static void VisualizzaDocenti()
        {
            var docenti = bl.GetAllDocenti();
            if (docenti.Count == 0)
            {
                Console.WriteLine("Docenti non presenti");
            }
            else
            {
                Console.WriteLine("***I docenti in elenco sono:***\n");
                foreach (var item in docenti)
                {
                    Console.WriteLine(item);
                }
            }
        }
        #endregion

        #region Studenti
        private static void VisualizzaStudentiIscrittiCorso()
        {
            Console.WriteLine("Elenco dei corsi:");
            VisualizzaCorsi();
            Console.WriteLine("Iserisci il codice del corso scelto: ");
            string codice = Console.ReadLine();

            var esito = bl.VisualizzaStudentiCorso(codice);
            Console.WriteLine(esito);

            if (esito == null)
            {
                Console.WriteLine("Errore! codice corso Errato");
            }
            if (esito.Count == 0)
            {
                Console.WriteLine("Errore! Non è presente nessuno studente iscritto per questo corso");
            }
            else
            {
                foreach(var item in esito)
                {
                    Console.WriteLine(item);
                }
            }

        }
        private static void EliminaStudente()
        {
            Console.WriteLine("Elenco dei Studenti iscritti");
            VisualizzaStudenti();
            Console.WriteLine("Quale studente vuoi eliminare? inserisci l'ID");
            int id = int.Parse(Console.ReadLine());

            var esito = bl.EliminaStudente(id);
            Console.WriteLine(esito);

        }
        private static void ModificaStudente()
        {
            Console.WriteLine("Elenco Studenti:");
            VisualizzaStudenti();
            Console.WriteLine("Quale studente vuoi modificare? inserisci l'ID dello studente");
            int idDaModificare = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci l'email:");
            string nuovaEmail = Console.ReadLine();

            var esito = bl.ModificaStudente(idDaModificare, nuovaEmail);
            Console.WriteLine(esito);

        }
        private static void InserisciNuovoStudente()
        {
            //Chiedo le info per creare il nuovo studente
            Console.WriteLine("Inserisci Nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Inserisci Cognome:");
            string cognome = Console.ReadLine();

            Console.WriteLine("Inserisci l'email:");
            string email = Console.ReadLine();

            Console.WriteLine("Inserisci la Data di Nascita (formato: gg-mm-aaaa):");
            DateTime dataNascita = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci il Titolo di Studio:");
            string titoloStudio = Console.ReadLine();

            VisualizzaCorsi();

            Console.WriteLine("inserisci codice corso che ti interessa:");
            string codiceCorso = Console.ReadLine();

            //lo creo
            Studente nuovoStudente = new Studente();

            nuovoStudente.Nome = nome;
            nuovoStudente.Cognome = cognome;
            nuovoStudente.DataNascita = dataNascita;
            nuovoStudente.Email = email;
            nuovoStudente.TitoloStudio = titoloStudio;
            nuovoStudente.CorsoCodice = codiceCorso;

            //Lo passo al business layer per controllare i dati ed aggiungerlo poi nel "Db"
            var esito = bl.InserisciNuovoStudente(nuovoStudente);
            Console.WriteLine(esito);

        }
        private static void VisualizzaStudenti()
        {
            var studenti = bl.GetAllStudenti();
            if (studenti.Count == 0)
            {
                Console.WriteLine("Studenti non presenti");
            }
            else
            {
                Console.WriteLine("***Gli studenti in elenco sono:***\n");
                foreach (var item in studenti)
                {
                    Console.WriteLine(item);
                }
            }
        }
        #endregion

        #region Corsi
        private static void EliminaCorso()
        {
            Console.WriteLine("Elenco dei corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi eliminare? Inserisci il codice");
            string codice = Console.ReadLine();

            var esito = bl.EliminaCorso(codice);
            Console.WriteLine(esito);

        }
        private static void ModificaCorso()
        {
            Console.WriteLine("Elenco dei corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi modificare? Inserisci il codice");
            string codice = Console.ReadLine();

            Console.WriteLine("Inserisci il nome");
            string nuovoNome = Console.ReadLine();

            Console.WriteLine("Inserisci la descrizione");
            string nuovaDescrizione = Console.ReadLine();

            var esito = bl.ModificaCorso(codice, nuovoNome, nuovaDescrizione);
            Console.WriteLine(esito);

        }
        private static void InserisciNuovoCorso()
        {
            //Chiedo all'utenti i dati per creare un nuovo corso 
            Console.WriteLine("Inserisci il codice del nuovo corso");
            string codice = Console.ReadLine();

            Console.WriteLine("Inserisci il nome del nuovo corso");
            string nome = Console.ReadLine();

            Console.WriteLine("Inserisci la descrizione del nuovo corso");
            string descrizione = Console.ReadLine();

            //Lo creo
            Corso nuovoCorso = new Corso();
            nuovoCorso.Nome = nome;
            nuovoCorso.CodiceCorso = codice;
            nuovoCorso.Descrizione = descrizione;

            //Lo passo al business layer per controllare i dati ed aggiungerlo poi nel "Db"
            string esito = bl.InserisciNuovoCorso(nuovoCorso);
            Console.WriteLine(esito);

        }
        private static void VisualizzaCorsi()
        {
            var corsi = bl.GetAllCorsi();
            if(corsi.Count == 0)
            {
                Console.WriteLine("Corsi non presenti");
            }
            else
            {
                Console.WriteLine("***I Corsi disponibili sono:***\n");
                foreach (var item in corsi)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            
        }
        #endregion
    }
}
