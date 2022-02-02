using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    public class LoginResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
        
    }
}