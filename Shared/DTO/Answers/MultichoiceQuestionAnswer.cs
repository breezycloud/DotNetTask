using Shared.DTO.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Answers;

public class MultichoiceQuestionAnswer : MultichoiceQuestion
{
    public List<string>? Options { get; set; }
}
