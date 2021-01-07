using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebPage.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String LogoPath { get; set; }
        public String ShortDiscriptionPL { get; set; }
        public String ShortDiscriptionENG { get; set; }
        public String DiscriptionPL { get; set; }
        public String DiscriptionENG { get; set; }
        public String Technologies { get; set; }
        private String ImagesPathAsStrings { get; set; }
        [NotMapped]
        public List<String> ImagesPath
        {
            get { return ImagesPathAsStrings.Split('|').ToList(); }
            set
            {
                ImagesPathAsStrings = String.Join(",", value);
            }
        }


    }
}
