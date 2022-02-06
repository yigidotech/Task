using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}