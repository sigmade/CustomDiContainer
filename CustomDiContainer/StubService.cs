namespace CustomDiContainer
{
    public class StubService : IService
    {
        private Logger _logger;

        public StubService(Logger logger)
        {
            _logger = logger;
        }

        public void GetProducts()
        {
            Console.WriteLine("StubProducts");
            _logger.SaveLog();
        }
    }
}
