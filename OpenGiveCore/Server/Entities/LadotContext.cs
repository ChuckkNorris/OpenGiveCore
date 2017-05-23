using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenGiveCore.Server.Entities
{
    public class LadotContext : DbContext
    {
		public LadotContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<WorkOrderRequest> WorkOrderRequests { get; set; }
	}
}
