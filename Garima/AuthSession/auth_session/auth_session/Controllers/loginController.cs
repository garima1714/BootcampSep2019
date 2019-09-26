using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_session.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace auth_session.Controllers
{
    [Route("api/login")]
    public class loginController : Controller
    {

        private readonly auth_sessionContext db;
        public loginController(auth_sessionContext _context)
        {
            db = _context;
        }
        // GET: api/login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/login
        [HttpPost]
        //[Route(")]
        public IActionResult Post([FromBody]Signup value)
        {
            
            //var obj = db.Signup.FirstOrDefault(a => a.Username == value.Username);
            
            try
            {
                var obj = db.Signup.FirstOrDefault(a => a.Username == value.Username);
                if (obj.Username == value.Username && obj.Password == value.Password)
                {
                    return Ok("user found");
                }
                return Unauthorized();
            }
            catch (Exception E)
            {
                return Unauthorized();
            }
           
                    
        }
        
        // PUT: api/login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
