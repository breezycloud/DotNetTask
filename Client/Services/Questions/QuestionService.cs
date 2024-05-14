using Client.Interfaces.Questions;
using Shared.DTO.Questions;
using Shared.Models.Questions;
using System.Net.Http.Json;

namespace Client.Services.Questions;

public class QuestionService(IHttpClientFactory _httpClient, ILogger<QuestionService> _logger) : IQuestionService
{
    public async Task<bool> AddOrEdiParagraphQuestion(ParagraphQuestion question)
    {
        try
        {
            var response = await _httpClient.CreateClient("AppUrl").PutAsJsonAsync($"api/questions/paragraphquestion/{question.Id}", question);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return false;
    }

    public async Task<bool> AddOrEditDateQuestion(DateQuestion question)
    {
        try
        {
            var response = await _httpClient.CreateClient("AppUrl").PutAsJsonAsync($"api/questions/datequestion/{question.Id}", question);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return false;
    }

    public async Task<bool> AddOrEditDropdownQuestion(DropdownQuestion question)
    {
        try
        {
            var response = await _httpClient.CreateClient("AppUrl").PutAsJsonAsync($"api/questions/dropdownquestion/{question.Id}", question);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return false;
    }

    public async Task<bool> AddOrEditMultichoicQuestion(MultichoiceQuestion question)
    {
        try
        {
            var response = await _httpClient.CreateClient("AppUrl").PutAsJsonAsync($"api/questions/multichoicequestion/{question.Id}", question);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return false;
    }

    public async Task<bool> AddOrEditNumberQuestion(NumberQuestion question)
    {
        try
        {
            var response = await _httpClient.CreateClient("AppUrl").PutAsJsonAsync($"api/questions/numberquestion/{question.Id}", question);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return false;
    }

    public async Task<bool> AddOrEditYesNoQuestion(YesNoQuestion question)
    {
        try
        {
            var response = await _httpClient.CreateClient("AppUrl").PutAsJsonAsync($"api/questions/yesnoquestion/{question.Id}", question);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return false;
    }

    public async Task<bool> AddQuestion(Question question)
    {
        try
        {
            var response = await _httpClient.CreateClient("AppUrl").PostAsJsonAsync("api/questions", question);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return false;
    }

    public async Task<bool> DeleteQuestion(Guid id)
    {
        try
        {
            var response = await _httpClient.CreateClient("AppUrl").DeleteAsync($"api/questions/{id}");
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return false;
    }

    public async Task<bool> EditQuestion(Question question)
    {
        try
        {
            var response = await _httpClient.CreateClient("AppUrl").PutAsJsonAsync($"api/questions/{question.Id}", question);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return false;
    }

    public async Task<DateQuestion?> GetDateQuestion(Guid id)
    {
        DateQuestion? question = null;
        try
        {
            question = await _httpClient.CreateClient("AppUrl").GetFromJsonAsync<DateQuestion?>($"api/questions/date/{id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return question;
    }

    public async Task<DropdownQuestion?> GetDropdownQuestion(Guid id)
    {
        DropdownQuestion? question = null;
        try
        {
            question = await _httpClient.CreateClient("AppUrl").GetFromJsonAsync<DropdownQuestion?>($"api/questions/dropdown/{id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return question;
    }

    public async Task<MultichoiceQuestion?> GetMultichoiceQuestion(Guid id)
    {
        MultichoiceQuestion? question = null;
        try
        {
            question = await _httpClient.CreateClient("AppUrl").GetFromJsonAsync<MultichoiceQuestion?>($"api/questions/multichoice/{id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return question;
    }

    public async Task<NumberQuestion?> GetNumberQuestion(Guid id)
    {
        NumberQuestion? question = null;
        try
        {
            question = await _httpClient.CreateClient("AppUrl").GetFromJsonAsync<NumberQuestion?>($"api/questions/number/{id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return question;
    }

    public async Task<ParagraphQuestion?> GetParagraphQuestion(Guid id)
    {
        ParagraphQuestion? question = null;
        try
        {
            question = await _httpClient.CreateClient("AppUrl").GetFromJsonAsync<ParagraphQuestion?>($"api/questions/paragraph/{id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return question;
    }

    public async Task<Question?> GetQuestion(Guid id)
    {
        Question? question = null;
        try
        {
            question = await _httpClient.CreateClient("AppUrl").GetFromJsonAsync<Question?>($"api/questions/{id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return question;
    }

    public async Task<Question[]?> GetQuestions()
    {
        Question[]? questions = null;
        try
        {
            questions = await _httpClient.CreateClient("AppUrl").GetFromJsonAsync<Question[]?>($"api/questions");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return questions;
    }

    public async Task<YesNoQuestion?> GetYesNoQuestion(Guid id)
    {
        YesNoQuestion? question = null;
        try
        {
            question = await _httpClient.CreateClient("AppUrl").GetFromJsonAsync<YesNoQuestion?>($"api/questions/yesno/{id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return question;
    }
}
