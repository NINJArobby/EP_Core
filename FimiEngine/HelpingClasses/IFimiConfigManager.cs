namespace FimiEngine.HelpingClasses;

public interface IFimiConfigManager
{
    string FimiDbConnection { get; }

    string GetConnectionString(string connectionName);

    string GetConfigurationSection(string Key);
}