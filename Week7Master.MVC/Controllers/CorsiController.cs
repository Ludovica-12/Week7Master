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
    public class CorsiController : Controller
    {
        private readonly IBusinessLayer BL;

        public CorsiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        //CRUD su Corso

        //url: https://...corsi
        [HttpGet]
        public IActionResult Index()
        {
            var corsi = BL.GetAllCorsi();

            List<CorsoViewModel> corsiViewModel = new List<CorsoViewModel>();

            foreach (var item in corsi)
            {
                corsiViewModel.Add(item.ToCorsoViewModel());
            }

            return View(corsiViewModel);
        }
        [HttpGet("Corsi/Details/{codice}")]
        public IActionResult Details(string code)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CodiceCorso == code);

            var corsoViewModel = corso.ToCorsoViewModel();

            return View(corsoViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CorsoViewModel corsoViewModel)
        {
            if(ModelState.IsValid)
            {
                var corso = corsoViewModel.ToCorso();
                BL.InserisciNuovoCorso(corso);
                return RedirectToAction(nameof(Index))
;            }
            return View(corsoViewModel);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CodiceCorso == id);
            var corsoViewModel = corso.ToCorsoViewModel();
            return View(corsoViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = corsoViewModel.ToCorso();
                BL.ModificaCorso(corso.CodiceCorso, corso.Nome, corso.Descrizione);
                return RedirectToAction(nameof(Index));
            }
            return View(corsoViewModel);

        }


        [HttpGet]
        public IActionResult Delete(string id)
        {
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CodiceCorso == id);
            var corsoViewModel = corso.ToCorsoViewModel();
            return View(corsoViewModel);
        }

        [HttpPost]
        public IActionResult Delete(CorsoViewModel corsoViewModel)
        {
            if (ModelState.IsValid)
            {
                var corso = corsoViewModel.ToCorso();
                BL.EliminaCorso(corso.CodiceCorso);
                return RedirectToAction(nameof(Index));
            }
            return View(corsoViewModel);
        }

    }
}
