using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Context;
using Shared.DTO.Questions;
using Shared.Models.Applicant;
using Shared.Models.Questions;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController(AppDbContext _context, ILogger<ApplicantsController> _logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
    {
        return await _context.Questions.ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Question?>> GetQuestion(Guid id)
    {
        return await _context.Questions.FindAsync(id);
    }
    
    [HttpGet("paragraph/{id}")]
    public async Task<ActionResult<ParagraphQuestion?>> GetParagraph(Guid id)
    {
        return await _context.ParagraphQuestions.FindAsync(id);
    }
    
    [HttpGet("yesno/{id}")]
    public async Task<ActionResult<YesNoQuestion?>> GetYesNoQuestion(Guid id)
    {
        return await _context.YesNoQuestions.FindAsync(id);
    }
    
    [HttpGet("dropdown/{id}")]
    public async Task<ActionResult<DropdownQuestion?>> GetDropdownQuestion(Guid id)
    {
        return await _context.DropdownQuestions.FindAsync(id);
    }
    
    [HttpGet("number/{id}")]
    public async Task<ActionResult<NumberQuestion?>> GetNumberQuestion(Guid id)
    {
        return await _context.NumberQuestions.FindAsync(id);
    }
    
    [HttpGet("date/{id}")]
    public async Task<ActionResult<DateQuestion?>> GetDateQuestion(Guid id)
    {
        return await _context.DateQuestions.FindAsync(id);
    }
    
    [HttpGet("multichoice/{id}")]
    public async Task<ActionResult<MultichoiceQuestion?>> GetMultichoiceQuestion(Guid id)
    {
        return await _context.MultichoiceQuestions.FindAsync(id);
    }


    [HttpPost]
    public async Task<ActionResult> PostQuestion(Question question)
    {
        try
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while saving question");
            return Problem(ex.Message);

        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutQuestion(Guid id, Question question)
    {
        if (id != question.Id)
        {
            return BadRequest();
        }
        _context.Entry(question).State = QuestionExists(id) ? EntityState.Modified : EntityState.Added;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!QuestionExists(id))
            {
                return NotFound();
            }
            else
            {
                _logger.LogError("Error while updating question");
            }
        }

        return NoContent();
    }
    
    [HttpPut("paragraphquestion/{id}")]
    public async Task<ActionResult> PutParagraphQuestion(Guid id, ParagraphQuestion question)
    {
        if (id != question.Id)
        {
            return BadRequest();
        }
        _context.Entry(question).State = QuestionExists(id) ? EntityState.Modified : EntityState.Added;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!QuestionExists(id))
            {
                return NotFound();
            }
            else
            {
                _logger.LogError("Error while updating question");
            }
        }

        return NoContent();
    }
    
    [HttpPut("datequestion/{id}")]
    public async Task<ActionResult> PutDateQuestion(Guid id, DateQuestion question)
    {
        if (id != question.Id)
        {
            return BadRequest();
        }
        _context.Entry(question).State = QuestionExists(id) ? EntityState.Modified : EntityState.Added;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!QuestionExists(id))
            {
                return NotFound();
            }
            else
            {
                _logger.LogError("Error while updating question");
            }
        }

        return NoContent();
    }
    [HttpPut("dropdownquestion/{id}")]
    public async Task<ActionResult> PutDateQuestion(Guid id, DropdownQuestion question)
    {
        if (id != question.Id)
        {
            return BadRequest();
        }
        _context.Entry(question).State = QuestionExists(id) ? EntityState.Modified : EntityState.Added;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!QuestionExists(id))
            {
                return NotFound();
            }
            else
            {
                _logger.LogError("Error while updating question");
            }
        }

        return NoContent();
    }
    [HttpPut("multichoicequestion/{id}")]
    public async Task<ActionResult> PutMultichoiceQuestion(Guid id, MultichoiceQuestion question)
    {
        if (id != question.Id)
        {
            return BadRequest();
        }
        _context.Entry(question).State = QuestionExists(id) ? EntityState.Modified : EntityState.Added;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!QuestionExists(id))
            {
                return NotFound();
            }
            else
            {
                _logger.LogError("Error while updating question");
            }
        }

        return NoContent();
    }
    
    [HttpPut("numberquestion/{id}")]
    public async Task<ActionResult> PutNumberQuestion(Guid id, NumberQuestion question)
    {
        if (id != question.Id)
        {
            return BadRequest();
        }

        _context.Entry(question).State = QuestionExists(id) ? EntityState.Modified : EntityState.Added;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!QuestionExists(id))
            {
                return NotFound();
            }
            else
            {
                _logger.LogError("Error while updating question");
            }
        }

        return NoContent();
    }
    
    [HttpPut("yesnoquestion/{id}")]
    public async Task<ActionResult> PutYesNoQuestion(Guid id, YesNoQuestion question)
    {
        if (id != question.Id)
        {
            return BadRequest();
        }
        _context.Entry(question).State = QuestionExists(id) ? EntityState.Modified : EntityState.Added;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!QuestionExists(id))
            {
                return NotFound();
            }
            else
            {
                _logger.LogError("Error while updating question");
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var record = await _context.Questions.FindAsync(id);
        if (record is null)
            return NotFound();

        _context.Questions.Remove(record);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool QuestionExists(Guid id)
    {
        var exist = _context.Questions?.Where(e => e.Id == id).ToArray();
        return exist!.Any();
    }


}
