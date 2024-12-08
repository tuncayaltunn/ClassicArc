using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities;


namespace Entities.Concrete
{
	public class Category : IEntity
    {
		public Category()
		{
		}
		[Key]
		public int category_id { get; set; }

		public string category_name { get; set; }
	}
}

