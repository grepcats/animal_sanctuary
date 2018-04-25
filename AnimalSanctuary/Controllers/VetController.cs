using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalSanctuary.Models.Repositories;
using AnimalSanctuary.Models;
using Microsoft.EntityFrameworkCore;


namespace AnimalSanctuary.Controllers
{
    public class VetController : Controller
    {
        private IVetRepository vetRepo;

        public VetController(IVetRepository repo = null)
        {
            if (repo == null)
            {
                this.vetRepo = new EFVetRepository();
            }
            else
            {
                this.vetRepo = repo;
            }
        }

        public ViewResult Index()
        {
            // Updated:
            return View(vetRepo.Vets.ToList());
        }
        public IActionResult Details(int id)
        {
            Vet thisVet = vetRepo.Vets.FirstOrDefault(x => x.VetId == id);
            return View(thisVet);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vet vet)
        {
            vetRepo.Save(vet);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Vet thisVet = vetRepo.Vets.FirstOrDefault(x => x.VetId == id);
            return View(thisVet);
        }

        [HttpPost]
        public IActionResult Edit(Vet vet)
        {
            vetRepo.Edit(vet);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Vet thisVet = vetRepo.Vets.FirstOrDefault(x => x.VetId == id);
            return View(thisVet);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Vet thisVet = vetRepo.Vets.FirstOrDefault(x => x.VetId == id);
            vetRepo.Remove(thisVet);
            return RedirectToAction("Index");
        }
    }
}
