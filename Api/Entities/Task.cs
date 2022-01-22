using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    [Table(name: "task")]
    public class Task : BaseEntity
    {
        [Column(name: "guid")]
        public string Guid { get; set; }
        [Column(name: "title")]
        public string Title { get; set; }
        [Column(name: "description")]
        public string Description { get; set; }
    }
}