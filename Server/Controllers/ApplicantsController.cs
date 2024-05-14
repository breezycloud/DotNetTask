using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Context;
using Shared.Models.Applicant;
using Shared.Models.Questions;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantsController(AppDbContext _context, ILogger<ApplicantsController> _logger) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicantInfo>>> GetQuestions()
    {
        return await _context.Applicants.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicantInfo?>> GetQuestion(Guid id)
    {
        return await _context.Applicants.FindAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult> PostApplicant(ApplicantInfo applicant)
    {
		try
		{
			await _context.Applicants.AddAsync(applicant);
			await _context.SaveChangesAsync();

			return Ok();
		}
		catch (Exception ex)
		{
			_logger.LogError("Error while saving applicant");
			return Problem(ex.Message);

        }		
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var record = await _context.Applicants.FindAsync(id);
        if (record is null)
            return NotFound();

        _context.Applicants.Remove(record);
        await _context.SaveChangesAsync();
        return NoContent();
    }


}
