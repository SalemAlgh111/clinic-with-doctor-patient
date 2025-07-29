using ClinikData.Models;
using ClinikData.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClinikData.Controllers
{
    public class PatientController : Controller
    {

        public ClinicContext context;

        public PatientController(ClinicContext context)
        {
            this.context = context;
        }

        //public IActionResult Index()
        //{
        //    var patients = context.Patients.Select(p => p.ToPatientVM()).ToList();
        //    return View(patients);
        //}
        public IActionResult Index(PatientFilterVM filter)
        {

            var patients = context.Patients
                                    .Where(p => filter.Id == null || p.Id == filter.Id)
                                    .Where(p => filter.FullName == null || p.FullName.Contains(filter.FullName))
                                    .Where(p => filter.PhoneNumber == null || p.PhoneNumber.StartsWith(filter.PhoneNumber))
                                    .Select(p => p.ToPatientVM())
                                    .ToList();

            var vm = new PatientFilteredListVM
            {
                Data = patients,
                Filter = filter
            };
            return View(vm);
        }
        public IActionResult Details(int id)
        {

            var patient = context.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            var vm = patient.ToPatientVM();
            return View(vm);
        }


        public IActionResult Create()
        {
            var vm = new PatientCreateVM();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PatientCreateVM newPatient)
        {

            if (!ModelState.IsValid)
            {
                return View(newPatient);
            }

            var patient = newPatient.ToPatient();
            context.Patients.Add(patient);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var patient = context.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            var vm = patient.ToPatientUpdateVM();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PatientUpdateVM updatedPatient)
        {

            if (!ModelState.IsValid)
            {
                return View(updatedPatient);
            }

            var existingPatient = context.Patients.FirstOrDefault(p => p.Id == id);
            if (existingPatient == null)
            {
                return NotFound();
            }

            updatedPatient.ToPatient(existingPatient);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var patient = context.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            context.Patients.Remove(patient);
            context.SaveChanges();
            return Ok();
        }



    }

}