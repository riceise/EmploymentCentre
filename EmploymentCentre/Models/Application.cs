using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EmploymentCentre.Models;
public enum ApplicationType
{
    Benefit,
    Training,
    Consultation
}

public enum ApplicationStatus
{
    New,
    InProgress,
    Approved,
    Rejected
}

public class Application
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    public ApplicationType Type { get; set; }

    public string Description { get; set; } = string.Empty;

    public ApplicationStatus Status { get; set; } = ApplicationStatus.New;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
