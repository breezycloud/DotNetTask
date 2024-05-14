using Shared.DTO.Questions;
using Shared.Models.Questions;


namespace Client.Interfaces.Questions;

public interface IQuestionService
{
    Task<bool> AddQuestion(Question question);
    Task<bool> AddOrEdiParagraphQuestion(ParagraphQuestion question);
    Task<bool> AddOrEditYesNoQuestion(YesNoQuestion question);
    Task<bool> AddOrEditDropdownQuestion(DropdownQuestion question);
    Task<bool> AddOrEditMultichoicQuestion(MultichoiceQuestion question);
    Task<bool> AddOrEditNumberQuestion(NumberQuestion question);
    Task<bool> AddOrEditDateQuestion(DateQuestion question);
    Task<bool> EditQuestion(Question question);
    Task<bool> DeleteQuestion(Guid id);
    Task<Question?> GetQuestion(Guid id);
    Task<ParagraphQuestion?> GetParagraphQuestion(Guid id);
    Task<DropdownQuestion?> GetDropdownQuestion(Guid id);
    Task<NumberQuestion?> GetNumberQuestion(Guid id);
    Task<MultichoiceQuestion?> GetMultichoiceQuestion(Guid id);
    Task<DateQuestion?> GetDateQuestion(Guid id);
    Task<YesNoQuestion?> GetYesNoQuestion(Guid id);
    Task<Question[]?> GetQuestions();
}
