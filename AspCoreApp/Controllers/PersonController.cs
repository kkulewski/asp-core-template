using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspCoreApp.Data.Repositories.Abstract;
using AspCoreApp.Models;

namespace AspCoreApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepo;
        private readonly IAddressRepository _addressRepo;

        public PersonController(IPersonRepository personRepo, IAddressRepository addressRepo)
        {
            _personRepo = personRepo;
            _addressRepo = addressRepo;
        }

        // GET: People
        public IActionResult Index()
        {
            var people = _personRepo.GetAll();
            return View(people);
        }

        // GET: People/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _personRepo.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_addressRepo.GetAll(), "Id", "FullAddress");
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,AddressId")] Person person)
        {
            if (ModelState.IsValid)
            {
                _personRepo.Add(person);
                return RedirectToAction(nameof(Index));
            }

            ViewData["AddressId"] = new SelectList(_personRepo.GetAll(), "Id", "FullAddress", person.AddressId);
            return View(person);
        }

        // GET: People/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _personRepo.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            ViewData["AddressId"] = new SelectList(_addressRepo.GetAll(), "Id", "FullAddress", person.AddressId);
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Id,FirstName,LastName,AddressId")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _personRepo.Update(person);
                return RedirectToAction(nameof(Index));
            }

            ViewData["AddressId"] = new SelectList(_addressRepo.GetAll(), "Id", "FullAddress", person.AddressId);
            return View(person);
        }

        // GET: People/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _personRepo.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _personRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
