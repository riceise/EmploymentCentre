using Microsoft.EntityFrameworkCore;
using EmploymentCentre.Models;

namespace EmploymentCentre.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Определение DbSet для каждой сущности
    public DbSet<Application> Applications { get; set; }
    public DbSet<Employer> Employers { get; set; }
    public DbSet<Response> Responses { get; set; }
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка отношений и дополнительных правил

        // User
        modelBuilder.Entity<User>()
            .HasMany(u => u.Resumes)
            .WithOne(r => r.Applicant)
            .HasForeignKey(r => r.ApplicantId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Vacancies)
            .WithOne(v => v.Employer)
            .HasForeignKey(v => v.EmployerId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Applications)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);

        // Employer (связь с User)
        modelBuilder.Entity<Employer>()
            .HasOne(e => e.User)
            .WithOne(u => u.Employer)
            .HasForeignKey<Employer>(e => e.UserId);

        // Resume и Response
        modelBuilder.Entity<Resume>()
            .HasMany(r => r.Responses)
            .WithOne(re => re.Resume)
            .HasForeignKey(re => re.ResumeId);

        // Vacancy и Response
        modelBuilder.Entity<Vacancy>()
            .HasMany(v => v.Responses)
            .WithOne(r => r.Vacancy)
            .HasForeignKey(r => r.VacancyId);

        // Убедимся, что все перечисления сохраняются как строки (если нужно)
        modelBuilder.Entity<Application>()
            .Property(a => a.Type)
            .HasConversion<string>();

        modelBuilder.Entity<Application>()
            .Property(a => a.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Response>()
            .Property(r => r.Status)
            .HasConversion<string>();

        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();

        // Дополнительные настройки, если нужны
        base.OnModelCreating(modelBuilder);
    }
}