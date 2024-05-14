using Shared.DTO.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Answers;

public class DropdownQuestionAnswer : DropdownQuestion
{
    public string? Option { get; set; }
    public string? Other { get; set; }
}
