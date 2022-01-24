using Api.Services;
using Api.Entities;
using Api.Contexts;
using Api.Repositories;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Api.Services
{
    public class TaskService
    {
        private TaskRepository taskRepository;
        public TaskService(TaskContext taskContext)
        {
            this.taskRepository = new TaskRepository(taskContext);
        }
        public async System.Threading.Tasks.Task<Task> CreateTask(Task task)
        {
            return await this.taskRepository.CreateTask(task);
        }

        public async System.Threading.Tasks.Task<List<Task>> GetAllTasks()
        {
            return await this.taskRepository.GetAllTasks();
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

        internal async System.Threading.Tasks.Task<PagingResponse<List<Task>>> GetTaskByPaging(PagingRequest pagingRequest)
        {
            PagingResponse<List<Task>> result = new PagingResponse<List<Task>>();

            int totalSize = await this.taskRepository.GetTotalSize(pagingRequest.Filters);
            List<Task> data = await this.taskRepository.GetTaskByPaging(pagingRequest.Page, pagingRequest.PageSize, pagingRequest.Filters);
            result.TotalSize = totalSize;
            result.Page = pagingRequest.Page;
            result.PageSize = pagingRequest.PageSize;
            result.Data = data;
            return result;
        }
    }
}