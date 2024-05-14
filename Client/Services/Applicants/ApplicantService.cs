using Client.Interfaces.Applicant;
using Shared.Models.Applicant;
using System.Net.Http.Json;

namespace Client.Services.Applicants;

public class ApplicantService(IHttpClientFactory _httpClient, ILogger<ApplicantService> _logger) : IApplicantService
{
    public async Task<bool> AddApplicant(ApplicantInfo applicant)
    {
        try
        {
            var response = await _httpClient.CreateClient("AppUrl").PostAsJsonAsync("api/applicants", applicant);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return false;
    }

    public async Task<bool> DeleteApplicant(Guid id)
    {
        try
        {
            var response = await _httpClient.CreateClient("AppUrl").DeleteAsync($"api/applicants/{id}");
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return false;
    }

    public async Task<bool> EditApplicant(ApplicantInfo applicant)
    {
        try
        {
            var response = await _httpClient.CreateClient("AppUrl").PostAsJsonAsync($"api/applicants/{applicant.Id}", applicant);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return false;
    }

    public async Task<ApplicantInfo?> GetApplicant(Guid id)
    {
        ApplicantInfo? applicant = null;
        try
        {
            applicant = await _httpClient.CreateClient("AppUrl").GetFromJsonAsync<ApplicantInfo?>($"api/applicants/{id}");            
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return applicant;
    }

    public async Task<ApplicantInfo[]?> GetApplicants()
    {
        ApplicantInfo[]? applicants = null;
        try
        {
            applicants = await _httpClient.CreateClient("AppUrl").GetFromJsonAsync<ApplicantInfo[]?>($"api/applicants");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return applicants;
    }
}
