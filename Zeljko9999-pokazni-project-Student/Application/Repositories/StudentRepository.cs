using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Models;

namespace Application.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public StudentRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);

            //if (student == null)
            //    throw new KeyNotFoundException();

            return student;
        }
    }
}
