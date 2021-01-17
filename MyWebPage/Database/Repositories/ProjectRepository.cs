using MyWebPage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebPage.Models;
using MyWebPage.Repositories.Interfaces;
using System.Globalization;

namespace MyWebPage.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectsDatabaseContext _context;

        public ProjectRepository(ProjectsDatabaseContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<List<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: Projects/Details/5
        public async Task<Project> Details(String? name)
        {
            if (name == null)
            {
                return null;
            }

            Project project;
            var requestCulture = CultureInfo.CurrentCulture;
            var regionInfo = new RegionInfo(requestCulture.Name);
            if (regionInfo.TwoLetterISORegionName.Equals("PL")){
                project = await _context.Projects
                .FirstOrDefaultAsync(m => m.NamePL == name);
            }
            else
            {
                project = await _context.Projects
                .FirstOrDefaultAsync(m => m.NameENG == name);
            }
            if (project == null)
            {
                return null;
            }

            return project;
        }
    }
}
