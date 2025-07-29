using ClinikData.Models;
using ClinikData.Services;
using ClinikData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ClinikData.Controllers
{
    public class DoctorsController : Controller
    {
        public ClinicContext context;
        public AnotherService anotherService;
        public DoctorService doctorService;

        public DoctorsController(ClinicContext context, AnotherService anotherService, DoctorService doctorService)
        {
            this.context = context;
            this.anotherService = anotherService;
            this.doctorService = doctorService;
        }

        public IActionResult Index()
        {
            var doctors = context.Doctors.Select(p => p.ToDoctorsVM()).ToList();
            return View(doctors);
        }


        public IActionResult Details(int id)
        {

            var doctors = context.Doctors

                            .Include(p => p.Appointments)
                            .ThenInclude(a => a.Doctor)
                            .FirstOrDefault(p => p.Id == id);
            if (doctors == null)
                return NotFound();
        }

        public IActionResult Create()
        {
            var vm = new DoctorsCreateVM();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DoctorsCreateVM newDoctor)
        {

            if (!ModelState.IsValid)
            {
                return View(newDoctor);
            }

            var doctor = newDoctor.ToDoctors();
            context.Doctors.Add(doctor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var doctor = context.Doctors.FirstOrDefault(p => p.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            var vm = doctor.ToDoctorsUpdateVM();
            return View(vm);
        }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Update(int id, DoctorsUpdateVM updateDoctor)
            {

                if (!ModelState.IsValid)
                {
                    return View(updateDoctor);
                }

                var existingPatient = context.Doctors.FirstOrDefault(p => p.Id == id);
                if (existingPatient == null)
                {
                    return NotFound();
                }

                updateDoctor.ToDoctor(existingPatient);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


             public IActionResult Delete(int id)
             {
            var doctor = context.Doctors.FirstOrDefault(p => p.Id == id);
            if (doctor == null)
              {
                return NotFound();
              }

            context.Doctors.Remove(doctor);
            context.SaveChanges();
            return Ok();
             }





    }
}
