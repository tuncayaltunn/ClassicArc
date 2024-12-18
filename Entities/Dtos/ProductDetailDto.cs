﻿using System;
using Core.Entities;

namespace Entities.Dtos
{
	public class ProductDetailDto : IDto
	{
		public ProductDetailDto()
		{
		}
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string CategoryName { get; set; }
		public short UnitsInStock { get; set; }
	}
}

