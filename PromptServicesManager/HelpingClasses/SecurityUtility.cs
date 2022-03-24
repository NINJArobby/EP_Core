using System.ComponentModel;
using System.Diagnostics;
using System.Security.Principal;

namespace PromptServicesManager.HelpingClasses;

public static class SecurityUtility
{
    public static bool IsAdministrator()
    {
        var identity = WindowsIdentity.GetCurrent();

        if (null != identity)
        {
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        return false;
    }

    public static Process RunProcess(string name, string arguments)
    {
        var path = Path.GetDirectoryName(name);

        if (string.IsNullOrEmpty(path))
        {
            path = Environment.CurrentDirectory;
        }

        var info = new ProcessStartInfo
        {
            UseShellExecute = true,
            WorkingDirectory = path,
            FileName = name,
            Arguments = arguments
        };

        if (!IsAdministrator())
        {
            info.Verb = "runas";
        }

        try
        {
            return Process.Start(info);
        }

        catch (Win32Exception ex)
        {
            Trace.WriteLine(ex);
        }

        return null;
    }
}