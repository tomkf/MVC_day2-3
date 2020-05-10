using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio_mvc.ViewModels
{
    public class InterviewRequestVM
    {
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public int Id { get; set; }
    }
}