namespace ClinikData.Services
{
    public class AnotherService
    {

        public DoctorService doctorService { get; set; }

        public AnotherService(DoctorService doctorService)
        {

        }

        public PatientService patientService;

        public AnotherService(PatientService patientService)
        {

        }

    }
}
