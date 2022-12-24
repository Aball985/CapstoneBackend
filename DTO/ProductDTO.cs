using System.ComponentModel.DataAnnotations;

namespace CapstoneBackend.DTOs;

public class ProductDTO
{
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
    [Required]
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; }
}