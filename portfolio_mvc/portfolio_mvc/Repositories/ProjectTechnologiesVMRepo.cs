using Portfolio.Models;
using portfolio_mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio_mvc.Repositories
{
    public class ProjectTechnologiesVMRepo
    {
        private PortfolioContext db;

        private readonly PortfolioContext _context;
        public ProjectTechnologiesVMRepo(PortfolioContext db)
        {
            this.db = db;
        }

        public IEnumerable<ProjectTechnologiesVM> GetAll()
        {
            return db.Projects.Select(tp => new ProjectTechnologiesVM
            {
                Project = tp,
                Technologies = tp.TechnologyProjects.Select(t => t.Technology)
            });
        }

        public ProjectTechnologiesVM GetDetails(int id)
        {
            return GetAll().FirstOrDefault(tp => tp.Project.ProjectId == id);
        }

    }
}
