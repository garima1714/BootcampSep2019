using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_session.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

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
        public IEnumerable<Signup> Get()
        {
            var a = db.Signup.ToList();
            return a;
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
        //public IActionResult Post([FromBody]Signup value)
        //{
        //    //var obj = db.Signup.FirstOrDefault(a => a.Username == value.Username);
        //    try
        //    {
        //        var obj = db.Signup.FirstOrDefault(a => a.Username == value.Username);
        //        if (obj.Username == value.Username && obj.Password == value.Password)
        //        {
        //            return Ok("user found");
        //        }
        //        return Unauthorized();
        //    }
        //    catch (Exception E)
        //    {
        //        return Unauthorized();
        //    }
        //}

        //Using headers....

        //public IActionResult POST([FromBody]dynamic loginData)
        //{
        //    try
        //    {
        //        StringValues _username;
        //        StringValues _password;
        //        Request.Headers.TryGetValue("username", out _username);
        //        Request.Headers.TryGetValue("password", out _password);
        //        String username = _username.FirstOrDefault();
        //        String password = _password.FirstOrDefault();

        //        Signup loggedinUser = db.Signup.Find(username);
        //        try
        //        {
        //            if (loggedinUser.Password.Equals(password))
        //            {
        //                return Ok(true);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return Unauthorized();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return BadRequest();
        //}

        //Using Hashing.......

        public IActionResult POST([FromBody]Signup value)
        {
            try
            {
                String hashedPassword;
                StringValues _username;
                StringValues _password;
                Request.Headers.TryGetValue("username", out _username);
                Request.Headers.TryGetValue("password", out _password);
                String username = _username.FirstOrDefault();
                String password = _password.FirstOrDefault();
                Signup loggedinUser = db.Signup.Find(username);
                hashedPassword = loggedinUser.Password;
                bool validPassword = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                
                try
                {
                   
                    if (validPassword == true)
                    {
                        
                        return Ok(true);
                    }
                }
                catch (Exception ex)
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {

            }
            return BadRequest();
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
