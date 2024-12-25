using System.ComponentModel.DataAnnotations;

namespace SingleDB.DTOs;

public record CreateProductRequest([Required]string Name, string Description);
