﻿namespace Store.DAL.Models;

public class ProductItem
{
	public int Id { get; set; }

	public Product? Product { get; set; }

	public int Count { get; set; }
}
