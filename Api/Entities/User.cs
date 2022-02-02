using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    [Table(name: "user")]
    public class User : BaseEntity
    {
        [Column(name: "username")]
        [MaxLength(100)]
        public string Username { get; set; }

        [Column(name: "password")]
        [MaxLength(20)]
        public string Password { get; set; }

        [Column(name: "firstName")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column(name: "lastName")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column(name: "Email")]
        [MaxLength(100)]
        public string Email { get; set; }

    }
}