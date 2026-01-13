using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<EmailRepository> _logger;

        public EmailRepository(IApplicationDbContext dbContext, ILogger<EmailRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        private List<Email> Emails { get; set; }

        public async Task<IEnumerable<Email>> GetEmails()
        {
            var email = await _dbContext.Emails.AsNoTracking().ToListAsync();

            return email;
        }

        public async Task<Email> GetEmailById(int id)
        {
            var email = await _dbContext.Emails.FindAsync(id);

            if (email == null)
            {
                throw new KeyNotFoundException($"Cannot find email with Id: {id}");
            }

            return email;
        }

        public void CreateEmail(Email email)
        {
            _dbContext.Emails.Add(email);
        }

        public async Task UpdateEmail(Email email)
        {
            var oldEmail = await _dbContext.Emails.FindAsync(email.Id)
                    ?? throw new KeyNotFoundException($"Email {email.Id} not found.");

            oldEmail.SenderId = email.SenderId;
            oldEmail.ReceiverId = email.ReceiverId;
            oldEmail.Subject = email.Subject;
            oldEmail.Message = email.Message;
        }

        public async Task DeleteEmail(int id)
        {
            var email = await _dbContext.Emails.FindAsync(id);

            if (email == null)         
                throw new KeyNotFoundException();

            _dbContext.Emails.Remove(email);
        }
    }
}
