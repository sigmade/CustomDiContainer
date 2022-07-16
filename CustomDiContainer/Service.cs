namespace CustomDiContainer
{
    public class Service : IService
    {
        private Logger _logger;

        public Service(Logger logger)
        {
            _logger = logger;
        }

        public void GetProducts()
        {
            Console.WriteLine("SomeProducts");
            _logger.SaveLog();
        }
    }
}
