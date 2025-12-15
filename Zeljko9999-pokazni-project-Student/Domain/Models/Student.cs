namespace Domain.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }
        public string EmailAddress { get; set; }
        public int? ProgramTypeId { get; set; }

        #region Navigation Properties
        public ProgramType? ProgramType { get; set; }
        #endregion

        #region Reverse Navigation Properties
        public ICollection<Email> SentEmails { get; set; }
        public ICollection<Email> ReceivedEmails { get; set; }
        #endregion
    }
}
