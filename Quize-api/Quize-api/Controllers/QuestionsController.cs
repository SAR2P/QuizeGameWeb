using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Quize_api.Models;

namespace Quize_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuizeDbContext _context;

        public QuestionsController(QuizeDbContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> Getquestions()
        {
            var random5Qns = await (_context.questions.Select(
                x => new
                {
                    Qnid = x.QnId,
                    QnInWords = x.QnInWords,
                    imageName = x.ImageName,
                    options = new string[] {x.option1,x.option2,x.option3,x.option4}
                }).OrderBy(y => Guid.NewGuid())
                .Take(5)
                ).ToListAsync();

            return Ok(random5Qns);
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.QnId)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

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
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Questions/GetAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("GetAnswers")]
        public async Task<ActionResult<Question>> retriveAnswers(int[] qnIds)
        {
            var answers = await (_context.questions.Where(x => qnIds.Contains(x.QnId))
                .Select(y => new
                {
                    Qnid = y.QnId,
                    QnInWords = y.QnInWords,
                    imageName = y.ImageName,
                    options = new string[] { y.option1, y.option2, y.option3, y.option4 },
                    Answer = y.Answre
                })).ToListAsync();

            return Ok(answers);
           
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return _context.questions.Any(e => e.QnId == id);
        }
    }
}
