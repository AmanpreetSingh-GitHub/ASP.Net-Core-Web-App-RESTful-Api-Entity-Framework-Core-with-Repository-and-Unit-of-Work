using FrameworkTwo.BusinessLayer.Interface;
using FrameworkTwo.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FrameworkTwo.Service.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private IStudentLogic studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            this.studentLogic = studentLogic;
        }

        // GET api/student
        [HttpGet]
        public IActionResult Get()
        {
            List<StudentModel> studentModel = studentLogic.GetStudents();

            if (studentModel == null)
            {
                return NotFound();
            }

            return new ObjectResult(studentModel);
        }

        // GET api/student/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/student
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/student/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/student/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
