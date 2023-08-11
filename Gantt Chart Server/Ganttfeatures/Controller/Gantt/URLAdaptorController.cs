using Ganttfeatures.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor;
using System.Collections;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ganttfeatures.Controller
{

    [ApiController]
    public class URLAdaptorController : ControllerBase
    {
        // POST api/<URLAdaptorController>
        [HttpPost]
        [Route("api/[controller]")]
        public object Post([FromBody] DataManagerRequest dm)
        {
            if (TaskData.ganttData.Count == 0)
            {
                TaskData.GetTree();
            }
            IEnumerable dataList = TaskData.ganttData.ToList();
            int count = dataList.Cast<TaskData>().Count();
            return new { result = dataList, count = count };
        }

        [HttpPost]
        [Route("api/URLAdaptor/BatchUpdate")]
        public void BatchUpdate([FromBody] CRUDModel<TaskData> data)
        {
            List<TaskData> uAdded = new List<TaskData>();
            if (data.Added != null && data.Added.Count() > 0)
            {
                foreach (var rec in data.Added)
                {
                    for (var i = 0; i < data.Added.Count(); i++)
                    {
                        TaskData.ganttData.Insert(0, data.Added[i]);
                    }
                }
            }
            if (data.Changed != null && data.Changed.Count() > 0)
            {
                foreach (var item in data.Changed)
                {
                    var result = TaskData.ganttData.Where(or => or.ID == item.ID).FirstOrDefault();
                    if (result != null)
                    {
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
                }
            }
            if (data.Deleted != null && data.Deleted.Count() > 0)
            {
                foreach (var rec in data.Deleted)
                {
                    TaskData.ganttData.Remove(TaskData.ganttData.Where(or => or.ID == rec.ID).FirstOrDefault());
                    RemoveChildRecords(rec.ID);
                }
            }
        }
        [NonAction]
        public void RemoveChildRecords(int id)
        {
            var childList = TaskData.ganttData.Where(x => x.ParentId == id).ToList();
            foreach (var item in childList)
            {
                TaskData.ganttData.Remove(TaskData.ganttData.Where(or => or.ID == item.ID).FirstOrDefault());
                RemoveChildRecords(item.ID);
            }
        }
        public class CRUDModel<T> where T : class
        {
            public object Key { get; set; }
            public string KeyColumn { get; set; }
            public string Action { get; set; }
            public IDictionary<string, object> Params { get; set; }
            public string Table { get; set; }
            public T Value { get; set; }
            public List<T> Added { get; set; }
            public List<T> Changed { get; set; }
            public List<T> Deleted { get; set; }

        }
    }
}
