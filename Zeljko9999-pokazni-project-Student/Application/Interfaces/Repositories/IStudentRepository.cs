using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentById(int id);
    }
}
