using System.Data.SqlClient;
using MobileInsureApi.HelpingClasses;
using SqlKata.Compilers;
using SqlKata.Execution;
using LogLevel = NLog.LogLevel;

namespace MobileInsureApi;

public static class DatabaseEngine
{
    private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    public static Customer CreateCustomer(Customer customer, string connection)
    {
        using (var conn = new SqlConnection(connection))
        {
            try
            {
                var db = new QueryFactory(conn, new SqlServerCompiler());
                db.Query("Customer").InsertGetId<int>(customer);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "ErrorCreateCustomer>>>" + e.Message);
            }
        }

        return null;
    }

    public static bool ModifyCustomer(Customer customer, string connection)
    {
        using (var conn = new SqlConnection(connection))
        {
            try
            {
                var db = new QueryFactory(conn, new SqlServerCompiler());
                if (!string.IsNullOrEmpty(customer.Email))
                {
                    db.Query("Customer").Where("CustomerId", customer.Id).Update(new
                    {
                        Email = customer.Email
                    });
                }

                if (!string.IsNullOrEmpty(customer.Password))
                {
                    db.Query("Customer").Where("CustomerId", customer.Id).Update(new
                    {
                        Password = customer.Password
                    });
                }

                db.Query("Customer").Where("CustomerId", customer.Id).Update(new
                {
                    Level = customer.Level
                });
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "ErrorModifyCustomer>>>" + e.Message);
            }
        }

        return false;
    }

    public static bool AddDevice(Device device, string connection)
    {
        using (var conn = new SqlConnection(connection))
        {
            try
            {
                var db = new QueryFactory(conn, new SqlServerCompiler());
                db.Query("Devices").InsertGetId<int>(new
                {
                    device.Serial,
                    device.CustomerId,
                    device.BackImage,
                    device.FrontImage,
                    device.ManufacturerId,
                    device.DeviceName,
                    device.Status
                });
                return true;
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "ErrorddDevice>>>" + e.Message);
            }
        }

        return false;
    }

    public static string CreateClaimRequest(ClaimsRequest request, string connection)
    {
        using (var conn = new SqlConnection(connection))
        {
            try
            {
                var db = new QueryFactory(conn, new SqlServerCompiler());
                var id = db.Query("ClaimsRequest").InsertGetId<int>(new
                {
                    request.ClaimType,
                    request.DeviceId,
                    request.Status,
                });
                var clId = db.Query("ClaimsRequest").Where("Id", id).Get<string>().FirstOrDefault();
                db.Query("ClaimsReviews").InsertGetId<int>(new
                {
                    ClaimRequestId = clId,
                    AssignedTo = GetRandomUser(connection),
                    ReviewComments = string.Empty,
                    Status = ClaimStatus.Submitted
                });
                return clId;
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "ErrorCreateClaimRequest>>>" + e.Message);
            }
        }

        return string.Empty;
    }
    private static int GetRandomUser(string connection)
    {
        using (var conn = new SqlConnection(connection))
        {
            try
            {
                var db = new QueryFactory(conn, new SqlServerCompiler());
                var users = db.Query("Users").Get<Users>().ToList();
                var user = users[new Random().Next(0, users.Count - 1)];
                return user.Uid;
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "ErrorGetRandomUser>>>" + e.Message);
            }
        }

        return 0;
    }

    public static bool InsureDevice(DeviceInsure data, string connection)
    {
        using (var conn = new SqlConnection(connection))
        {
            try
            {
                var db = new QueryFactory(conn, new SqlServerCompiler());
                db.Query("DeviceInsureTable").InsertGetId<int>(new
                {
                    data.DeviceId,
                    data.InsuranceAmount,
                    data.InsuranceType,
                    data.InsuranceStartDate,
                    data.InsuranceEndDate,
                    data.InsuranceComments,
                    data.InsuranceImageFront,
                    data.InsuranceImageBack
                });
                return true;
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "ErrorInsureDevice>>>" + e.Message);
            }
        }
        return false;
    }
    
    //todo Work on user methods eg, adduser, modifyUser etc
}