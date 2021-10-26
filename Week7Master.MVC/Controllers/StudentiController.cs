using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7Master.Core.BusinessLayer;
using Week7Master.MVC.Helper;
using Week7Master.MVC.Models;

namespace Week7Master.MVC.Controllers
{
    public class StudentiController : Controller
    {
        private readonly IBusinessLayer BL;

        public StudentiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var studenti = BL.GetAllStudenti();

            List<StudenteViewModel> studentiViewModel = new List<StudenteViewModel>();

            foreach (var item in studenti)
            {
                studentiViewModel.Add(item.ToStudenteViewModel());
            }

            return View(studentiViewModel);
        }
        [HttpGet("Studenti/Details/{id}")]
        public IActionResult Details(int id)
        {
            var studente = BL.GetAllStudenti().FirstOrDefault(s => s.ID == id);

            var studenteViewModel = studente.ToStudenteViewModel();

            return View(studenteViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = studenteViewModel.ToStudente();
                BL.InserisciNuovoStudente(studente);
                return RedirectToAction(nameof(Index))
;
            }
            return View(studenteViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var studente = BL.GetAllStudenti().FirstOrDefault(s => s.ID == id);
            var studenteViewModel = studente.ToStudenteViewModel();
            return View(studenteViewModel);
        }

        [HttpPost]
        public IActionResult Edit(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = studenteViewModel.ToStudente();
                BL.ModificaStudente(studente.ID, studente.Email);
                return RedirectToAction(nameof(Index));
            }
            return View(studenteViewModel);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var studente = BL.GetAllStudenti().FirstOrDefault(s => s.ID == id);
            var studenteViewModel = studente.ToStudenteViewModel();
            return View(studenteViewModel);
        }

        [HttpPost]
        public IActionResult Delete(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = studenteViewModel.ToStudente();
                BL.EliminaStudente(studente.ID);
                return RedirectToAction(nameof(Index));
            }
            return View(studenteViewModel);
        }
    }
}
