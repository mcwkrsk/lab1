// Интерфейс логгера
public interface ILogger
{
    void Log(string message);
}

// Логгер в консоль
public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine($"[CONSOLE] {message}");
}

// Логгер в файл
public class FileLogger : ILogger
{
    private readonly string _filePath;
    public FileLogger(string filePath) => _filePath = filePath;
    public void Log(string message)
    {
        File.AppendAllText(_filePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        Console.WriteLine($"[FILE] Записано в {_filePath}");
    }
}

// Логгер на удалённый сервер (эмуляция)
public class RemoteLogger : ILogger
{
    private readonly string _serverUrl;
    public RemoteLogger(string serverUrl) => _serverUrl = serverUrl;
    public void Log(string message)
    {
        // В реальном коде здесь был бы HTTP-запрос
        Console.WriteLine($"[REMOTE] Отправка на {_serverUrl}: {message}");
    }
}

// Фабрика логгеров
public static class LoggerFactory
{
    private static readonly Dictionary<string, Func<string?, ILogger>> _registry = new()
    {
        ["console"] = _ => new ConsoleLogger(),
        ["file"] = p => new FileLogger(p ?? "log.txt"),
        ["remote"] = p => new RemoteLogger(p ?? "https://example.com/log"),
    };

    public static void Register(string key, Func<string?, ILogger> factory)
        => _registry[key] = factory;

    public static ILogger CreateLogger(string type, string? param = null)
    {
        if (_registry.TryGetValue(type, out var factory))
            return factory(param);
        throw new ArgumentException($"Неизвестный тип: {type}");
    }
}