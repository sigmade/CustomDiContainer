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

        public void Start()
        {
            Console.WriteLine("Controller Started");
            _service.GetProducts();
        }
    }
}
