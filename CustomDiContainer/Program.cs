using CustomDiContainer.Logger;
using CustomDiContainer.Services;
using OurDiContainer;

namespace CustomDiContainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new SimpleContainer();

            services.AddNewService(typeof(ILogger), typeof(Log));
            services.AddNewService(typeof(IService), typeof(SomeService));
            services.GetInstance(typeof(MainController));

            Console.ReadKey();
        }
    }
}