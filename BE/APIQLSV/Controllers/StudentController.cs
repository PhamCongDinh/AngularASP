using APIQLSV.Models;
using APIQLSV.Models.Req;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace APIQLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentManagementContext DB = new StudentManagementContext();

        [HttpGet("lststu")]
        public JsonResult lststu()
        {

            var lst = from s in DB.Students
                      join c in DB.Classes on s.IdClasses equals c.Id
                      select new
                      {
                          id = s.Id,
                          StudentName = s.StudentName,
                          dateOfBirth = s.DateOfBirth,
                          town = s.Town,
                          nameclass = c.NameClass,
                      };
            return new JsonResult(new { Message = "Success", data = lst });
        }

       
        [HttpGet("Getstubyid")]
        public JsonResult Getstubyid([FromQuery] int id)
        {
            var lst = from s in DB.Students
                      join c in DB.Classes on s.IdClasses equals c.Id
                      where s.Id== id
                      select new
                      {
                          id = s.Id,
                          StudentName = s.StudentName,
                          dateOfBirth = s.DateOfBirth,
                          town = s.Town,
                          nameclass = c.NameClass,
                      };
            return new JsonResult(new {Message = "Success",data=lst});
        }
        [HttpGet("lstallpoint")]
        public JsonResult lstallpoint([FromQuery] int id)
        {
            var lst = from s in DB.Students
                      join c in DB.Classes on s.IdClasses equals c.Id
                      join sc in DB.StuCours on s.Id equals sc.IdStudent
                      join course in DB.Courses on sc.IdCourses equals course.Id
                      where s.Id == id
                      select new
                      {
                          StudentID = s.Id,
                          StudentName = s.StudentName,
                          ClassName = c.NameClass,
                          CourseName = course.CoursesName,
                          Number = sc.Number,
                          PointProcess = sc.PointProcess,
                          PointTest = sc.PointTest,
                          DiemKT = Math.Round((float)(sc.PointProcess * 0.4f + sc.PointTest * 0.6f), 1)
                      };
            return new JsonResult(new { Message = "Success", data = lst });

        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StudentAddReq req)
        {
            var check = DB.Students.Any(x => x.Id == req.Id);
            if (!check)
            {
                var classesEntity = DB.Classes.SingleOrDefault(c => c.NameClass == req.Nameclass);

                if (classesEntity == null)
                {
                    return new JsonResult(new { Message = "Error", Data = "Class not found" });
                }

                var student = new Student
                {
                    Id = req.Id,
                    StudentName = req.StudentName,
                    DateOfBirth = req.DateOfBirth,
                    Town = req.Town,
                    IdClasses = classesEntity.Id
                };

                if (ModelState.IsValid)
                {
                    DB.Students.Add(student);
                    DB.SaveChanges();
                    return new JsonResult(new { Message = "Success", Data = student });
                }
                else
                {
                    return new JsonResult(new { Message = "Error", Data = "Invalid model state" });
                }
            }
            else
            {
                return new JsonResult(new { Message = "Error", Data = "ID student already exists" });
            }
        }

        [HttpGet("classbyid")]
        public JsonResult classbyid()
        {
            var lst = DB.Classes;
            return new JsonResult(new { Message = "Success", data = lst });
        }




        [HttpPut("update")]
        public JsonResult update([FromBody] StudentAddReq req)
        {
            var classesEntity = DB.Classes.SingleOrDefault(c => c.NameClass == req.Nameclass);
            var student = new Student
            {
                Id = req.Id,
                StudentName = req.StudentName,
                DateOfBirth = req.DateOfBirth,
                Town = req.Town,
                IdClasses = classesEntity.Id
            };
            if (ModelState.IsValid)
            {
                try
                {
                    DB.Update(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    DB.SaveChanges();

                    return new JsonResult(new { Message = "Success", data = student });
                }
                catch (Exception ex)
                {
                    return new JsonResult($"Error: {ex.Message}");
                }
            }
            return new JsonResult("error");
        }
        [HttpDelete("delete")]
        public JsonResult delete(int id)
        {
            DB.Remove(DB.Students.Find(id));
            DB.SaveChanges();
            return new JsonResult("Success");
        }

    }
}
