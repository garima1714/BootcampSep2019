using System;
using System.Collections.Generic;

namespace auth_session.Models
{
    public partial class Signup
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Collegename { get; set; }
        public string Collegeid { get; set; }
    }
}
