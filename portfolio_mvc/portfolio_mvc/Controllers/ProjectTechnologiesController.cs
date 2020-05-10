using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using portfolio_mvc.Repositories;

namespace portfolio_mvc.Controllers
{
    public class ProjectTechnologiesController : Controller
    {
        private readonly PortfolioContext db;
        public ProjectTechnologiesController(PortfolioContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var result = db.TechnologyProjects
                .Include(tp => tp.Project)
                .Include(tp => tp.Technology);
            return View(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            ProjectTechnologiesVMRepo repo = new ProjectTechnologiesVMRepo(db);
            return View(repo.GetDetails(id));
        }
    }
}