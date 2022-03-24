namespace FastpaceProcessor.HelpingClasses;

public class GenericResponse
{
    public class MessageResponse
    {
        public string title { get; set; }
        public string message { get; set; }
    }

    public class RootObject
    {
        public List<MessageResponse> messageResponses { get; set; }
        public int transactionId { get; set; }
    }
}