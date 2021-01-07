using Microsoft.AspNetCore.Mvc;
using MyWebPage.Data;
using MyWebPage.Models;
using MyWebPage.Repositories;
using MyWebPage.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebPage.ViewComponents
{
    [ViewComponent(Name = "Detail")]
    public class DetailViewComponent : ViewComponent
    {
        public IProjectRepository projectRepository;

        public DetailViewComponent(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(Project project)
        {

            return View(project);
        }
    }
}
