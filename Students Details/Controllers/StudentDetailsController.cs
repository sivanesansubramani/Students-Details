using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Students_Details.Models;
using Students_Details.Repository;

namespace Students_Details.Controllers
{
    public class StudentDetailsController : Controller
    {
        // GET: StudentDetailsController


        StudentDetailsRepo ObjRepository;

        public StudentDetailsController()
        {
            ObjRepository = new StudentDetailsRepo();
        }

        public ActionResult List()
        {
            return View("List", ObjRepository.Select());
        }

        // GET: StudentDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonalDataController/Create
        public ActionResult InsertRecord()
        {
            return View("Insert", new Studentmodels());
        }

        // POST: PersonalDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Studentmodels data)
        {
            try
            {
                ObjRepository.InsertStudentDetails(data);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }


        // GET: StudentDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
