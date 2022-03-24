using System.Security.Claims;
using FastpaceProcessor.HelpingClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LogLevel = NLog.LogLevel;

namespace FastpaceProcessor.Controllers;

[ApiController]
[Route("/TransactionsProcessor/")]
[Authorize]
public class TransactionsProcessor : ControllerBase
{
    private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
    private ClaimsPrincipal currentUser;

    bool IsAuthorised()
    {
        currentUser = HttpContext.User;
        if (currentUser.HasClaim(c => c.Type == "Super") || currentUser.HasClaim(c => c.Type == "FineractUser"))
            return true;
        _logger.Log(LogLevel.Error, "Unauthorised Action:Setup request user is:" + currentUser);
        return false;
    }

    [HttpGet("account-balance")]
    public JsonResult GetBalance()
    {
        try
        {
            if (IsAuthorised() && currentUser.HasClaim(c => c.Type == "AccountBalance"))
            {
                currentUser = HttpContext.User;
                //var id = currentUser.FindFirst("uid").Value;
                //return new JsonResult(new {balance = DatabaseEngine.GetAccountBalance(id)});
                return new JsonResult(new {balance = 3000.00});
            }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "Unauthorised Action:GetBalance request user is:" + currentUser);
        }

        HttpContext.Response.StatusCode = 400;
        var errors = new List<string>();
        errors.Add("Transaction Processing Error: Savings account with ID null does not exist");
        return new JsonResult(new {errors});
    }

    [HttpGet("currency-rate")]
    public JsonResult GetExchangeRate(string id)
    {
        try
        {
            //check for header
            if (!HttpContext.Request.Headers.TryGetValue("Payout-Country", out var payoutCountry))
                throw new Exception("payout-country missing");
            if (IsAuthorised() && currentUser.HasClaim(c => c.Type == "ExchangeRate"))
            {
                //return new JsonResult(new {rate = DatabaseEngine.GetCurrencyRate(id)});
                return new JsonResult(new {rate = 7.11});
            }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "Unauthorised Action:GetExchangeRate request user is:" + currentUser);
        }

        HttpContext.Response.StatusCode = 400;
        var errors = new List<string>();
        errors.Add($"Transaction Processing Error: Currency with ID:{id} does not exist");
        return new JsonResult(new {errors});
    }

    [HttpPost("account-enquiry/bank-account")]
    public JsonResult GetBankAccountInfo(AccountInfoClass data)
    {
        try
        {
            //check for header
            if (!HttpContext.Request.Headers.TryGetValue("Payout-Country", out var payoutCountry))
                throw new Exception("payout-country missing");
            var dd = new PaymentInformation();
            dd.paymentInformation = new List<Responseobject>();
            dd.paymentInformation.Add(new Responseobject()
            {
                option = "1001434", value = "1001258258"
            });
            if (IsAuthorised() && currentUser.HasClaim(c => c.Type == "AccountInfo"))
            {
                return new JsonResult(dd);
            }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, $"Unauthorised Action:{e.Message}>>request user is:" + currentUser);
        }

        HttpContext.Response.StatusCode = 400;
        var errors = new List<string>();
        errors.Add($"Transaction Processing Error");
        return new JsonResult(new {errors});
    }

    [HttpPost("account-enquiry/mobile-money")]
    public JsonResult GetWalletAccountInfo(WalletinfoClass data)
    {
        try
        {
            //check for header
            if (!HttpContext.Request.Headers.TryGetValue("Payout-Country", out var payoutCountry))
                throw new Exception("payout-country missing");
            var dd = new PaymentInformation();
            dd.paymentInformation = new List<Responseobject>();
            dd.paymentInformation.Add(new Responseobject()
            {
                option = "1001450", value = "17881258258"
            });
            if (IsAuthorised() && currentUser.HasClaim(c => c.Type == "AccountInfo"))
            {
                return new JsonResult(dd);
            }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, $"Unauthorised Action:{e.Message}>>request user is:" + currentUser);
        }

        HttpContext.Response.StatusCode = 400;
        var errors = new List<string> {$"Transaction Processing Error"};
        return new JsonResult(new {errors});
    }

    [HttpPost("money-transfer/card-account")]
    public JsonResult DoCardTransfer(CardTransferRequestObject data)
    {
        try
        {
            //check for header
            // if (!HttpContext.Request.Headers.TryGetValue("Payout-Country", out var payoutCountry))
            //     throw new Exception("payout-country missing");
            var res = new GenericResponse.MessageResponse()
            {
                message = "Transfer was processed successfully",
                title = "Success"
            };
            var vList = new List<GenericResponse.MessageResponse> {res};
            HttpContext.Response.StatusCode = 200;
            return new JsonResult(new GenericResponse.RootObject()
            {
                messageResponses = vList,
                transactionId = 1221
            });
            // if (IsAuthorised() && currentUser.HasClaim(c => c.Type == "Transfers"))
            // {
            //     return new JsonResult(new GenericResponse.RootObject()
            //     {
            //         messageResponses = vList
            //     });
            // }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, $"Unauthorised Action:{e.Message}>>request user is:" + currentUser);
        }

        HttpContext.Response.StatusCode = 400;
        var errors = new List<string> {$"Transaction Processing Error"};
        return new JsonResult(new {errors});
    }

    [HttpPost("money-transfer/bank-account")]
    public JsonResult DoBankTransfer(BankTransferRequestObject data)
    {
        try
        {
            //check for header
            if (!HttpContext.Request.Headers.TryGetValue("Payout-Country", out var payoutCountry))
                throw new Exception("payout-country missing");
            var res = new GenericResponse.MessageResponse()
            {
                message = "Transfer was processed successfully",
                title = "Success"
            };
            var vList = new List<GenericResponse.MessageResponse> {res};
            HttpContext.Response.StatusCode = 200;
            return new JsonResult(new GenericResponse.RootObject()
            {
                messageResponses = vList,
                transactionId = 1225
            });
            // if (IsAuthorised() && currentUser.HasClaim(c => c.Type == "Transfers"))
            // {
            //     return new JsonResult(new GenericResponse.RootObject()
            //     {
            //         messageResponses = vList
            //     });
            // }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, $"Unauthorised Action:{e.Message}>>request user is:" + currentUser);
        }

        HttpContext.Response.StatusCode = 400;
        var errors = new List<string> {$"Transaction Processing Error"};
        return new JsonResult(new {errors});
    }

    [HttpPost("money-transfer/mobile-money")]
    public JsonResult DoMomoTransfer(MomoTransferRequestObject data)
    {
        try
        {
            //check for header
            if (!HttpContext.Request.Headers.TryGetValue("Payout-Country", out var payoutCountry))
                throw new Exception("payout-country missing");
            var res = new GenericResponse.MessageResponse()
            {
                message = "Transfer was processed successfully",
                title = "Success"
            };
            var vList = new List<GenericResponse.MessageResponse> {res};
            HttpContext.Response.StatusCode = 200;
            return new JsonResult(new GenericResponse.RootObject()
            {
                messageResponses = vList,
                transactionId = 1222
            });
            // if (IsAuthorised() && currentUser.HasClaim(c => c.Type == "Transfers"))
            // {
            //     return new JsonResult(new GenericResponse.RootObject()
            //     {
            //         messageResponses = vList
            //     });
            // }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, $"Unauthorised Action:{e.Message}>>request user is:" + currentUser);
        }

        HttpContext.Response.StatusCode = 400;
        var errors = new List<string> {$"Transaction Processing Error"};
        return new JsonResult(new {errors});
    }

    [HttpPost("money-transfer/otc")]
    public JsonResult sendOTP(OtpRequest data)
    {
        try
        {
            //check for header
            var res = new GenericResponse.MessageResponse()
            {
                message = "Transfer was processed successfully",
                title = "Success"
            };
            HttpContext.Response.StatusCode = 200;
            return new JsonResult("");
            // if (IsAuthorised() && currentUser.HasClaim(c => c.Type == "OTP"))
            // {
            //     return new JsonResult(new GenericResponse.RootObject()
            //     {
            //         messageResponses = vList
            //     });
            // }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, $"Unauthorised Action:{e.Message}>>request user is:" + currentUser);
        }

        HttpContext.Response.StatusCode = 400;
        var errors = new List<string> {$"Transaction Processing Error"};
        return new JsonResult(new {errors});
    }

    // [HttpPut("money-transfer/otc")]
    // public JsonResult sendOtp(OtcRequestObject data)
    // {
    //     try
    //     {
    //         //check for header
    //         var res = new GenericResponse.MessageResponse()
    //         {
    //             message = "Transfer was processed successfully",
    //             title = "Success"
    //         };
    //         HttpContext.Response.StatusCode = 200;
    //         return null;
    //         // if (IsAuthorised() && currentUser.HasClaim(c => c.Type == "Transfers"))
    //         // {
    //         //     return new JsonResult(new GenericResponse.RootObject()
    //         //     {
    //         //         messageResponses = vList
    //         //     });
    //         // }
    //     }
    //     catch (Exception e)
    //     {
    //         _logger.Log(LogLevel.Error, $"Unauthorised Action:{e.Message}>>request user is:" + currentUser);
    //     }
    //
    //     HttpContext.Response.StatusCode = 400;
    //     var errors = new List<string> {$"Transaction Processing Error"};
    //     return new JsonResult(new {errors});
    // }
}