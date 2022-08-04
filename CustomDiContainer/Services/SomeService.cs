using CustomDiContainer.Logger;

namespace CustomDiContainer.Services
{
    public class SomeService : IService
    {
        private ILogger _logger;

        public SomeService(ILogger logger)
        {
            _logger = logger;
        }

        public void GetProducts()
        {
            Console.WriteLine("SomeServiceProducts");
            _logger.SaveLog();
        }
    }
}
