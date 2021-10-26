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
    public class DocenteController : Controller
    {
        private readonly IBusinessLayer BL;

        public DocenteController(IBusinessLayer bl)
        {
            BL = bl;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var docenti = BL.GetAllDocenti();

            List<DocenteViewModel> docentiViewModel = new List<DocenteViewModel>();

            foreach (var item in docenti)
            {
                docentiViewModel.Add(item.ToDocenteViewModel());
            }

            return View(docentiViewModel);
        }
        [HttpGet("Docente/Details/{id}")]
        public IActionResult Details(int id)
        {
            var docente = BL.GetAllDocenti().FirstOrDefault(d => d.ID == id);

            var decenteViewModel = docente.ToDocenteViewModel();

            return View(decenteViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docenteViewModel.ToDocente();
                BL.InserisciNuovoDocente(docente);
                return RedirectToAction(nameof(Index))
;
            }
            return View(docenteViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var docente = BL.GetAllDocenti().FirstOrDefault(d => d.ID == id);
            var docenteViewModel = docente.ToDocenteViewModel();
            return View(docenteViewModel);
        }

        [HttpPost]
        public IActionResult Edit(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docenteViewModel.ToDocente();
                BL.ModificaDocente(docente.ID, docente.Email);
                return RedirectToAction(nameof(Index));
            }
            return View(docenteViewModel);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var docente = BL.GetAllDocenti().FirstOrDefault(d => d.ID == id);
            var docenteViewModel = docente.ToDocenteViewModel();
            return View(docenteViewModel);
        }

        [HttpPost]
        public IActionResult Delete(DocenteViewModel docenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var docente = docenteViewModel.ToDocente();
                BL.EliminaDocente(docente.ID);
                return RedirectToAction(nameof(Index));
            }
            return View(docenteViewModel);
        }
    }
}
