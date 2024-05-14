using Shared.Models.Applicant;

namespace Client.Interfaces.Applicant;

public interface IApplicantService
{
    Task<bool> AddApplicant(ApplicantInfo applicant);
    Task<bool> EditApplicant(ApplicantInfo applicant);
    Task<bool> DeleteApplicant(Guid id);
    Task<ApplicantInfo?> GetApplicant(Guid id);
    Task<ApplicantInfo[]?> GetApplicants();
}
