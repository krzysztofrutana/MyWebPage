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
        [Column("NamePL")]
        public String NamePL { get; set; }
        [Column("NameENG")]
        public String NameENG { get; set; }
        [Column("LogoPath")]
        public String LogoPath { get; set; }
        [Column("ShortDiscriptionPL")]
        public String ShortDiscriptionPL { get; set; }
        [Column("ShortDiscriptionENG")]
        public String ShortDiscriptionENG { get; set; }
        [Column("DiscriptionPL")]
        public String DiscriptionPL { get; set; }
        [Column("DiscriptionENG")]
        public String DiscriptionENG { get; set; }
        [Column("Technologies")]
        public String Technologies { get; set; }
        [Column("License")]
        public String License { get; set; }
        [Column("SourceLink")]
        public String SourceLink { get; set; }
        [Column("Platform")]
        public String Platform { get; set; }
        [Column("FilePath")]
        public String FilePath { get; set; }
        [Column("Screenshot")]
        public String Screenshot { get; set; }
        [Column("ItsWebPage")]
        public Boolean ItsWebPage { get; set; }

        [NotMapped]
        public List<String> ScreenshotPaths
        {
            get
            {
                if (Screenshot != null) { 
                    return Screenshot.Split('|').ToList();
                }
                else
                {
                    return new List<string>();
                }
            }
            set
            {
                Screenshot = String.Join("|", value);
            }
        }


    }
}
