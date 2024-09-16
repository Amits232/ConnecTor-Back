using ConnecTor_Back.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IMediator _mediator;

    public ProjectsController(IProjectService projectService, IMediator mediator)
    {
        _projectService = projectService;
        _mediator = mediator;
    }

    // Get the last X projects by user ID
    [HttpGet("last")]
    public async Task<IActionResult> GetLastProjectsById(int id, int amount)
    {
        var query = new GetLastProjectsByIdQuery(id, amount);
        var lastProjectsDto = await _mediator.Send(query);

        if (lastProjectsDto == null || lastProjectsDto.Count == 0)
        {
            return NotFound();
        }

        return Ok(lastProjectsDto);
    }

    [HttpGet("bids")]
    public async Task<IActionResult> GetLastBidsById(int id, int amount)
    {
        var query = new GetLastBidsByIdQuery(id, amount);
        var lastBidsDto = await _mediator.Send(query);

        if (lastBidsDto == null || lastBidsDto.Count == 0)
        {
            return NotFound();
        }

        return Ok(lastBidsDto);
    }

    // Get all projects
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        return Ok(projects);
    }

    // Get project by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProject(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    // Create a new project
    [HttpPost]
    public async Task<ActionResult<Project>> CreateProject(Project project)
    {
        var createdProject = await _projectService.CreateProjectAsync(project);
        return CreatedAtAction(nameof(GetProject), new { id = createdProject.ProjectID }, createdProject);
    }

    // Update an existing project
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(int id, Project project)
    {
        if (id != project.ProjectID)
        {
            return BadRequest();
        }

        await _projectService.UpdateProjectAsync(project);
        return NoContent();
    }

    // Delete a project
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        await _projectService.DeleteProjectAsync(id);
        return NoContent();
    }
}
