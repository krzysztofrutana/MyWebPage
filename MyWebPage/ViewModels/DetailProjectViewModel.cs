using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebPage.Models
{
    public class DetailProjectViewModel
    {
        public DetailProjectViewModel(Project project, int carouselID)
        {
            Project = project;
            CarouselID = carouselID;
        }

        public Project Project { get; set; }
        public int CarouselID { get; set; }
    }
}
