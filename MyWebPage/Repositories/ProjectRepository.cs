using MyWebPage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebPage.Models;
using MyWebPage.Repositories.Interfaces;

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

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.Name == name);
            if (project == null)
            {
                return null;
            }

            return project;
        }
    }
}
