using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementWithWS
{


    [Route("api/[controller]")]
    [ApiController]

    
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService m_studentService;
        public StudentsController(IStudentService studentService)
        {
            m_studentService = studentService;
        }

        [HttpGet]
        public IActionResult SearchStudent(string keyword, string hutechClass)
        {

            return Ok(m_studentService.SearchStudent(keyword, hutechClass));
        }

        [HttpGet("{id}")]
        public IActionResult LoadStudentById(int id)
        {

            return Ok(m_studentService.LoadStudentById(id));
        }

        [HttpDelete ("{id}")]
        public IActionResult DeleteStudentById(int id)
        {
            return Ok(DeleteStudentById(id));
        }

    }
}
