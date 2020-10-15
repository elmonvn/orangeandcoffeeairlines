using System;
using System.Collections.Generic;
using System.Text;

namespace OCAirLines.Database.Models
{
    public class AppAuthentication
    {
        public int Id { get; set; }
        public string HashId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AppRole { get; set; }
    }
}
