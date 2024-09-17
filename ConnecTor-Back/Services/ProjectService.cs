// ProjectService.cs
using ConnecTor_Back.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ConnecTor_Back.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ConnecTorDbContext _context;

        public ProjectService(ConnecTorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllProjectsDto>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Contractor)
                .Include(p => p.ProjectField)
                .Include(p => p.Region)
                .Include(p => p.Proposals)
                .Include(p => p.ProjectImages)
                .Select(p => new AllProjectsDto
                {
                    ProjectID = p.ProjectID,
                    ClientName = p.Client.FirstName + " " + p.Client.LastName,
                    ProjectName = p.ProjectName,
                    ProjectFieldName = p.ProjectField.ProjectFieldDescription,
                    OpeningDate = p.OpeningDate,
                    Deadline = p.Deadline,
                    ProjectDescription = p.ProjectDescription,
                    Region = p.Region.RegionDescription
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
                    ClientName =  p.Client.FirstName + " " + p.Client.LastName,
                    ProjectName = p.ProjectName,
                    ProjectFieldName =  p.ProjectField.ProjectFieldDescription,
                    OpeningDate = p.OpeningDate,
                    Deadline = p.Deadline,
                    ProjectDescription = p.ProjectDescription,
                    Region = p.Region.RegionDescription,
                    ContractorID = p.ContractorID != null? p.ContractorID: null,
                    ActualStartDate = p.ActualStartDate != null ? p.ActualStartDate : null,
                    ActualEndDate = p.ActualEndDate != null? p.ActualEndDate : null,
                    Client = p.Client != null ? new UserDto
                    {
                        UserID = p.Client.UserID,
                        FirstName = p.Client.FirstName,
                        LastName = p.Client.LastName,
                        UserType = p.Client.UserType.UserTypeDescription,
                        Region = p.Client.Region.RegionDescription,
                        UserImage = p.Client.UserImage,
                        Email = p.Client.Email,
                        Telephone = p.Client.Telephone
                    } : null,
                    Contractor = p.Contractor != null ? new UserDto
                    {
                        UserID = p.Contractor.UserID,
                        FirstName = p.Contractor.FirstName,
                        LastName = p.Contractor.LastName,
                        UserType = p.Contractor.UserType.UserTypeDescription,
                        Region = p.Contractor.Region.RegionDescription,
                        UserImage = p.Contractor.UserImage,
                        Email = p.Contractor.Email,
                        Telephone = p.Contractor.Telephone,
                        Profession = p.Contractor.Profession.ProfessionDescription,
                        LicenseCode = p.Contractor.BusinessLicenseCode
                    } : null,
                    ProjectQuantities = p.ProjectQuantities != null ? p.ProjectQuantities : null,
                    ConstructionPlans = p.ConstructionPlans != null ? p.ConstructionPlans : null,
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
