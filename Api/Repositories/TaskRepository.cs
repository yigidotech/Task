using System;
using System.Collections.Generic;
using System.Linq;
using Api.Contexts;
using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class TaskRepository
    {
        private TaskContext _taskContext;
        // public TaskRepository(TaskContext taskContext)
        public TaskRepository(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public Task SaveTask(Task task)
        {
            task.Guid = Guid.NewGuid().ToString();
            Task savedTask = null;
            try
            {
                DateTime now = DateTime.Now;
                task.InsertDate = now;
                task.LastUpdateDate = now;
                this._taskContext.Tasks.Add(task);
                this._taskContext.SaveChanges();
                savedTask = this._taskContext.Tasks.Where(x => x.Guid == task.Guid).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return savedTask;
        }

        public async System.Threading.Tasks.Task<Task> UpdateTask(Task task)
        {
            var updateTask = await _taskContext.Tasks
         .FirstOrDefaultAsync(e => e.Id == task.Id);

            if (updateTask != null)
            {
                updateTask.CreatedBy = task.CreatedBy;
                updateTask.Description = task.Description;
                updateTask.Guid = task.Guid;
                updateTask.InsertDate = task.InsertDate;
                updateTask.LastUpdateDate = DateTime.Now;
                updateTask.Title = task.Title;

                await _taskContext.SaveChangesAsync();

                return updateTask;
            }

            return null;
        }

        public async System.Threading.Tasks.Task<Task> GetTaskById(int id)
        {
            return await _taskContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async System.Threading.Tasks.Task<Task> DeleteTaskById(int id)
        {
            var result = await _taskContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (result != null)
            {
                _taskContext.Tasks.Remove(result);
                await _taskContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public List<Task> GetAllTasks()
        {
            List<Task> tasks = null;
            try
            {
                tasks = this._taskContext.Tasks.ToList();
            }
            catch (Exception ex)
            {

            }
            return tasks;
        }
    }
}