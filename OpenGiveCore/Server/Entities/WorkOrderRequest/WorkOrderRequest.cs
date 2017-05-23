using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGiveCore.Server.Entities
{
    public class WorkOrderRequest
    {
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string RequestorEmail { get; set; }
		public bool IsApproved { get; set; } = false;
	}
}
