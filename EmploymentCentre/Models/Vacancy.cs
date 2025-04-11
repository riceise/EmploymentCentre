using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploymentCentre.Models;

public class Vacancy
{
    public int Id { get; set; }

    [Required]
    public int EmployerId { get; set; }

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
