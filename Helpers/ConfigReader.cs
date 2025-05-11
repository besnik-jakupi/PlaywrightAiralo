using Microsoft.Extensions.Configuration;

public static class ConfigReader
{
    private static IConfigurationRoot _config;

    static ConfigReader()
    {
        var basePath = AppContext.BaseDirectory;
        var configFilePath = Path.Combine(basePath, "appsettings.json");

        Console.WriteLine($"Current Directory: {basePath}");
        Console.WriteLine($"Looking for config file at: {configFilePath}");

        if (!File.Exists(configFilePath))
        {
            Console.WriteLine("Configuration file not found.");
            throw new FileNotFoundException($"Configuration file not found: {configFilePath}");
        }

        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(basePath) 
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        _config = configBuilder.Build();
    }

    public static string GetBaseUrl() => _config["TestSettings:BaseUrl"];
}
