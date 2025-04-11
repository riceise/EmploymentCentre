using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploymentCentre.Models;

public class Vacancy
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid EmployerId { get; set; }

    [ForeignKey("EmployerId")]
    public User Employer { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string City { get; set; }

    public decimal SalaryFrom { get; set; }

    public decimal SalaryTo { get; set; }

    public DateTime PostedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Response> Responses { get; set; }
}
