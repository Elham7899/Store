namespace Store.DAL.Models;

public class Order
{
	public int Id { get; set; }

	public List<OrderItem?> OrderItem { get; set; }

	public DateTime Date { get; set; }
}
