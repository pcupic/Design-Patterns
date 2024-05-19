public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class FilerLoggerService
{
    public void LogToFile(string message)
    {
        Console.WriteLine($"Logging message to file. Message:{message}");
    }
}

public class FileLoggerAdapter : ILogger
{
    FilerLoggerService service;
    public FileLoggerAdapter()
    {
        service = new FilerLoggerService();
    }
    public void Log(string message)
    {
        service.LogToFile(message);
    }
}

public static class ClientCode
{
    public static void Run()
    {
        ILogger logger = new ConsoleLogger();

        logger.Log("Hello World");
    }
}