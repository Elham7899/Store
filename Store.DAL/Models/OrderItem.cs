namespace Store.DAL.Models;

public class OrderItem
{
	public int Id { get; set; }

	public int Count { get; set; }

	public Product? Products { get; set; }
}
