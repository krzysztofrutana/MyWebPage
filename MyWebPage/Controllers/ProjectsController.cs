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
using MyWebPage.Services;

namespace MyWebPage.Controllers
{
    public class ProjectsController : Controller
    {
        private FileService _fileService;
        private ProjectRepository projectRepository;

        public ProjectsController(ProjectsDatabaseContext context, FileService fileService)
        {
            projectRepository = new ProjectRepository(context);
            _fileService = fileService;
        }

        [HttpGet]
        public PartialViewResult List()
        {
            var projects = projectRepository.GetAll();
            return PartialView(projects);
        }

        [HttpGet]
        [Route("download")]
        public IActionResult Get(String filePath)
        {
            return _fileService.GetFileAsStream(filePath) ?? (IActionResult)NotFound();
        }
    }
}
