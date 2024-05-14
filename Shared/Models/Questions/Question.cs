using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Questions;

public class Question
{
    public Guid Id { get; set; }  = Guid.NewGuid();
    public string? Title { get; set; }
    public QuestionType Type { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateModified { get; set; } = DateTime.UtcNow;
}
