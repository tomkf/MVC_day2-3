using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Models;

namespace portfolio_mvc.ViewModels
{
    public class ProjectTechnologiesVM
    {
        public Project Project { get; set; }
        public IEnumerable<Technology> Technologies { get; set; }
    }
}
