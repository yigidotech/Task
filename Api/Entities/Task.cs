using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    [Table(name: "task")]
    public class Task : BaseEntity
    {
        [Column(name: "guid")]
        [MaxLength(36)]
        public string Guid { get; set; }
        [Column(name: "title")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Column(name: "description")]
        [MaxLength(500)]
        public string Description { get; set; }
        [Column(name: "is_completed")]
        public bool IsCompleted { get; set; }
    }
}