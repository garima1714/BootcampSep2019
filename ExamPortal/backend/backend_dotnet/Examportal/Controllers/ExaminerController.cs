using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bcrypt = BCrypt.Net;
using Examportal.Auth;
using Examportal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Examportal.Custom_Models;
using Microsoft.AspNetCore.Authorization;

namespace Examportal.Controllers
{
    [ApiController]
    public class ExaminerController : ControllerBase
    {
        // GET: api/Examiner
        ExamportalContext db = new ExamportalContext();

        [Route("/examiner/exams")]
        [HttpGet]
        public IActionResult allExams()
        {
            Dictionary<string, string> email = new Dictionary<string, string>();

            Authentication auth = new Authentication();
            email = auth.getAllClaims(HttpContext);
            String userEmail = "";
            foreach (KeyValuePair<string, string> em in email)
            {
                userEmail = em.Value;
                break;
            }
            var exams = db.ExamDetails.Where(e => e.Email == userEmail).ToList();
            return Ok(exams);
        }
        [Route("/examiner")]
        [HttpPatch]
        public IActionResult examinerUpdate([FromBody] UpdateExaminerCustomModel value)
        {
            try
            {
                var examinerData = db.Users.FirstOrDefault(s => s.Email == value.email);
                examinerData.Name = value.name;
                examinerData.PhoneNumber = value.phoneNumber;
                examinerData.CollegeName = value.collegeName;
                value.password = Bcrypt.BCrypt.HashPassword(value.password);
                examinerData.Password = value.password;
                db.Users.Update(examinerData);
                db.SaveChanges();
                return Ok(new { message = "User Updated" });
            }
            catch (Exception e )
            {
                return BadRequest(new { error = e });
            }

        }
        [Route("/examiner/exams/students")]
        [HttpGet]
        public IActionResult allStudents()
        {
            Dictionary<string, string> email = new Dictionary<string, string>();

            Authentication auth = new Authentication();
            string examcode = HttpContext.Request.Headers["examId"].ToString();
            var answers = db.CandidateAnswer.Where(e => e.TestCode == examcode && e.Answer!= null).Count();
            var data = db.CandidateResult.Where(e => e.TestCode == examcode).ToList();
           // var rev = data.OrderByDescending(x => x.Email).ToList();
            var totalWeightage = db.Questions.Where(e => e.ExamCode == examcode).Sum(t => t.Weightage);

            //var joinQuery = db.CandidateResult.Join(db.CandidateAnswer, )
            var i = 0;
            var len = data.Count();
            List<Users> arr = new List<Users>();
            while (i < len)
            {
                var stuEmail = data[i].Email;
                var details = db.Users.FirstOrDefault(e => e.Email == stuEmail);
               
                arr.Add(details);
                i++;
            }
            return Ok(new {a= arr , b=data, c=totalWeightage});
        }

    }


}

