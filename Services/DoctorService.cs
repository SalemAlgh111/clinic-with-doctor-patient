namespace ClinikData.Services
{
    public class DoctorService
    {

        public static int Count { get; set; }

        public DoctorService()
        {
            Count++;
            Console.WriteLine($"DoctorService #{Count}");
        }


    }
}
