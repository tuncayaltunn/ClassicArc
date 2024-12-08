using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
	public class Order : IEntity
	{
		public Order()
		{
		}
		[Key]
		public int order_id { get; set; }
        public string customer_id { get; set; }
        public int employee_id { get; set; }
		public DateTime order_date { get; set; }
		public string ship_city { get; set; }
	}
}

