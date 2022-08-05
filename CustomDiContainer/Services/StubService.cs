using CustomDiContainer.Logger;

namespace CustomDiContainer.Services
{
    public class StubService : IService
    {
        private ILogger _logger;

        public StubService(ILogger logger)
        {
            _logger = logger;
        }

        public void GetProducts()
        {
            Console.WriteLine("StubServiceProducts");
            _logger.SaveLog();
        }
    }
}
