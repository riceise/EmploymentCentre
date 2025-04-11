using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmploymentCentre.Models;

public class Employer
{
    [Key, ForeignKey("User")] 
    public Guid UserId { get; set; } = Guid.NewGuid();

    public string CompanyName { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty; 
    public string Phone { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;

    public virtual User? User { get; set; }
    public virtual ICollection<Vacancy> Vacancies { get; set; }
}
