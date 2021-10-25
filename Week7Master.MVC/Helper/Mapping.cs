using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7Master.Core.Entities;
using Week7Master.MVC.Models;

namespace Week7Master.MVC.Helper
{
    public static class Mapping
    {
        #region Corsi
        public static CorsoViewModel ToCorsoViewModel(this Corso corso)
        {

            return new CorsoViewModel
            {
                CodiceCorso = corso.CodiceCorso,
                Nome = corso.Nome,
                Descrizione = corso.Descrizione
            };
        }

        public static Corso ToCorso(this CorsoViewModel corsoViewModel)
        {

            return new Corso
            {
                CodiceCorso = corsoViewModel.CodiceCorso,
                Nome = corsoViewModel.Nome,
                Descrizione = corsoViewModel.Descrizione,
            };
        }
        #endregion

        #region Docenti
        public static DocenteViewModel ToDocenteViewModel(this Docente docente)
        {
            return new DocenteViewModel
            {
                ID = docente.ID,
                Nome = docente.Nome,
                Cognome = docente.Cognome,
                Email = docente.Email,
                Telefono = docente.Telefono
            };
        }

        public static Docente ToDocente(this DocenteViewModel docenteViewModel)
        {
            return new Docente
            {
                ID = docenteViewModel.ID,
                Nome = docenteViewModel.Nome,
                Cognome = docenteViewModel.Cognome,
                Email = docenteViewModel.Email,
                Telefono = docenteViewModel.Telefono
            };
        }
        #endregion

        #region Studenti
        public static StudenteViewModel ToStudenteViewModel(this Studente studente)
        {
            return new StudenteViewModel
            {
                ID = studente.ID,
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                Email = studente.Email,
                DataNascita = studente.DataNascita,
                TitoloStudio = studente.TitoloStudio
            };
        }

        public static Studente ToStudente(this StudenteViewModel studenteViewModel)
        {
            return new Studente
            {
                ID = studenteViewModel.ID,
                Nome = studenteViewModel.Nome,
                Cognome = studenteViewModel.Cognome,
                Email = studenteViewModel.Email,
                DataNascita = studenteViewModel.DataNascita,
                TitoloStudio = studenteViewModel.TitoloStudio
            };
        }
        #endregion
    }
}
