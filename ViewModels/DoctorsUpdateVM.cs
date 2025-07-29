using ClinikData.Models;
using System.ComponentModel.DataAnnotations;

namespace ClinikData.ViewModels
{
    public class DoctorsUpdateVM
    {

        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "National Id")]
        public string NationalId { get; set; }

        public string Email { get; set; }

        [RegularExpression("05\\d{8}", ErrorMessage = "Phone number must be in format 05xxxxxxxx")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now.AddYears(-20);


        public void ToDoctor(Doctor doctor)
        {
            doctor.FullName = FullName;
            doctor.NationalId = NationalId;
            doctor.Email = Email;
            doctor.PhoneNumber = PhoneNumber;
            doctor.DateOfBirth = DateOfBirth;
        }





    }
}

