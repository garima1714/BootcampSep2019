using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using auth_session.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace auth_session.Controllers
{
    [Route("api/login")]
    public class loginController : Controller
    {

        private readonly auth_sessionContext db;
        //public loginController(auth_sessionContext _context)
        //{
        //    db = _context;
        //}
        // GET: api/login
        private IConfiguration _config;

        public loginController(IConfiguration config, auth_sessionContext _context)
        {
            db = _context;
            _config = config;
        }
        [HttpGet]
        public IEnumerable<Signup> Get()
        {
            var a = db.Signup.ToList();
            return a;
        }

        //GET: api/login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST: api/login
        //[HttpPost]
        ////[Route(")]
        ////public IActionResult Post([FromBody]Signup value)
        ////{
        ////    //var obj = db.Signup.FirstOrDefault(a => a.Username == value.Username);
        ////    try
        ////    {
        ////        var obj = db.Signup.FirstOrDefault(a => a.Username == value.Username);
        ////        if (obj.Username == value.Username && obj.Password == value.Password)
        ////        {
        ////            return Ok("user found");
        ////        }
        ////        return Unauthorized();
        ////    }
        ////    catch (Exception E)
        ////    {
        ////        return Unauthorized();
        ////    }
        ////}

        ////Using headers....

        ////public IActionResult POST([FromBody]dynamic loginData)
        ////{
        ////    try
        ////    {
        ////        StringValues _username;
        ////        StringValues _password;
        ////        Request.Headers.TryGetValue("username", out _username);
        ////        Request.Headers.TryGetValue("password", out _password);
        ////        String username = _username.FirstOrDefault();
        ////        String password = _password.FirstOrDefault();

        ////        Signup loggedinUser = db.Signup.Find(username);
        ////        try
        ////        {
        ////            if (loggedinUser.Password.Equals(password))
        ////            {
        ////                return Ok(true);
        ////            }
        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            return Unauthorized();
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {

        ////    }
        ////    return BadRequest();
        ////}

        ////Using Hashing.......
        [HttpPost]
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
                        String tokenString = GenerateJSONWebToken(loggedinUser);
                        return Ok(new { token = tokenString });
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



        //PUT: api/login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        //auth_sessionContext db = new auth_sessionContext();
        //[Route("login")]
        //[HttpPost]

        //public IActionResult Signup([FromBody]dynamic loginData)
        //{
        //    try
        //    {
        //        StringValues _username;
        //        StringValues _password;
        //        Request.Headers.TryGetValue("email", out _username);
        //        Request.Headers.TryGetValue("password", out _password);

        //        String username = _username.FirstOrDefault();
        //        String password = _password.FirstOrDefault();

        //        Signup loggedinUser = db.Signup.Find(username);
        //        try
        //        {
        //            if (BCrypt.Net.BCrypt.Verify(password, loggedinUser.Password))
        //            {
        //                String tokenString = GenerateJSONWebToken(loggedinUser);
        //                return Ok(new { token = tokenString });
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


        //Signup
        [Route("signup")]
            [HttpPost]
            public IActionResult Singup([FromBody]Signup signupUser)
            {
                try
                {
                    signupUser.Password = BCrypt.Net.BCrypt.HashPassword(signupUser.Password);
                    db.Signup.Add(signupUser);
                    db.SaveChanges();
                    return Ok();

                }
                catch (Exception ex)
                {

                }
                return BadRequest();
            }

            [Route("sample")]
            [HttpGet]
            [Authorize]
            public IActionResult sampleAuthRoute()
            {
                try
                {
                    var currentUser = HttpContext.User;
                    //TODO: Make claims work, currently not working
                    //if (currentUser.HasClaim(c => c.Type == "Email"))
                    //{
                    //    String email = currentUser.Claims.FirstOrDefault(c => c.Type == "Email").Value;
                    //}
                    return Ok(new { message = "Sample page working" });

                }
                catch (Exception ex)
                {

                }
                return BadRequest();
            }

            private string GenerateJSONWebToken(Signup userInfo)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[] {
                new Claim("Username", userInfo. Username),
                 new Claim("Password", userInfo.Password),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  claims,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }

