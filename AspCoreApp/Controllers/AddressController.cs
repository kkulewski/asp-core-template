﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCoreApp.Data.Repositories.Abstract;
using AspCoreApp.Models;

namespace AspCoreApp.Controllers
{
    [Route("[controller]/[action]")]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepo;

        public AddressController(IAddressRepository addressRepo)
        {
            _addressRepo = addressRepo;
        }

        // GET: Address
        public async Task<IActionResult> Index()
        {
            var addresses = await _addressRepo.GetAll();
            return View(addresses);
        }

        // GET: Address/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _addressRepo.GetById(id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Address/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Street,Number")] Address address)
        {
            if (ModelState.IsValid)
            {
                await _addressRepo.Add(address);
                return RedirectToAction(nameof(Index));
            }

            return View(address);
        }

        // GET: Address/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _addressRepo.GetById(id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Address/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Street,Number")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _addressRepo.Update(address);
                return RedirectToAction(nameof(Index));
            }

            return View(address);
        }

        // GET: Address/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _addressRepo.GetById(id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _addressRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
