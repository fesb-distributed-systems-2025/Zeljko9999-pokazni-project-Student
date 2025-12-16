using Application.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //private EmailRespository _emailRespository;
        public StudentController(StudentController emailRespository)
        {
            //_emailRespository = emailRespository;
        }

        [HttpGet("students")]
        public IEnumerable<Student> GetAllStudents()
        {
            //return _emailRespository.Emails;

            return Enumerable.Empty<Student>();
        }

        [HttpGet("students/{id}")]
        public Student GetStudentById()
        {
            //return _emailRespository.Emails;

            return new Student();
        }

        [HttpPost("new")]
        public int AddStudent([FromBody] PostStudentDTO newStudent)
        {
            //_emailRespository.Emails.Add(email);
            //return _emailRespository.Emails;

            return 0;
        }

        [HttpPut("edit")]
        public int EditStudent([FromBody] Student student)
        {
            //var oldEmail = _emailRespository.Emails.FirstOrDefault(x => x.Id == id);

            //if (oldEmail == null)
            //{
            //    return _emailRespository.Emails;
            //}

            //oldEmail.Sender = newEmail.Sender;
            //oldEmail.Recepient = newEmail.Recepient;
            //oldEmail.Subject = newEmail.Subject;
            //oldEmail.Message = newEmail.Message;

            //return _emailRespository.Emails;

            return 0;
        }

        [HttpDelete("delete/{id}")]
        public int DeleteEmail([FromRoute] int id)
        {
            //_emailRespository.Emails = _emailRespository.Emails.Where(x => x.Id != id).ToList();
            //return _emailRespository.Emails;

            return 0;
        }
    }
}
