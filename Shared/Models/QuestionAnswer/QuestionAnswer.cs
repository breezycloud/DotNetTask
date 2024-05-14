using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.QuestionAnswer;

public class Answer
{    
    public Guid QuestionId { get; set; }
}
