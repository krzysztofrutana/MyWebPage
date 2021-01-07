using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebPage.Data;
using MyWebPage.Models;
using MyWebPage.Repositories;

namespace MyWebPage.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectsDatabaseContext _context;
        private ProjectRepository projectRepository;

        public ProjectsController(ProjectsDatabaseContext context)
        {
            _context = context;
            projectRepository = new ProjectRepository(context);
        }

        [HttpGet]
        public PartialViewResult List()
        {
            var projects = projectRepository.GetAll();
            return PartialView(projects);
        }
    }
}
