using Shared.DTO.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Answers;

public class NumberQuestionAnswer : NumberQuestion
{
    [Required(ErrorMessage = "Field is required")]
    public int? Number { get; set; }
}
