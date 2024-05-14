using Shared.Enums;
using Shared.Models.Questions;
using Shared.Models.QuestionAnswer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO.Answers;

namespace Shared.Models.Applicant
{
    public class ApplicantInfo
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set;}
        [EmailAddress(ErrorMessage = "Email address is required")]
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? Nationality { get; set; }
        public string? CurrentResidence { get; set; }       
        public string? IdNumber { get; set; }
        public DateTime? Dob { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
        public List<ParagraphQuestionAnswer>? ParagraphQuestionAnswers { get; set; } = new();
        public List<YesNoQuestionAnswer>? YesNoQuestionAnswers { get; set; } = new();
        public List<DateQuestionAnswer>? DateQuestionAnswers { get; set; } = new();
        public List<NumberQuestionAnswer>? NumberQuestionAnswers { get; set; } = new();
        public List<DropdownQuestionAnswer>? DropdownQuestionAnswers { get; set; } = new();
        public List<MultichoiceQuestionAnswer>? MultichoiceQuestionAnswers { get; set; } = new();

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
