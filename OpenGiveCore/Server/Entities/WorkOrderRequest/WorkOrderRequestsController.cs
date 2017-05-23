using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace OpenGiveCore.Server.Entities
{
    [Route("api/[controller]")]
    public class WorkOrderRequestsController : Controller
    {
		private readonly LadotContext _context;
		public WorkOrderRequestsController(LadotContext context)
		{
			_context = context;
		}
        
		/// <summary>
		/// Gets all the Work Order Requests
		/// </summary>
		/// <returns>All work order requests</returns>
        [HttpGet]
        public IEnumerable<WorkOrderRequest> Get()
        {
           return _context.WorkOrderRequests.ToList();
        }

        /// <summary>
		/// Saves a new work order request
		/// </summary>
		/// <param name="workOrderRequest">The work order request to save</param>
        [HttpPost]
        public async void Post([FromBody]WorkOrderRequest workOrderRequest)
        {
			_context.WorkOrderRequests.Add(workOrderRequest);
			_context.SaveChanges();
			HttpClient client = new HttpClient();
			var content = new StringContent(JsonConvert.SerializeObject(workOrderRequest), Encoding.UTF8, "application/json");
			await client.PostAsync("https://prod-08.northcentralus.logic.azure.com/workflows/573b6c8bc4b34f348f49e33315986abb/triggers/manual/paths/invoke/api/workorderrequests?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=vOwp5O3rbBMLLaIySg4oJ26fvDAvCL0e4oYbYbJEAjg", content);
        }

    }
}
