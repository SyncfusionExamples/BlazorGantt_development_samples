using Ganttfeatures.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ganttfeatures.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class URLAdaptorController : ControllerBase
    {
        // GET: api/<URLAdaptorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<URLAdaptorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<URLAdaptorController>
        [HttpPost]
        public object Post([FromBody] DataManagerRequest dm)
        {
            IEnumerable DataSource = GanttData.GetSelfDataSource();
            int count = DataSource.Cast<GanttData.TaskData>().Count();
            return new { result = DataSource, count = count };
        }

        // PUT api/<URLAdaptorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<URLAdaptorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
