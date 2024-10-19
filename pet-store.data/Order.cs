using System.ComponentModel.DataAnnotations;

namespace pet_store.Data;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public ICollection<Product> Products { get; set; }
}