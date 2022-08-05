namespace CustomDiContainer.Logger
{
    public class DbLogger : ILogger
    {
        public void SaveLog()
        {
            Console.WriteLine("Logs saved in DB");
        }
    }
}
