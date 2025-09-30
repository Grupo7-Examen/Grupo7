using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPI.Models;

public class SupportTicket
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Subject { get; set; } = null!;

    [Required, EmailAddress, MaxLength(150)]
    public string RequesterEmail { get; set; } = null!;

    public string? Description { get; set; }

    [Required, MaxLength(50)]
    public string Severity { get; set; } = null!; // Ej: Low, Medium, High

    [Required, MaxLength(50)]
    public string Status { get; set; } = null!; // Ej: Open, In Progress, Closed

    public DateTime OpenedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ClosedAt { get; set; }

    [MaxLength(100)]
    public string? AssignedTo { get; set; }
}