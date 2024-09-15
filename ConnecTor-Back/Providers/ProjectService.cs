// ProjectService.cs
using ConnecTor_Back.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ConnecTor_Back.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly ConnecTorDbContext _context;

        public ProjectService(ConnecTorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Contractor)
                .Include(p => p.ProjectField)
                .Include(p => p.Region)
                .Include(p => p.Proposals)
                .Include(p => p.ProjectImages)
                .Select(p => new ProjectDto
                {
                    ProjectID = p.ProjectID,
                    ClientID = p.ClientID,
                    ProjectName = p.ProjectName,
                    ProjectFieldID = p.ProjectFieldID,
                    OpeningDate = p.OpeningDate,
                    Deadline = p.Deadline,
                    ProjectDescription = p.ProjectDescription,
                    RegionID = p.RegionID,
                    ProjectQuantities = p.ProjectQuantities ?? Array.Empty<byte>(), 
                    ConstructionPlans = p.ConstructionPlans ?? Array.Empty<byte>(), 
                    ContractorID = p.ContractorID,
                    ActualStartDate = p.ActualStartDate,
                    ActualEndDate = p.ActualEndDate,
                    ActualPayment = p.ActualPayment,
                    ClientReview = p.ClientReview ?? string.Empty, 
                    ContractorReview = p.ContractorReview ?? string.Empty, 
                    RegionName = p.Region != null ? p.Region.RegionDescription : string.Empty, 
                    ProjectFieldName = p.ProjectField != null ? p.ProjectField.ProjectFieldDescription : string.Empty, 
                    Client = p.Client != null ? new UserDto
                    {
                        UserID = p.Client.UserID,
                        FirstName = p.Client.FirstName,
                        LastName = p.Client.LastName
                    } : null,
                    Contractor = p.Contractor != null ? new UserDto
                    {
                        UserID = p.Contractor.UserID,
                        FirstName = p.Contractor.FirstName,
                        LastName = p.Contractor.LastName
                    } : null,
                    Proposals = p.Proposals ?? new List<ProjectProposal>(), 
                    ProjectImages = p.ProjectImages ?? new List<ProjectImage>() 
                })
                .ToListAsync();
        }





        public async Task<ProjectDto> GetProjectByIdAsync(int projectId)
        {
            return await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Contractor)
                .Include(p => p.ProjectField)
                .Include(p => p.Region)
                .Include(p => p.Proposals)
                .Include(p => p.ProjectImages)
                .Where(p => p.ProjectID == projectId)
                .Select(p => new ProjectDto
                {
                    ProjectID = p.ProjectID,
                    ClientID = p.ClientID,
                    ProjectName = p.ProjectName,
                    ProjectFieldID = p.ProjectFieldID,
                    OpeningDate = p.OpeningDate,
                    Deadline = p.Deadline,
                    ProjectDescription = p.ProjectDescription,
                    RegionID = p.RegionID,
                    ProjectQuantities = p.ProjectQuantities ?? Array.Empty<byte>(), 
                    ConstructionPlans = p.ConstructionPlans ?? Array.Empty<byte>(), 
                    ContractorID = p.ContractorID,
                    ActualStartDate = p.ActualStartDate,
                    ActualEndDate = p.ActualEndDate,
                    ActualPayment = p.ActualPayment,
                    ClientReview = p.ClientReview ?? string.Empty, 
                    ContractorReview = p.ContractorReview ?? string.Empty, 
                    RegionName = p.Region != null ? p.Region.RegionDescription : string.Empty, 
                    ProjectFieldName = p.ProjectField != null ? p.ProjectField.ProjectFieldDescription : string.Empty, 
                    Client = p.Client != null ? new UserDto
                    {
                        UserID = p.Client.UserID,
                        FirstName = p.Client.FirstName,
                        LastName = p.Client.LastName
                    } : null,
                    Contractor = p.Contractor != null ? new UserDto
                    {
                        UserID = p.Contractor.UserID,
                        FirstName = p.Contractor.FirstName,
                        LastName = p.Contractor.LastName
                    } : null,
                    Proposals = p.Proposals ?? new List<ProjectProposal>(),
                    ProjectImages = p.ProjectImages ?? new List<ProjectImage>() 
                })
                .FirstOrDefaultAsync();
        }


        public async Task<Project> CreateProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}
