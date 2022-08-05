using CustomDiContainer.Services;

namespace CustomDiContainer
{

    public class MainController
    {
        private readonly IService _service;
        public MainController(IService service)
        {
            _service = service;
            Start();
        }

        // Иходная точка работы приложения аналог метода Main в Program
        public void Start()
        {
            Console.WriteLine("App Started");

            // APP Logic.....................

            _service.GetProducts();
        }
    }
}
