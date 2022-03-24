using System.ServiceProcess;
using PromptServicesManager.Controllers;
using LogLevel = NLog.LogLevel;

namespace PromptServicesManager.HelpingClasses;

public class ServicesUtility
{
    private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    public static ResponseObject ToggleService(ServiceRequestObject data)
    {
        var res = new ResponseObject();
        try
        {
            var sc = new ServiceController(data.ServiceName, data.MachineIp);
            switch (data.ToggleState)
            {
                case 1:
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running);
                    return new ResponseObject()
                    {
                        Status = sc.Status.ToString()
                    };
                    break;
                case 2:
                    sc.Pause();
                    sc.WaitForStatus(ServiceControllerStatus.Paused);
                    return new ResponseObject()
                    {
                        Status = sc.Status.ToString()
                    };
                    break;
                case 3:
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                    return new ResponseObject()
                    {
                        Status = sc.Status.ToString()
                    };

                    break;
            }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "ToggleServiceError:" + e.Message);
            res.Status = e.Message;
        }

        return res;
    }

    public static string CheckServiceStatus(ServiceRequestObject data)
    {
        try
        {
            var sc = new ServiceController(data.ServiceName, data.MachineIp);
            return sc.Status.ToString();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "CheckServiceStatusError:" + e.Message);
        }

        return "System failed. See logs";
    }
}