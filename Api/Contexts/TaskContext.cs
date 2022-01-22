using System;
using Microsoft.EntityFrameworkCore;
using Api.Entities;

namespace Api.Contexts
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; }
    }
}