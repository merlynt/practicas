using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica_1.Models;
using Practica_1.Repositories;

namespace Practica_1.Controllers
{
    public class StaffCategoryController : Controller
    {
        private readonly StaffCategoryRepository _staffCategoryRepository;

        public StaffCategoryController(StaffCategoryRepository staffCategoryRepository)
        {
            _staffCategoryRepository = staffCategoryRepository;
        }

        // GET: StaffCategoryController
        public IActionResult Index()
        {
            var staffCategoryRepositoryList = _staffCategoryRepository.GetAll();
            return View(staffCategoryRepositoryList);
        }

        // GET: staffCategoryController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: staffCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StaffCategoryModel staffCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                _staffCategoryRepository.Add(staffCategoryModel);
                return RedirectToAction(nameof(Index));
            }
            return View(staffCategoryModel);
        }

        // GET: staffCategoryController/Edit/5
        public IActionResult Edit(int id)
        {
            var staffCategory = _staffCategoryRepository.GetById(id);

            if (staffCategory == null) return NotFound();

            return View(staffCategory);
        }

        // POST: staffCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StaffCategoryModel staffCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                _staffCategoryRepository.Update(staffCategoryModel);
                return RedirectToAction(nameof(Index));
            }
            return View(staffCategoryModel);
        }

        public IActionResult Delete(int id)
        {
            var staffCategory = _staffCategoryRepository.GetById(id);
            if (staffCategory == null) return NotFound();
            return View(staffCategory);
        }

        // POST: staffCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(StaffCategoryModel staffCategoryModel)
        {
            _staffCategoryRepository.Delete(staffCategoryModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
