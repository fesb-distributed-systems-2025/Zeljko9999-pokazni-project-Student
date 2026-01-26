using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmailService(IEmailRepository emailRepository, IStudentRepository studentRepository, IUnitOfWork unitOfWork) 
        {
            _emailRepository = emailRepository;
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Email?>>> GetAllEmails()
        {
            var emails = await _emailRepository.GetEmails();
            return Result<IEnumerable<Email?>>.Success(emails);
        }

        public async Task<Result<Email?>> GetEmailById(int id)
        {
            var email = await _emailRepository.GetEmailById(id);
            return Result<Email?>.Success(email);
        }

        public async Task<Result<object>> AddEmail(PostEmailDTO email)
        {
            var emailEntity = email.ToModel();

            var validationResult = await CreateOrUpdateValidation(emailEntity);

            if (!validationResult.IsSuccess)
                return Result<object>.Failure(validationResult.ValidationItems);

            _emailRepository.CreateEmail(emailEntity);
            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        public async Task<Result<object>> UpdateEmail(PutEmailDTO email)
        {
            var emailEntity = email.ToModel();

            var validationResult = await CreateOrUpdateValidation(emailEntity);

            if (!validationResult.IsSuccess)
                return Result<object>.Failure(validationResult.ValidationItems);

            await _emailRepository.UpdateEmail(emailEntity);
            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        public async Task<Result<object>> DeleteEmail(int id)
        {
            await _emailRepository.DeleteEmail(id);
            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        private async Task<ValidationResult> CreateOrUpdateValidation(Email email)
        {
            var result = new ValidationResult();

            var sender = await _studentRepository.GetStudentById(email.SenderId);
            if (sender is null)
                result.ValidationItems.Add("Sender is not found.");

            var receiver = await _studentRepository.GetStudentById(email.ReceiverId);
            if (receiver is null)
                result.ValidationItems.Add("Receiver is not found.");

            if (string.IsNullOrWhiteSpace(email.Subject))
                result.ValidationItems.Add("Subject is required.");
            else if (email.Subject.Length > Email.SubjectMaxLength)
                result.ValidationItems.Add($"Subject cant have more than {Email.SubjectMaxLength} characters.");
            else if (email.Subject.Length < Email.SubjectMinLength)
                result.ValidationItems.Add($"Subject must have more than {Email.SubjectMinLength} characters.");

            if (!string.IsNullOrWhiteSpace(email.Message) &&
                email.Message.Length > Email.MessageMaxLength)
                result.ValidationItems.Add($"Message cant have more than {Email.MessageMaxLength} characters.");

            return result;
        }

    }
}