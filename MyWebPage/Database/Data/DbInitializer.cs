using MyWebPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebPage.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProjectsDatabaseContext context)
        {
            context.Database.EnsureCreated();

            // Look for any project.
            if (context.Projects.Any())
            {
                return;   // DB has been seeded
            }

            var projects = new Project[]
            {
                new Project(){
                Name = "Program dyplomowy",
                LogoPath = "",
                ShortDiscriptionPL = "The program is based on selected features of the set, such as median, mode, kurtosis, skewness, quartiles, etc." +
                " Based on these features, the classifier proposes the best grouping method, distance calculation method and grouping method parameter.",
                DiscriptionPL = "Opis po polsku",
                DiscriptionENG = "Opis po angielsku",
                Technologies = "Technologie",
                ScreenshotPaths = new List<string>()
                {
                    "Pierwsze zdjęcie",
                    "Drugie zdjęcie"
                }
            },

            new Project(){
                Name = "OCR Read and Translate",
                LogoPath = "~/Content/Projects/OCR_read_and_translate/OCR_logo.png",
                ShortDiscriptionPL = "The program allows you to read text from graphic and PDF files. It is possible to read a specific photo / page, " +
                "all text or only selected photos / pages. Successively received text can be translated using Google Translator through the module available " +
                "in the application.",
                DiscriptionPL = "Opis po polsku",
                DiscriptionENG = "Opis po angielsku",
                Technologies = "Technologie",
                FilePath = "Files\\CV.docx",
                ScreenshotPaths = new List<string>()
                {
                    "~/Content/Projects/OCR_read_and_translate/Main-Window.jpg",
                     "~/Content/Projects/OCR_read_and_translate/Main-Window-PDF.jpg",
                      "~/Content/Projects/OCR_read_and_translate/Translation-Window.jpg"
                }
            },

            new Project(){
                Name = "Przypominajka",
                LogoPath = "~/Content/Projects/Przypominajka/przypominajka_logo.png",
                ShortDiscriptionPL = "My first android application and my first Java program. The application allows you to add events for a specific day of the month (if the 31st day of the month is specified, " +
                "the application automatically sets the last days of the month), cyclically every few days, weeks or months, or once on a selected date." +
                " The whole is displayed in the form of an original calendar with color markings of a given event (which is selected at the stage of adding an event).",
                DiscriptionPL = "Opis po polsku",
                DiscriptionENG = "Opis po angielsku",
                Technologies = "Technologie",
                ScreenshotPaths = new List<string>()
                {
                    "Pierwsze zdjęcie",
                    "Drugie zdjęcie"
                }
            },

            new Project(){
                Name = "Asystent wokalisty",
                LogoPath = "~/Content/Projects/Asystent_wokalisty/asystent_wokalisty_logo.png",
                ShortDiscriptionPL = "My second android app wrote in c# with use Xamarin.Forms. The application allows you to add songs and create songs playlist. " +
                "You can get text from tekstowo.pl to current songs (searching by title or artist name or both). From playlist view you can run presentation of songs " +
                "text by order in playlist. Text size is set to 20, but number of lines is calculated for device. You can use one devices as server to set text " +
                "presentation and changing pages and other devices in band can connect to server (server client socket solution) and text will automaticaly send to " +
                "clients. Any clients will see the same text in the same time like server device.",
                DiscriptionPL = "Opis po polsku",
                DiscriptionENG = "Opis po angielsku",
                Technologies = "Technologie",
                ScreenshotPaths = new List<string>()
                {
                    "Pierwsze zdjęcie",
                    "Drugie zdjęcie"
                }
            } };

            foreach (Project s in projects)
            {
                context.Projects.Add(s);
            }
            context.SaveChanges();
        }

    }
}
