using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(ProjectService projectService) : ControllerBase
    {
        private readonly ProjectService _projectService = projectService;

        [HttpPost]

        public async Task<IActionResult> Create(AddProjectFormData projectFormData)
        {
           if (!ModelState.IsValid)
                return BadRequest(projectFormData);

           var result = await _projectService.CreateProjectAsync(projectFormData);
           return result ? Ok() : BadRequest("Project creation failed");
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAllProjectsAsync(orderByDescending: true);
            return Ok(projects);
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> Get (string projectId)
        {
            var project = await _projectService.GetProjectByIdAsync(projectId);
            return project == null ? NotFound() : Ok(project); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateProjectFormData projectFormData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            projectFormData.Id = id;

            var result = await _projectService.UpdateProjectAsync(projectFormData);
            return result ? Ok() : NotFound("Project not found");
        }


        [HttpDelete ("{projectId}")]
        public async Task<IActionResult> Delete(string projectId)
        {
            if (string.IsNullOrEmpty(projectId))
                return BadRequest("Project ID cannot be null or empty");

            var result = await _projectService.DeleteProjectAsync(projectId);
            return result ? Ok() : NotFound("Project not found");

        }





    }
}
