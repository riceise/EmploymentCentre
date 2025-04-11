namespace EmploymentCentre.Models;

using System.ComponentModel.DataAnnotations;

public enum UserRole
{
    Applicant,
    Employer,
    Admin
}

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    public string FullName { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public UserRole Role { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Навигационные свойства
    public ICollection<Resume> Resumes { get; set; }
    public ICollection<Vacancy> Vacancies { get; set; }
    public ICollection<Application> Applications { get; set; }
    public virtual Employer? Employer { get; set; } 

}

