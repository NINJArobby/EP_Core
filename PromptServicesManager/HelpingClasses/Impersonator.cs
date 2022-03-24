using System.Security.Principal;

namespace PromptServicesManager.HelpingClasses;

public class ImpersonateUser
{
    WindowsIdentity identity = WindowsIdentity.GetCurrent();

    void impersonate()
    {
    }
}