﻿using Examportal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace Examportal.Controllers
{
    [Route("/examiner")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        ExamportalContext db = new ExamportalContext();
        // GET: api/Admin
        [HttpGet]
        public IActionResult display()
        {
            var itm = db.Users.Where(e => e.AccountType == "Examiner")
                .Select(a => new { a.Email, _id = a.Email, a.Name, a.CreatedDate });
            return Ok(itm);
        }

        // GET: api/Admin/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admin
        //[HttpPost]
        //public IActionResult Post([FromBody] Users value)
        //{
        //    var data = (from c in db.Users where c.Email == value.Email select c).FirstOrDefault();
        //    if (data != null)
        //    {
        //        return Ok(new { message = "user already exist" });
        //    }
        //    else if (data == null)
        //    {
        //        value.Password = Bcrypt.BCrypt.HashPassword(value.Password);
        //        value.CreatedDate = DateTime.Now;
        //        db.Users.Add(value);
        //        db.SaveChanges();
        //        return Ok(true);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }

        //}
        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult deleteexaminer(String id)
        {
            var data = db.Users.FirstOrDefault(e => e.Email == id);
            db.Users.Remove(data);
            db.SaveChanges();
            return Ok(true);
        }
    }
}
