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
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid ResumeId { get; set; }

    [ForeignKey("ResumeId")]
    public Resume Resume { get; set; }

    public Guid VacancyId { get; set; } = Guid.NewGuid();

    [ForeignKey("VacancyId")]
    public Vacancy Vacancy { get; set; }

    public ResponseStatus Status { get; set; } = ResponseStatus.Pending;

    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
}
