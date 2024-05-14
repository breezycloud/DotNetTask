using Shared.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Questions;

public class MultichoiceQuestion : Question
{
    public int Max { get; set; }
    public List<string>? Choices { get; set; }
}
