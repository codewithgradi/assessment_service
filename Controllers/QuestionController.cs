
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
  private readonly IQuestionRepo _questionRepo;
  public QuestionController(IQuestionRepo questionRepo)
  {
    _questionRepo = questionRepo;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var questions = await _questionRepo.GetAllAsync(query);
    if (questions == null) return NotFound();
    return Ok(questions);
  }

  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetOne([FromRoute] int id)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var question = await _questionRepo.GetByIdAsync(id);
    if (question == null) return NotFound("Question does not exist.");
    return Ok(question);
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete([FromRoute] int id)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var question = await _questionRepo.DeleteAsync(id);
    if (question == null) return NotFound("Question Not found");
    return Ok(question);
  }
  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update([FromRoute] int id, UpdateQuestionDto updateQuestionDto)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var question = await _questionRepo.UpdateAsync(id, updateQuestionDto);
    if (question == null) return NotFound("Question Not found");
    return Ok(question);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateQuestionDto questionDto)
  {
    await _questionRepo.CreateAsync(questionDto);
    return CreatedAtAction(
      nameof(GetOne),
      new { id = questionDto.Id },
      questionDto
    );
  }
}