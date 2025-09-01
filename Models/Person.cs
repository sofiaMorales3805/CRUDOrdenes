namespace Api;

public class Person
{
 public int PersonId { get; set; }
public string FirstName { get; set; } = string.Empty;
public string LastName { get; set; } = string.Empty;
public string Email { get; set; } = string.Empty;
public DateTime CreatedAt { get; set; }
public DateTime? UpdatedAt { get; set; }
public List<Order> Orders { get; set; } = [];
}
