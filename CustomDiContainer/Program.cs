namespace CustomDiContainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var container = new Container();

            //container.RegisterInstance<Logger>(new Logger());
            //container.Register<IService, StubService>();

            //container.GetInstance(typeof(MainController));

            var services = new SimpleContainer();
            services.AddNew(typeof(IService), typeof(StubService));
            services.AddNew(typeof(Logger), typeof(Logger));
            services.GetInstance(typeof(MainController));


            Console.ReadKey();
        }
    }
}