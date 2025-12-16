namespace Domain.Models
{
    public class Email
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Subject { get; set; }
        public string? Message { get; set; }

        #region Navigation Properties
        public Student Sender { get; set; }
        public Student Receiver { get; set; }
        #endregion
    }
}
