using Bogus;
using Bogus.DataSets;
using Server.Context;
using Shared.DTO.Questions;
using Shared.DTO.Answers;
using Shared.Enums;
using Shared.Models.Applicant;
using Shared.Models.Questions;
using static MudBlazor.Icons;

namespace Server.Data;

public class SeedData
{

    public static void EnsureSeeded(IServiceProvider services)
    {
        var factory = services.GetRequiredService<IServiceScopeFactory>();
        using var scope = factory.CreateScope();
        using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        //db.Database.EnsureDeleted();
        if (db.Database.EnsureCreated())
        {
            AddApplicants(db);
            AddQuestions(db);
        }        
    }

    private static void AddQuestions(AppDbContext db)
    {
        db.Questions.AddRange(
       [
            new ParagraphQuestion
            {
                Id = Guid.NewGuid(),
                Title = "Please tell me about yourself in  less than 500 words",
                Type = QuestionType.Paragraph,
            },
            new DropdownQuestion
            {
                Id = Guid.NewGuid(),
                Title = "Please select the year of graduation from the list below",
                Type = QuestionType.Dropdown,
                Choices = new List<string>
                {
                    "2024",
                    "2025"
                }
            },
            new YesNoQuestion
            {
                Id = Guid.NewGuid(),
                Title = "Have you ever been rejected by the UK embassy?",
                Type = QuestionType.YesNo
            }
       ]);
        db.SaveChanges();
    }

    private static void AddApplicants(AppDbContext db)
    {
        var bogus = new Faker<ApplicantInfo>()
                            .RuleFor(g => g.Gender, f => f.PickRandom<Gender>())
                            .RuleFor(p => p.FirstName, (f, c) => f.Name.FirstName((Name.Gender?)c.Gender))
                            .RuleFor(p => p.LastName, f=> f.Name.LastName())
                            .RuleFor(p => p.Email, f=> f.Person.Email)
                            .RuleFor(p => p.PhoneNo, f => f.Person.Phone)
                            .RuleFor(p => p.Nationality, (f, c) => f.Address.Country())
                            .RuleFor(p => p.CurrentResidence, (f, c) => f.Address.Country())
                            .RuleFor(p => p.DateCreated, f => f.Date.Recent())
                            .RuleFor(p => p.DateModified, f => f.Date.Recent());
        var customers = bogus.Generate(50);
        db.Applicants.AddRange(customers);
        db.SaveChanges();
    }
}
