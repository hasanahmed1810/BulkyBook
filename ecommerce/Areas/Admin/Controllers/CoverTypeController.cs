﻿using ecommerce.DataAccess;
using ecommerce.Models;
using ecommerce.Repository;
using ecommerce.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CoverTypeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Create(CoverType obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type created successfully";

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(item => item.Id == id);

            if (coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type updated successfully";

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(item => item.Id == id);

            if (coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(item => item.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type deleted successfully";
            return RedirectToAction("Index");

        }
    }

}