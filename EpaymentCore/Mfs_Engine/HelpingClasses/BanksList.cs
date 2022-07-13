using System.Xml.Serialization;

namespace Mfs_Engine.HelpingClasses;

public class BanksList
{
    [XmlRoot(ElementName="bank_limit", Namespace="http://mfs/xsd")]
	public class Bank_limit {
		[XmlElement(ElementName="max_daily_value", Namespace="http://mfs/xsd")]
		public string Max_daily_value { get; set; }
		[XmlElement(ElementName="max_monthly_value", Namespace="http://mfs/xsd")]
		public string Max_monthly_value { get; set; }
		[XmlElement(ElementName="max_per_tx_limit", Namespace="http://mfs/xsd")]
		public string Max_per_tx_limit { get; set; }
		[XmlElement(ElementName="max_weekly_value", Namespace="http://mfs/xsd")]
		public string Max_weekly_value { get; set; }
		[XmlElement(ElementName="min_per_tx_limit", Namespace="http://mfs/xsd")]
		public string Min_per_tx_limit { get; set; }
		[XmlAttribute(AttributeName="type", Namespace="http://www.w3.org/2001/XMLSchema-instance")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName="return", Namespace="http://ws.mfsafrica.com")]
	public class Return {
		[XmlElement(ElementName="bank_limit", Namespace="http://mfs/xsd")]
		public Bank_limit Bank_limit { get; set; }
		[XmlElement(ElementName="bank_name", Namespace="http://mfs/xsd")]
		public string Bank_name { get; set; }
		[XmlElement(ElementName="bic", Namespace="http://mfs/xsd")]
		public string Bic { get; set; }
		[XmlElement(ElementName="country_code", Namespace="http://mfs/xsd")]
		public string Country_code { get; set; }
		[XmlElement(ElementName="currency_code", Namespace="http://mfs/xsd")]
		public string Currency_code { get; set; }
		[XmlElement(ElementName="dom_bank_code", Namespace="http://mfs/xsd")]
		public string Dom_bank_code { get; set; }
		[XmlElement(ElementName="iban", Namespace="http://mfs/xsd")]
		public string Iban { get; set; }
		[XmlElement(ElementName="mfs_bank_code", Namespace="http://mfs/xsd")]
		public string Mfs_bank_code { get; set; }
		[XmlAttribute(AttributeName="xsi", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
		[XmlAttribute(AttributeName="type", Namespace="http://www.w3.org/2001/XMLSchema-instance")]
		public string Type { get; set; }
	}
	

	public Exception ErrorMessage { get; set; }
}