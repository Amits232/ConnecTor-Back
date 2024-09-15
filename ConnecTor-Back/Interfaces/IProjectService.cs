// IProjectService.cs
using ConnecTor_Back.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
    Task<ProjectDto> GetProjectByIdAsync(int projectId);
    Task<Project> CreateProjectAsync(Project project);
    Task UpdateProjectAsync(Project project);
    Task DeleteProjectAsync(int projectId);
}
