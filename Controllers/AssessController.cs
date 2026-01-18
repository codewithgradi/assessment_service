using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AssessController : ControllerBase
{
  private readonly IAssessmentRepo _assessmentRepo;
  public AssessController(IAssessmentRepo assesRepo)
  {
    _assessmentRepo = assesRepo;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var assessments = await _assessmentRepo.GetAllAsync(query);
    if (assessments == null) return NotFound();
    return Ok(assessments);
  }

  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetOne([FromRoute] int id)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var assessment = await _assessmentRepo.GetOneAsync(id);
    if (assessment == null) return NotFound("Assessment does not exist.");
    return Ok(assessment);
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete([FromRoute] int id)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var assessment = await _assessmentRepo.DeleteAsync(id);
    if (assessment == null) return NotFound("Assessment Not found");
    return Ok(assessment);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateAssessmentDto assessmentDto)
  {
    if (await _assessmentRepo.AssessmentExists(assessmentDto.Id)) return BadRequest("Assessment Already exists");
    await _assessmentRepo.CreateAsync(assessmentDto);
    return CreatedAtAction(
      nameof(GetOne),
      new { id = assessmentDto.Id },
      assessmentDto
    );
  }
}