namespace CustomDiContainer.Logger
{
    public class Log : ILogger
    {
        public void SaveLog()
        {
            Console.WriteLine("Logs saved");
        }
    }
}
