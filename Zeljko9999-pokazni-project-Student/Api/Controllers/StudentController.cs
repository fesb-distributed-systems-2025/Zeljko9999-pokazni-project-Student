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
        public void GetAllStudents()
        {
            //return _emailRespository.Emails;
        }

        [HttpGet("students/{id}")]
        public void GetStudentById()
        {
            //return _emailRespository.Emails;
        }

        [HttpPost("new")]
        public void AddStudent([FromBody] PostStudentDTO student)
        {
            //_emailRespository.Emails.Add(email);
            //return _emailRespository.Emails;
        }

        [HttpPut("edit")]
        public void EditStudent([FromBody] Student newStudent)
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
        }

        [HttpDelete("delete/{id}")]
        public void DeleteEmail([FromRoute] int id)
        {
            //_emailRespository.Emails = _emailRespository.Emails.Where(x => x.Id != id).ToList();
            //return _emailRespository.Emails;
        }
    }
}
