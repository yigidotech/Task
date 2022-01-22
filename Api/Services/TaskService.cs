using Api.Services;
using Api.Entities;
using Api.Contexts;
using Api.Repositories;
using System.Collections.Generic;
using System;

namespace Api.Services
{
    public class TaskService
    {
        private TaskRepository taskRepository;
        public TaskService(TaskContext taskContext)
        {
            this.taskRepository = new TaskRepository(taskContext);
        }
        public Task SaveTask(Task task)
        {
            return this.taskRepository.SaveTask(task);
        }

        public List<Task> GetAllTasks()
        {
            return this.taskRepository.GetAllTasks();
        }

        public async System.Threading.Tasks.Task<Task> DeleteTaskById(int id)
        {
            return await this.taskRepository.DeleteTaskById(id);
        }

        public async System.Threading.Tasks.Task<Task> UpdateTask(Task task)
        {
            return await this.taskRepository.UpdateTask(task);
        }

        public async System.Threading.Tasks.Task<Task> GetTaskById(int id)
        {
            return await this.taskRepository.GetTaskById(id);
        }
    }
}