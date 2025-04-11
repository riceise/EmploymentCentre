namespace EmploymentCentre.Models;

public class Resume
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty; 
    public string Education { get; set; } = string.Empty;
    public string WorkExperience { get; set; } = string.Empty;
    public string Skills { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int ApplicantId { get; set; }
    public virtual User? Applicant { get; set; }
    public virtual ICollection<Response> Responses { get; set; }
}
