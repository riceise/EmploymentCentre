using System.ComponentModel.DataAnnotations.Schema;

namespace EmploymentCentre.Models;

public enum ResponseStatus
{
    Pending,
    Accepted,
    Rejected
}

public class Response
{
    public int Id { get; set; }

    public int ResumeId { get; set; }

    [ForeignKey("ResumeId")]
    public Resume Resume { get; set; }

    public int VacancyId { get; set; }

    [ForeignKey("VacancyId")]
    public Vacancy Vacancy { get; set; }

    public ResponseStatus Status { get; set; } = ResponseStatus.Pending;

    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
}
