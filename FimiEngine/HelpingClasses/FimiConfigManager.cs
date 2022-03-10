using Microsoft.Extensions.Configuration;

namespace FimiEngine.HelpingClasses;

public class FimiConfigManager : IFimiConfigManager
{
    private readonly IConfiguration _configuration;

    public FimiConfigManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string FimiDbConnection => _configuration["ConnectionStrings:FimiDatabase"];

    public string GetConnectionString(string connectionName)
    {
        return _configuration["FimiDatabase"];
    }

    public string GetConfigurationSection(string Key)
    {
        return _configuration.GetConnectionString(Key);
    }
}