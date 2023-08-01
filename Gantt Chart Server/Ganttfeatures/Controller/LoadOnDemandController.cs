using Ganttfeatures.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ganttfeatures.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadOnDemandController : ControllerBase
    {
        public static IDictionary<string, object> queryParams = null;
        IEnumerable DataSource = null;

        // GET: api/<LoadOnDemandController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoadOnDemandController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoadOnDemandController>
        [HttpPost]
        public object Post([FromBody] DataManagerRequest dm)
        {

            queryParams = dm.Params;
            if (TaskData.tree.Count == 0)
            {
                TaskData.GetTree();
            }
            DataSource = TaskData.tree.ToList();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = DataOperations.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<TaskData>().Count();
            if (dm.Skip != 0)
            {
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            bool lod = queryParams != null && queryParams.ContainsKey("loadchildondemand") && bool.Parse(dm.Params["loadchildondemand"].ToString());
            if (lod)
            {
                DataSource = Pages.Gantt.DataBinding.LoadOnDemand.FetchChildRecords(DataSource, Request.Query);
            }
            return new { result = DataSource, count = count };
        }

        // PUT api/<LoadOnDemandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoadOnDemandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
