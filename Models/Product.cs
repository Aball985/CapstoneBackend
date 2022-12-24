using System.ComponentModel.DataAnnotations;

namespace CapstoneBackend.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
    [Required]
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; }
}