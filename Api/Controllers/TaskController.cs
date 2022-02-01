using System;
using System.Collections.Generic;
using System.Linq;
using Api.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Services;
using Api.Entities;
using Microsoft.AspNetCore.Http;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ILogger<TaskController> _logger;
        // private readonly TaskContext _taskContext;
        private TaskService taskService;
        public TaskController(ILogger<TaskController> logger, TaskContext taskContext)
        {
            _logger = logger;
            // _taskContext = taskContext;
            this.taskService = new TaskService(taskContext);
        }

        [HttpGet("get-task-by-id")]
        public async System.Threading.Tasks.Task<ActionResult<Task>> GetTaskById(int id)
        {
            try
            {
                var result = await taskService.GetTaskById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("get-all-tasks")]
        public async System.Threading.Tasks.Task<List<Task>> GetAllTasks()
        {
            List<Task> tasks = await this.taskService.GetAllTasks();
            return tasks;
        }

        [HttpGet("get-all-tasks-by-is-completed")]
        public async System.Threading.Tasks.Task<List<Task>> GetAllTasksByIsCompleted(bool isCompleted)
        {
            List<Task> tasks = await this.taskService.GetAllTasksByIsCompleted(isCompleted);
            return tasks;
        }

        [HttpGet("get-task-by-paging")]
        public async System.Threading.Tasks.Task<PagingResponse<List<Task>>> GetTaskByPaging(PagingRequest pagingRequest)
        {
            PagingResponse<List<Task>> tasks = await this.taskService.GetTaskByPaging(pagingRequest);
            return tasks;
        }
        [HttpGet("get-task-total-size-by-filter")]
        public async System.Threading.Tasks.Task<int> GetTaskTotalSizeByFiter(List<Filter> filters)
        {
            int totalSize = await this.taskService.GetTaskTotalSizeByFiter(filters);
            return totalSize;
        }

        [HttpPost("create-task")]
        public async System.Threading.Tasks.Task<Task> CreateTask([FromBody] Task task)
        {
            Task createdTask = await this.taskService.CreateTask(task);
            return createdTask;
        }

        [HttpDelete("delete-task")]
        public async System.Threading.Tasks.Task<Task> DeleteTaskById(int id)
        {
            return await this.taskService.DeleteTaskById(id);
        }

        [HttpPut("update-task")]
        public async System.Threading.Tasks.Task<ActionResult<Task>> UpdateTask(int id, Task task)
        {
            try
            {
                if (id != task.Id)
                {
                    return BadRequest("Task ID mismatch");
                }

                Task taskToUpdate = await taskService.GetTaskById(id);

                if (taskToUpdate == null)
                {
                    return NotFound($"Task with Id = {id} not found");
                }

                return await taskService.UpdateTask(task);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpPut("change-task-complete")]
        public async System.Threading.Tasks.Task<ActionResult<Task>> ChangeTaskComplete(Task task)
        {
            try
            {
                return await taskService.ChangeTaskCompleted(task);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
