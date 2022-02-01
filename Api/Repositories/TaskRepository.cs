using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Api.Contexts;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
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

        public async System.Threading.Tasks.Task<Task> CreateTask(Task task)
        {
            task.Guid = Guid.NewGuid().ToString();
            Task createdTask = null;
            try
            {
                DateTime now = DateTime.Now;
                task.InsertDate = now;
                task.LastUpdateDate = now;
                this._taskContext.Tasks.Add(task);
                await this._taskContext.SaveChangesAsync();
                createdTask = this._taskContext.Tasks.Where(x => x.Guid == task.Guid).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return createdTask;
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
                updateTask.IsActive = task.IsActive;
                updateTask.IsCompleted = task.IsCompleted;
                updateTask.IsDeleted = task.IsDeleted;
                await _taskContext.SaveChangesAsync();

                return updateTask;
            }

            return null;
        }
        IQueryable<Task> GetTaskQuery(List<Filter> filters)
        {
            IQueryable<Task> query = _taskContext.Tasks.Where(x => x.CreatedBy == 1);
            // var sql = from t in _taskContext.Tasks
            //           where t.CreatedBy == 1
            //           select t;

            // sql = sql.Where(x => x.Id == 1);
            // var tasks = sql.ToListAsync();
            foreach (Filter filter in filters)
            {
                switch (filter.Field.Trim().ToUpper())
                {
                    case "DESCRIPTION":
                        {
                            query = query.Where(x => x.Description.Contains(filter.Datas[0].ToString()));
                            break;
                        }
                    case "GUID":
                        {
                            query = query.Where(x => x.Guid == filter.Datas[0].ToString());
                            break;
                        }
                    case "TITLE":
                        {
                            query = query.Where(x => x.Title.Contains(filter.Datas[0].ToString()));
                            // sql.Where(x => x.Title.Contains(filter.Datas[0].ToString()));
                            break;
                        }
                    case "ID":
                        {
                            query = query.Where(x => x.Id == long.Parse(filter.Datas[0].ToString()));
                            break;
                        }
                    case "INSERTDATE":
                        {
                            query = query.Where(x => x.InsertDate >= DateTime.Parse(filter.Datas[0].ToString()) && x.InsertDate <= DateTime.Parse(filter.Datas[1].ToString()));
                            break;
                        }
                    case "LASTUPDATEDATE":
                        {
                            query = query.Where(x => x.LastUpdateDate >= DateTime.Parse(filter.Datas[0].ToString()) && x.LastUpdateDate <= DateTime.Parse(filter.Datas[1].ToString()));
                            break;
                        }
                    case "CREATEDBY":
                        {
                            query = query.Where(x => x.CreatedBy == int.Parse(filter.Datas[0].ToString()));
                            break;
                        }
                    case "ISACTIVE":
                        {
                            query = query.Where(x => x.IsActive == bool.Parse(filter.Datas[0].ToString()));
                            break;
                        }
                    case "ISDELETED":
                        {
                            query = query.Where(x => x.IsDeleted == bool.Parse(filter.Datas[0].ToString()));
                            break;
                        }
                }
            }
            return query;
        }

        internal async System.Threading.Tasks.Task<ActionResult<Task>> ChangeTaskCompleted(Task task)
        {
            Task updateTask = await this._taskContext.Tasks.Where(x => x.Id == task.Id).FirstOrDefaultAsync();
            if (updateTask != null)
            {
                updateTask.IsCompleted = task.IsCompleted;
                this._taskContext.Tasks.Update(updateTask);
                this._taskContext.SaveChanges();
            }
            else
            {

            }
            return updateTask;
        }

        internal async System.Threading.Tasks.Task<List<Task>> GetTaskByPaging(int page, int pageSize, List<Filter> filters)
        {
            List<Task> result;
            IQueryable<Task> query = this.GetTaskQuery(filters);
            query = query.Skip((page * pageSize) - pageSize).Take(pageSize);
            result = await query.ToListAsync();
            return result;
        }
        internal async System.Threading.Tasks.Task<int> GetTotalSize(List<Filter> filters)
        {
            IQueryable<Task> query = this.GetTaskQuery(filters);
            int result = await query.CountAsync();
            return result;
        }

        public async System.Threading.Tasks.Task<Task> GetTaskById(long id)
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

        public async System.Threading.Tasks.Task<List<Task>> GetAllTasks()
        {
            List<Task> tasks = null;
            try
            {
                tasks = await this._taskContext.Tasks.ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return tasks;
        }
        public async System.Threading.Tasks.Task<List<Task>> GetAllTasksByIsCompleted(bool isCompleted)
        {
            List<Task> tasks = null;
            try
            {
                tasks = await this._taskContext.Tasks.Where(x => x.IsCompleted == isCompleted).ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return tasks;
        }
    }
}