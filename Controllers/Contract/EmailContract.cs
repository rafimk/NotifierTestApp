namespace NotifierTestApp.Controllers.Contract
{
    public class EmailContract
    {
        public string To {get; set;}
        public string Subject { get; set;}
        public string Html { get; set;}
    }
}