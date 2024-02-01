using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiredFirst.Domain.DTO
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public bool Success { get; set; }
        public string UserId { get; set; }
    }
}
