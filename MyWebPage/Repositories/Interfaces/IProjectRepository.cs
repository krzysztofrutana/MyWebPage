using MyWebPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebPage.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();

        // GET: Projects/Details/5
        Task<Project> Details(String? name);
    }
}
