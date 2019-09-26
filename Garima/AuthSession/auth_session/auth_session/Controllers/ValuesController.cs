using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_session.Models;
using Microsoft.AspNetCore.Mvc;

namespace auth_session.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        
        private readonly auth_sessionContext dc;
        private String hashedPassword;
        public ValuesController(auth_sessionContext context)
        {
            dc = context;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Signup> Get()
        {
            var a = dc.Signup.ToList();
            return a;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Signup value)
        {
            try
            {
                hashedPassword = BCrypt.Net.BCrypt.HashPassword(value.Password);
                value.Password = hashedPassword;
                dc.Signup.Add(value);
                dc.SaveChanges();
                return Ok(value);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

