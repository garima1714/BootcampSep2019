﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examportal.Auth;
using Examportal.Handlers;
using Examportal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Examportal.Controllers
{
    [Route("[controller]")]
    public class examDetailsController : ControllerBase
    {
        public IConfiguration _config;
        public examDetailsController(IConfiguration config)
        {
            _config = config;
        }
        [Authorize,HttpPost, Route("/exam")]
        public IActionResult SaveExam([FromBody] ExamDetails examDetails)
        {
            SaveExamDetails exam = new SaveExamDetails();
            if (exam.SaveExam(examDetails,HttpContext))
                return Ok(new { msg = "exam save successfully", status = 200, flag = true });
            return BadRequest(new { msg = "something went wrong", status = 404,flag = false });
        }
        
        [Authorize,HttpGet,Route("/exam")]
        public IActionResult ViewExamDeatils()
        {
            SaveExamDetails exam = new SaveExamDetails();
            var data = exam.ViewExamDetails(HttpContext);
            if( data != null)
            {
                return Ok(data);
            }
            return BadRequest(new { msg = "Not found", status = 404 });
        }
        
        [Authorize, HttpGet,Route("/exam/{id}")]
        public IActionResult ViewExamDetailForUpdate(int id )
        {
            SaveExamDetails exam = new SaveExamDetails();
            var data = exam.ViewExamDeatilForUpdate(id);
            if (data != null)
                return Ok(data);
            return BadRequest(new { msg = "Not Found", status = 404 });
        }
        
        
        [Authorize, HttpPatch,Route("/exam/{id}")]
        public IActionResult EditExamDeatils(int id , [FromBody] ExamDetails val )
        {
<<<<<<< HEAD
            try
            {
                Dictionary<string, string> email = new Dictionary<string, string>();

                Authentication auth = new Authentication();
                email = auth.getAllClaims(HttpContext);

                var data = db.ExamDetails.FirstOrDefault(e => e.Id == id);
                data.ExamName = val.ExamName; data.ExamDuration = val.ExamDuration; data.ExamStartTime = val.ExamStartTime;
                data.ModifiedDate = DateTime.Now;

                Users obj = db.Users.FirstOrDefault(e => e.Email == email["Email"]);
                //data.ModifiedBy = obj.Name;

                db.SaveChanges();
                return Ok(new { message = "Exams Details Updated" });
            }catch(Exception e)
            {
                return BadRequest(new { error = e });
            }
=======
            SaveExamDetails exam = new SaveExamDetails();
            if (exam.EditExamDetails(id, val, HttpContext))
                return Ok(new { msg = "update successful", Status = 200 });
            return BadRequest(new { msg = "Not Found", status = 404 });
>>>>>>> upstream/development
        }
        
        [Authorize, HttpDelete,Route("/exam/{id}")]
        public IActionResult RemoveExamDetails(int id)
        {
            SaveExamDetails exam = new SaveExamDetails();

            if( exam.RemoveExamDetails(id))
            return Ok(new { msg = "exam deleted", status = 200 });

            return BadRequest(new { msg="Not Found",status=404});
        }
    }
}