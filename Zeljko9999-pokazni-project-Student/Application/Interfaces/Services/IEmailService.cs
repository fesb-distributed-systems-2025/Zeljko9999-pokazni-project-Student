using Application.Common;
using Application.DTOs;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task<Result<IEnumerable<Email?>>> GetAllEmails();
        Task<Result<Email?>> GetEmailById(int id);
        Task<Result<object>> AddEmail(PostEmailDTO email);
        Task<Result<object>> UpdateEmail(PutEmailDTO email);
        Task<Result<object>> DeleteEmail(int id);
    }
}
