using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        // GET: Registration/Details/5
        public ActionResult Details(int id)
        {
            var res = ObjRepository.SelectSP(id);
            return View("QR", res);
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


        // GET: PersonalDataController/Edit/5
        public ActionResult Edit(int Studid)
        {
            var res = ObjRepository.SelectSP(Studid);
            return View("Ubdate", res);
        }

        // POST: PersonalDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Studid, Studentmodels Reg)
        {
            try
            {
                Reg.Studid = Studid;
                ObjRepository.ubdate(Reg);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Delete/5
        [HttpGet]
        public ActionResult Delete(int Studid)
        {
            var res = ObjRepository.SelectSP(Studid);
            return View("Delete", res);
        }

        // POST: Registration/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int Studid)
        {
            try
            {
                ObjRepository.delete(Studid);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
