using Ganttfeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ganttfeatures.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        // GET: api/<WebApiController>
        [HttpGet]
        public object Get()
        {
            if (TaskData.ganttData.Count == 0)
            {
                TaskData.GetTree();
            }
            IEnumerable dataList = TaskData.ganttData.ToList();
            int count = dataList.Cast<TaskData>().Count();
            return new { Items = dataList, Count = count };
        }

        // GET api/<WebApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WebApiController>
        [HttpPost]
        public void Post(TaskData data)
        {
            //TaskData.ganttData.Insert(0, data);
        }

        // PUT api/<WebApiController>/5
        [HttpPut]
        public void Put(TaskData item)
        {
            var result = TaskData.ganttData.Where(or => or.ID == item.ID).FirstOrDefault();
            result.ID = item.ID;
            result.TaskName = item.TaskName;
            result.StartDate = item.StartDate;
            result.EndDate = item.EndDate;
            result.Duration = item.Duration;
            result.Progress = item.Progress;
            result.Predecessor = item.Predecessor;
            result.ParentId = item.ParentId;
            result.Assignee = item.Assignee;
            result.StoryPoint = item.StoryPoint;
        }

        // DELETE api/<WebApiController>/5
        [HttpDelete("{List<TaskData>}")]
        public void Delete(List<TaskData> items)
        {
            foreach (var rec in items)
            {
                TaskData.ganttData.Remove(TaskData.ganttData.Where(or => or.ID == rec.ID).FirstOrDefault());
            }
        }
    }
}
