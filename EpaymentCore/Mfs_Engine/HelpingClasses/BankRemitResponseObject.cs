using System.Xml.Serialization;

namespace Mfs_Engine.HelpingClasses;

public class BankRemitResponseObject
{
	[XmlRoot(ElementName="receive_amount", Namespace="http://ws.mfsafrica.com")]
	public class Receive_amount {
		[XmlElement(ElementName="amount", Namespace="http://ws.mfsafrica.com")]
		public string Amount { get; set; }
		[XmlElement(ElementName="currency_code", Namespace="http://ws.mfsafrica.com")]
		public string Currency_code { get; set; }
	}

	[XmlRoot(ElementName="send_amount", Namespace="http://ws.mfsafrica.com")]
	public class Send_amount {
		[XmlElement(ElementName="amount", Namespace="http://ws.mfsafrica.com")]
		public string Amount { get; set; }
		[XmlElement(ElementName="currency_code", Namespace="http://ws.mfsafrica.com")]
		public string Currency_code { get; set; }
	}

	[XmlRoot(ElementName="code", Namespace="http://ws.mfsafrica.com")]
	public class Code {
		[XmlElement(ElementName="status_code", Namespace="http://ws.mfsafrica.com")]
		public string Status_code { get; set; }
	}

	[XmlRoot(ElementName="status", Namespace="http://ws.mfsafrica.com")]
	public class Status {
		[XmlElement(ElementName="code", Namespace="http://ws.mfsafrica.com")]
		public Code Code { get; set; }
		[XmlElement(ElementName="message", Namespace="http://ws.mfsafrica.com")]
		public string Message { get; set; }
	}

	[XmlRoot(ElementName="return", Namespace="http://ws.mfsafrica.com")]
	public class Return {
		[XmlElement(ElementName="fx_rate", Namespace="http://ws.mfsafrica.com")]
		public string Fx_rate { get; set; }
		[XmlElement(ElementName="mfs_trans_id", Namespace="http://ws.mfsafrica.com")]
		public string Mfs_trans_id { get; set; }
		[XmlElement(ElementName="receive_amount", Namespace="http://ws.mfsafrica.com")]
		public Receive_amount Receive_amount { get; set; }
		[XmlElement(ElementName="send_amount", Namespace="http://ws.mfsafrica.com")]
		public Send_amount Send_amount { get; set; }
		[XmlElement(ElementName="status", Namespace="http://ws.mfsafrica.com")]
		public Status Status { get; set; }
		[XmlElement(ElementName="third_party_trans_id", Namespace="http://ws.mfsafrica.com")]
		public string Third_party_trans_id { get; set; }
	}

	[XmlRoot(ElementName="bank_remit_logResponse", Namespace="http://ws.mfsafrica.com")]
	public class Bank_remit_logResponse {
		[XmlElement(ElementName="return", Namespace="http://ws.mfsafrica.com")]
		public Return Return { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
	}

	[XmlRoot(ElementName="Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
	public class Body {
		[XmlElement(ElementName="bank_remit_logResponse", Namespace="http://ws.mfsafrica.com")]
		public Bank_remit_logResponse Bank_remit_logResponse { get; set; }
	}

	[XmlRoot(ElementName="Envelope", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
	public class Envelope {
		[XmlElement(ElementName="Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
		public Body Body { get; set; }
		[XmlAttribute(AttributeName="soap", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Soap { get; set; }
	}

}

