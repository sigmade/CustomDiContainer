namespace CustomDiContainer.Logger
{
    public class FileLogger : ILogger
    {
        public void SaveLog()
        {
            Console.WriteLine("Logs saved in file");
        }
    }
}
