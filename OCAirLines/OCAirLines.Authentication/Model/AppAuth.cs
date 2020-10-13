using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Authentication.Model
{
    public class AppAuth
    {
        public int AppId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AppRole { get; set; }
    }
}
