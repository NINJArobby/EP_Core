using System.Xml;
using System.Xml.Serialization;
using Mfs_Engine.HelpingClasses;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Mfs_Engine;

using Microsoft.Extensions.Configuration;

public static class Agent
{
    private static string companyCode;
    private static string companyPassword;
    private static string endpoint;
    private static string x_api_key;

    public static void initAgent(IConfiguration configuration)
    {
        companyCode = "FASTPACE";
        companyPassword = "FReQ?2cWF>4crDfWcoK]";
        endpoint = "https://mfsafricatest.com/mttest/services/XPService.XPServiceHttpSoap11Endpoint/";
        x_api_key = "OHFRlPB6k61lHOFDzdmJM4HvFT1U7cHA5raj1A6l";
    }

    public static accountRequestResponse AccountRequest(string destCountry, string msisdn)
    {
        var res = new accountRequestResponse();
        try
        {
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml; charset=utf-8");
            request.AddHeader("SOAPAction", "urn:account_request");
            request.AddHeader("x-api-key", x_api_key);
            var body = @"<?xml version=""1.0"" encoding=""utf-8""?>" + "\n" +
                       @"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" + "\n" +
                       @"  <soap:Body>" + "\n" +
                       @"    <account_request xmlns=""http://ws.mfsafrica.com"">" + "\n" +
                       @"      <login>" + "\n" +
                       @"        <corporate_code>" + companyCode + "</corporate_code>" + "\n" +
                       @"        <password>" + companyPassword + "</password>" + "\n" +
                       @"      </login>" + "\n" +
                       @"      <to_country>" + destCountry + "</to_country>" + "\n" +
                       @"      <msisdn>" + msisdn + "</msisdn>" + "\n" +
                       @"    </account_request>" + "\n" +
                       @"  </soap:Body>" + "\n" +
                       @"</soap:Envelope>" + "\n" +
                       @"";
            request.AddParameter("text/xml; charset=utf-8", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            //var vstring = response.Content.Replace("", string.Empty);
            var doc = new XmlDocument();
            doc.LoadXml(response.Content);
            var root = doc.DocumentElement;
            var childNodes = root?.ChildNodes;
            var dp = childNodes[0].FirstChild.FirstChild.ChildNodes;
            res.Msisdn = dp.Item(0).FirstChild.Value;
            res.PartnerCode = dp.Item(1).FirstChild.Value;
            res.Status = dp.Item(2).FirstChild.FirstChild.Value;
        }
        catch (Exception e)
        {
            res.ErrorMessage = e.InnerException;
        }

        return res;
    }

    public static transactionStatusResponse GetTransactionStatus(string transactionId)
    {
        var res = new transactionStatusResponse();
        try
        {
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml; charset=utf-8");
            request.AddHeader("x-api-key", x_api_key);
            request.AddHeader("SOAPAction", "urn:get_trans_status");
            var body = @"<?xml version=""1.0"" encoding=""utf-8""?>" + "\n" +
                       @"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" + "\n" +
                       @"  <soap:Body>" + "\n" +
                       @"    <account_request xmlns=""http://ws.mfsafrica.com"">" + "\n" +
                       @"      <login>" + "\n" +
                       @"        <corporate_code>" + companyCode + "</corporate_code>" + "\n" +
                       @"        <password>" + companyPassword + "</password>" + "\n" +
                       @"      </login>" + "\n" +
                       @"      <trans_id>" + transactionId + "</trans_id>" + "\n" +
                       @"    </get_trans_status>" + "\n" +
                       @"  </soap:Body>" + "\n" +
                       @"</soap:Envelope>" + "\n" +
                       @"";
            request.AddParameter("text/xml; charset=utf-8", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            //var vstring = response.Content.Replace("", string.Empty);
            var doc = new XmlDocument();
            doc.LoadXml(response.Content);
            var root = doc.DocumentElement;
            var childNodes = root?.ChildNodes;
            var dp = childNodes[0].FirstChild.FirstChild.ChildNodes;
            res.code = dp.Item(0).FirstChild.FirstChild.Value;
            res.message = dp.Item(2).FirstChild.Value;
            res.e_trans_id = dp.Item(1).FirstChild.Value;
            res.mfs_trans_id = dp.Item(3).FirstChild.Value;
            res.third_party_trans_id = dp.Item(4).FirstChild.FirstChild.Value;
        }
        catch (Exception e)
        {
            res.ErrorMessage = e.InnerException;
        }

        return res;
    }
}