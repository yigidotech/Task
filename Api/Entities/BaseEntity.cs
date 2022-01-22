using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    public class BaseEntity
    {

        [Column(name: "id")]
        public long Id { get; set; }
        [Column(name: "insert_date")]
        public DateTime InsertDate { get; set; }
        [Column(name: "last_update_date")]
        public DateTime LastUpdateDate { get; set; }
        [Column(name: "created_by")]
        public int CreatedBy { get; set; }
    }
}