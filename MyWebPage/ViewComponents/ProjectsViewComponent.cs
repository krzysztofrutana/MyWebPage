using Microsoft.AspNetCore.Mvc;
using MyWebPage.Data;
using MyWebPage.Repositories;
using MyWebPage.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebPage.ViewComponents
{
    [ViewComponent(Name = "Projects")]
    public class ProjectsViewComponent : ViewComponent
    {
        public IProjectRepository projectRepository;

        public ProjectsViewComponent(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var projects = await projectRepository.GetAll();

            return View(projects);
        }
    }
}
