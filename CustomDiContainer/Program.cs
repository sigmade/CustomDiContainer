using CustomDiContainer.Logger;
using CustomDiContainer.Services;
using OurDiContainer;

namespace CustomDiContainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new Container();

            services.AddNewService(typeof(ILogger), typeof(DbLogger));
            services.AddNewService(typeof(IService), typeof(StubService));

            // Регистрируем корневой объект, его метод Start будет использоваться
            // как исходная точка работы приложения
            services.AddNewService(typeof(MainController), typeof(MainController));

            Console.ReadKey();
        }
    }
}