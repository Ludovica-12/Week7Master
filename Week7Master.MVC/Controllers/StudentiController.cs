using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7Master.Core.BusinessLayer;
using Week7Master.MVC.Helper;

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

            List<StudentiController> studentiViewModel = new List<StudentiController>();

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
    }
}
