using System.Threading.Tasks;
using AspCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspCoreApp.Data.Repositories.Abstract;
using AspCoreApp.Models;

namespace AspCoreApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IPersonRepository _personRepo;
        private readonly IAddressRepository _addressRepo;

        public PersonController(IUnitOfWork uow, IPersonRepository personRepo, IAddressRepository addressRepo)
        {
            _uow = uow;
            _personRepo = personRepo;
            _addressRepo = addressRepo;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var people = await _personRepo.GetAll();
            return View(people);
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personRepo.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AddressId"] = new SelectList(await _addressRepo.GetAll(), "Id", "FullAddress");
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,AddressId")] Person person)
        {
            if (!ModelState.IsValid)
            {

                ViewData["AddressId"] = new SelectList(await _personRepo.GetAll(), "Id", "FullAddress", person.AddressId);
                return View(person);
            }

            _personRepo.Add(person);
            await _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personRepo.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            ViewData["AddressId"] = new SelectList(await _addressRepo.GetAll(), "Id", "FullAddress", person.AddressId);
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,AddressId")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewData["AddressId"] = new SelectList(await _addressRepo.GetAll(), "Id", "FullAddress", person.AddressId);
                return View(person);
            }

            _personRepo.Update(person);
            await _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _personRepo.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var person = await _personRepo.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            _personRepo.Delete(person);
            await _uow.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
