namespace Domain.Models
{
    public class Email
    {
        public int Id { get; set; }

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
