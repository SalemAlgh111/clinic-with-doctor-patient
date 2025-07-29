using ClinikData.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ClinikData.Models
{
    public class Doctor
    {

        public int Id { get; set; }

        public string? FullName { get; set; }

        public string NationalId { get; set; }

        public string? Email { get; set; }

        [RegularExpression("05\\d{8}", ErrorMessage = "Phone number must be in format 05xxxxxxxx")]
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }


        public DoctorsVM ToDoctorsVM()
        {
            return new DoctorsVM
            {
                Id = Id,
                FullName = FullName,
                DateOfBirth = DateOfBirth,
                Email = Email,
                NationalId = NationalId,
                PhoneNumber = PhoneNumber
            };
        }

        public DoctorsUpdateVM ToDoctorsUpdateVM()
        {
            return new DoctorsUpdateVM()
            {
                 Id = Id ,
                FullName = FullName,
                DateOfBirth = DateOfBirth,
                Email = Email,
                NationalId = NationalId,
                PhoneNumber = PhoneNumber
            };
        }


        public List<Appointment> Appointments { get; set; } = new();


    }
}







