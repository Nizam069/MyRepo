using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NetCoreApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Students : ControllerBase
    {
        List<Student> _oStudents = new List<Student>() { 
        new Student(){ Id=1,Name="Shaik Nizam",Roll=1001 },
         new Student(){ Id=2,Name="Seema Nizam",Roll=1002 },
          new Student(){ Id=3,Name="Shaik Seema",Roll=1003 },
           new Student(){ Id=4,Name="Shaik Sheeza",Roll=1004 },
            new Student(){ Id=5,Name="Shaik Sasha",Roll=1005 },
        };
        [HttpGet]
        public IActionResult Gets()
        {
            if(_oStudents.Count==0)
            {
                return NotFound("No List Found");
            }
            return Ok(_oStudents);
        }

        [HttpGet("GetStudent")]
        public IActionResult Get(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x=>x.Id==id);
            if(oStudent == null)
            {
                return NotFound("No Student Found");
            }
            return Ok(oStudent);
        }

        [HttpPost]
        public IActionResult Save(Student oStudent)
        {
            _oStudents.Add(oStudent);
            if(_oStudents.Count==0)
            {
                return NotFound("No List Found");
            }
            return Ok(_oStudents);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x=>x.Id==id);
            if (_oStudents.Count == 0)
            {
                return NotFound("No List Found");
            }
            _oStudents.Remove(oStudent);

            if (_oStudents.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(_oStudents);
        }

    }
}
