using System.Xml;
using System.Xml.Serialization;
using Mfs_Engine.HelpingClasses;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
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

    public static string AccountRequest(string destCountry, string msisdn)
    {
        //var res = new accountRequestResponse();
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
            return JsonConvert.SerializeXmlNode(doc);
            // var root = doc.DocumentElement;
            // var childNodes = root?.ChildNodes;
            // var dp = childNodes[0].FirstChild.FirstChild.ChildNodes;
            // res.Msisdn = dp.Item(0).FirstChild.Value;
            // res.PartnerCode = dp.Item(1).FirstChild.Value;
            // res.Status = dp.Item(2).FirstChild.FirstChild.Value;
        }
        catch (Exception e)
        {
            //res.ErrorMessage = e.InnerException;
        }

        return String.Empty;
    }

    public static string GetTransactionStatus(string transactionId)
    {
        //var res = new transactionStatusResponse();
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
            return JsonConvert.SerializeXmlNode(doc);
            // var root = doc.DocumentElement;
            // var childNodes = root?.ChildNodes;
            // var dp = childNodes[0].FirstChild.FirstChild.ChildNodes;
            // res.code = dp.Item(0).FirstChild.FirstChild.Value;
            // res.message = dp.Item(2).FirstChild.Value;
            // res.e_trans_id = dp.Item(1).FirstChild.Value;
            // res.mfs_trans_id = dp.Item(3).FirstChild.Value;
            // res.third_party_trans_id = dp.Item(4).FirstChild.FirstChild.Value;
        }
        catch (Exception e)
        {
            //res.ErrorMessage = e.InnerException;
        }

        return String.Empty;
    }

    public static string CancelTransaction(string transactionId)
    {
        //var res = new transactionStatusResponse();
        try
        {
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml; charset=utf-8");
            request.AddHeader("x-api-key", x_api_key);
            request.AddHeader("SOAPAction", "urn:cancel_trans");
            var body = @"<?xml version=""1.0"" encoding=""utf-8""?>" + "\n" +
                       @"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" + "\n" +
                       @"  <soap:Body>" + "\n" +
                       @"    <cancel_trans xmlns=""http://ws.mfsafrica.com"">" + "\n" +
                       @"      <login>" + "\n" +
                       @"        <corporate_code>" + companyCode + "</corporate_code>" + "\n" +
                       @"        <password>" + companyPassword + "</password>" + "\n" +
                       @"      </login>" + "\n" +
                       @"      <trans_id>" + transactionId + "</trans_id>" + "\n" +
                       @"    </cancel_trans>" + "\n" +
                       @"  </soap:Body>" + "\n" +
                       @"</soap:Envelope>" + "\n" +
                       @"";
            request.AddParameter("text/xml; charset=utf-8", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            //var vstring = response.Content.Replace("", string.Empty);
            var doc = new XmlDocument();
            doc.LoadXml(response.Content);
            return JsonConvert.SerializeXmlNode(doc);
            // var root = doc.DocumentElement;
            // var childNodes = root?.ChildNodes;
            // var dp = childNodes[0].FirstChild.FirstChild.ChildNodes;
            // res.code = dp.Item(0).FirstChild.FirstChild.Value;
            // res.message = dp.Item(2).FirstChild.Value;
            // res.e_trans_id = dp.Item(1).FirstChild.Value;
            // res.mfs_trans_id = dp.Item(3).FirstChild.Value;
            // res.third_party_trans_id = dp.Item(4).FirstChild.FirstChild.Value;
        }
        catch (Exception e)
        {
            //res.ErrorMessage = e.InnerException;
        }

        return string.Empty;
    }

    public static string GetRates(string destCountry, string from_currency, string to_currency)
    {
        //var res = new GetRatesObject();
        try
        {
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml; charset=utf-8");
            request.AddHeader("x-api-key", x_api_key);
            request.AddHeader("SOAPAction", "urn:get_rate");
            var body = @"<?xml version=""1.0"" encoding=""utf-8""?>" + "\n" +
                       @"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" + "\n" +
                       @"  <soap:Body>" + "\n" +
                       @"    <get_rate xmlns=""http://ws.mfsafrica.com"">" + "\n" +
                       @"      <login>" + "\n" +
                       @"        <corporate_code>" + companyCode + "</corporate_code>" + "\n" +
                       @"        <password>" + companyPassword + "</password>" + "\n" +
                       @"      </login>" + "\n" +
                       @"      <to_country>" + destCountry + "</to_country>" + "\n" +
                       @"      <from_currency>" + from_currency + "</from_currency>" + "\n" +
                       @"      <to_currency>" + to_currency + "</to_currency>" + "\n" +
                       @"    </get_rate>" + "\n" +
                       @"  </soap:Body>" + "\n" +
                       @"</soap:Envelope>" + "\n" +
                       @"";
            request.AddParameter("text/xml; charset=utf-8", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            var doc = new XmlDocument();
            doc.LoadXml(response.Content);
            return JsonConvert.SerializeXmlNode(doc);
            // var root = doc.DocumentElement;
            // var childNodes = root?.ChildNodes;
            // var dp = childNodes[0].FirstChild.FirstChild.ChildNodes;
            // res.from_currency = dp.Item(0).FirstChild.Value;
            // res.fx_rate = dp.Item(2).FirstChild.Value;
            // res.partner_code = dp.Item(1).FirstChild.Value;
            // res.time_stamp = dp.Item(3).FirstChild.Value;
            // res.to_currency = dp.Item(4).FirstChild.Value;
        }
        catch (Exception e)
        {
            //res.ErrorMessage = e.InnerException;
        }

        return string.Empty;
    }

    public static string GetBanks(string destCountry)
    {
        try
        {
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml; charset=utf-8");
            request.AddHeader("x-api-key", x_api_key);
            request.AddHeader("SOAPAction", "urn:get_banks");
            var body = @"<?xml version=""1.0"" encoding=""utf-8""?>" + "\n" +
                       @"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" + "\n" +
                       @"  <soap:Body>" + "\n" +
                       @"    <get_banks xmlns=""http://ws.mfsafrica.com"">" + "\n" +
                       @"      <login>" + "\n" +
                       @"        <corporate_code>" + companyCode + "</corporate_code>" + "\n" +
                       @"        <password>" + companyPassword + "</password>" + "\n" +
                       @"      </login>" + "\n" +
                       @"      <to_country>" + destCountry + "</to_country>" + "\n" +
                       @"    </get_banks>" + "\n" +
                       @"  </soap:Body>" + "\n" +
                       @"</soap:Envelope>" + "\n" +
                       @"";
            request.AddParameter("text/xml; charset=utf-8", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            //var dd = response.Content;
            var doc = new XmlDocument();
            doc.LoadXml(response.Content);
            // var xnList = doc.ChildNodes.Item(1).ChildNodes.Item(0).ChildNodes.Item(0);
            return JsonConvert.SerializeXmlNode(doc);
        }
        catch (Exception e)
        {
            //res.ErrorMessage = e.InnerException;
        }

        return String.Empty;
    }

    public static string BankTransLog(BankRemitRequestObject data)
    {
        try
        {
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml; charset=utf-8");
            request.AddHeader("x-api-key", x_api_key);
            request.AddHeader("SOAPAction", "urn:bank_trans_log");
            var body = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                              <soap:Body>
                                <bank_trans_log xmlns=""http://ws.mfsafrica.com"">
                                  <login>
                                    <corporate_code>{companyCode}</corporate_code>
                                    <password>{companyPassword}</password>
                                  </login>
                                  <send_amount>
                                    <amount>{data.send_amount}</amount>
                                    <currency_code>{data.send_amount_currency_code}</currency_code>
                                  </send_amount>
                                  <fee>
                                    <amount>{data.fee}</amount>
                                    <currency_code>{data.fee_currency_code}</currency_code>
                                  </fee>
                                  <sender>
                                    <email>{data.sender_email}</email>
                                    <from_country>{data.sender_country}</from_country>
                                    <msisdn>{data.sender_msisdn}</msisdn>
                                    <name>{data.sender_fname}</name>
                                    <surname>{data.sender_surname}</surname>
                                  </sender>
                                  <recipient>
                                    <email>{data.recipient_email}</email>
                                    <msisdn>{data.recipient_msisdn}</msisdn>
                                    <name>{data.recipient_fname}</name>
                                    <status>
                                      <status_code></status_code>
                                    </status>
                                    <surname>{data.recipient_surname}</surname>
                                    <to_country>{data.recipient_country}</to_country>
                                  </recipient>
                                  <account>
                                    <account_number>{data.recipient_account_number}</account_number>
                                    <mfs_bank_code>{data.recipient_mfs_bank_code}</mfs_bank_code>
                                  </account>
                                  <third_party_trans_id>{data.third_party_trans_id}</third_party_trans_id>
                                  <reference>{data.recipient_reference}</reference>
                                </bank_trans_log>
                              </soap:Body>
                            </soap:Envelope>
                            ";
            request.AddParameter("text/xml; charset=utf-8", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            //var dd = response.Content;
            var doc = new XmlDocument();
            doc.LoadXml(response.Content);
            // var xnList = doc.ChildNodes.Item(1).ChildNodes.Item(0).ChildNodes.Item(0);
            return JsonConvert.SerializeXmlNode(doc);
        }
        catch (Exception e)
        {
            //res.ErrorMessage = e.InnerException;
        }

        return String.Empty;
    }
    
    public static string TransCom(string trans_id)
    {
        try
        {
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml; charset=utf-8");
            request.AddHeader("x-api-key", x_api_key);
            request.AddHeader("SOAPAction", "urn:trans_com");
            var body = $@"<?xml version=""1.0"" encoding=""utf-8""?>" + "\n" +
                       @"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" + "\n" +
                       @"  <soap:Body>" + "\n" +
                       @"    <trans_com xmlns=""http://ws.mfsafrica.com"">" + "\n" +
                       @"      <login>" + "\n" +
                       @"        <corporate_code>" + companyCode + "</corporate_code>" + "\n" +
                       @"        <password>" + companyPassword + "</password>" + "\n" +
                       @"      </login>" + "\n" +
                       @"      <trans_id>"+trans_id+"</trans_id>" + "\n" +
                       @"    </trans_com>" + "\n" +
                       @"  </soap:Body>" + "\n" +
                       @"</soap:Envelope>" + "\n" +
                       @"";
            request.AddParameter("text/xml; charset=utf-8", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            //var dd = response.Content;
            var doc = new XmlDocument();
            doc.LoadXml(response.Content);
            // var xnList = doc.ChildNodes.Item(1).ChildNodes.Item(0).ChildNodes.Item(0);
            return JsonConvert.SerializeXmlNode(doc);
        }
        catch (Exception e)
        {
            //res.ErrorMessage = e.InnerException;
        }

        return String.Empty;
    }
    
    public static string BankRemitLog(BankRemitRequestObject data)
    {
        try
        {
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml; charset=utf-8");
            request.AddHeader("x-api-key", x_api_key);
            request.AddHeader("SOAPAction", "urn:bank_remit_log");
            var body = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                              <soap:Body>
                                <bank_remit_log xmlns=""http://ws.mfsafrica.com"">
                                  <login>
                                    <corporate_code>{companyCode}</corporate_code>
                                    <password>{companyPassword}</password>
                                  </login>
                                  <send_amount>
                                    <amount>{data.send_amount}</amount>
                                    <currency_code>{data.send_amount_currency_code}</currency_code>
                                  </send_amount>
                                  <fee>
                                    <amount>{data.fee}</amount>
                                    <currency_code>{data.fee_currency_code}</currency_code>
                                  </fee>
                                  <sender>
                                    <email>{data.sender_email}</email>
                                    <from_country>{data.sender_country}</from_country>
                                    <msisdn>{data.sender_msisdn}</msisdn>
                                    <name>{data.sender_fname}</name>
                                    <surname>{data.sender_surname}</surname>
                                  </sender>
                                  <recipient>
                                    <email>{data.recipient_email}</email>
                                    <msisdn>{data.recipient_msisdn}</msisdn>
                                    <name>{data.recipient_fname}</name>
                                    <status>
                                      <status_code></status_code>
                                    </status>
                                    <surname>{data.recipient_surname}</surname>
                                    <to_country>{data.recipient_country}</to_country>
                                  </recipient>
                                  <account>
                                    <account_number>{data.recipient_account_number}</account_number>
                                    <mfs_bank_code>{data.recipient_mfs_bank_code}</mfs_bank_code>
                                  </account>
                                  <third_party_trans_id>{data.third_party_trans_id}</third_party_trans_id>
                                  <reference>{data.recipient_reference}</reference>
                                </bank_remit_log>
                              </soap:Body>
                            </soap:Envelope>
                            ";
            request.AddParameter("text/xml; charset=utf-8", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            //var dd = response.Content;
            var doc = new XmlDocument();
            doc.LoadXml(response.Content);
            // var xnList = doc.ChildNodes.Item(1).ChildNodes.Item(0).ChildNodes.Item(0);
            return JsonConvert.SerializeXmlNode(doc);
        }
        catch (Exception e)
        {
            //res.ErrorMessage = e.InnerException;
        }

        return String.Empty;
    }
    
    public static string ValidateBankAccount(ValidateAccountRequest data)
    {
        try
        {
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/xml; charset=utf-8");
            request.AddHeader("SOAPAction", "urn:validate_bank_account");
            var body = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                            <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                              <soap:Body>
                                <validate_bank_account xmlns=""http://ws.mfsafrica.com"">
                                  <login>
                                    <corporate_code>{companyCode}</corporate_code>
                                    <password>{companyPassword}</password>
                                  </login>
                                  <payee>
                                    <msisdn>{data.payee_msisdn}</msisdn>
                                    <name>{data.payee_fname}</name>
                                  </payee>
                                  <account>
                                    <account_number>{data.account_number}</account_number>
                                    <mfs_bank_code>{data.mfs_bank_code}</mfs_bank_code>
                                  </account>
                                  <to_country>{data.to_country}</to_country>
                                </validate_bank_account>
                              </soap:Body>
                            </soap:Envelope>
                            ";
            request.AddParameter("text/xml; charset=utf-8", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            var doc = new XmlDocument();
            doc.LoadXml(response.Content);
            return JsonConvert.SerializeXmlNode(doc);

        }
        catch (Exception e)
        {
            //res.ErrorMessage = e.InnerException;
        }

        return String.Empty;
    }
}