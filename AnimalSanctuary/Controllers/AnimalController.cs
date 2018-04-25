using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalSanctuary.Models.Repositories;
using AnimalSanctuary.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalSanctuary.Controllers
{
    public class AnimalController : Controller
    {
        private IAnimalRepository animalRepo;

        public AnimalController(IAnimalRepository repo = null)
        {
            if (repo == null)
            {
                this.animalRepo = new EFAnimalRepository();
            }
            else
            {
                this.animalRepo = repo;
            }
        }

        public ViewResult Index()
        {
            // Updated:
            return View(animalRepo.Animals.ToList());
        }

        public IActionResult Details(int id)
        {
            Animal thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
            return View(thisAnimal);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            animalRepo.Save(animal);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Animal thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
            return View(thisAnimal);
        }

        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            animalRepo.Edit(animal);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Animal thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
            return View(thisAnimal);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Animal thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
            animalRepo.Remove(thisAnimal);
            return RedirectToAction("Index");
        }
    }
}
