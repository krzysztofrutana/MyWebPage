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
                NamePL = "Program dyplomowy",
                NameENG = "Diploma program",
                LogoPath =  "~/Content/Projects/Diploma/Thumbnail/miniatura.png",
                ShortDiscriptionPL = "Pro&shy;gram opie&shy;ra się o wy&shy;bór wy&shy;bra&shy;nych cech zbio&shy;ru ta&shy;kich jak: me&shy;dia&shy;na, mo&shy;da, ku&shy;rio&shy;za, sko&shy;śność, kwa&shy;rty&shy;le itp. " +
                "Na pod&shy;sta&shy;wie tych cech kla&shy;sy&shy;fi&shy;ka&shy;tor pro&shy;po&shy;nu&shy;je naj&shy;le&shy;pszą me&shy;to&shy;dę gru&shy;po&shy;wa&shy;nia, me&shy;to&shy;de li&shy;cze&shy;nia odle&shy;gło&shy;ści oraz pa&shy;ra&shy;metr me&shy;to&shy;dy gru&shy;po&shy;wa&shy;nia spo&shy;śród " +
                "trzech me&shy;tod: ite&shy;ra&shy;cyj&shy;nej (KMeans), aglo&shy;me&shy;ra&shy;cyj&shy;nej (Agglomerative) oraz gę&shy;sto&shy;ścio&shy;wej (DBScan).",
                ShortDiscriptionENG = "The program is based on selected features of the set, such as median, mode, kurtosis, skewness, quartiles, etc." +
                " Based on these features, the classifier proposes the best grouping method, distance calculation method and grouping method parameter " +
                "among the three methods: iterative (KMeans), algomerative (Agglomerative) and density (DBScan).",
                DiscriptionPL = "<h4>Okno główne</h4>" +
                "<p>Okno głó&shy;wne poz&shy;wa&shy;la wy&shy;brać zbiór da&shy;nych (for&shy;mat .tab, .csv lub .txt) z zaz&shy;na&shy;cze&shy;niem czy dany zbiór po&shy;sia&shy;da wiersz z na&shy;głów&shy;ka&shy;mi ko&shy;lumn. " +
                "Na&shy;stę&shy;pnie po&shy;zwa&shy;la usu&shy;nąc pu&shy;ste lub nie&shy;po&shy;trze&shy;bne ko&shy;lu&shy;mny. Przed obli&shy;cze&shy;nia&shy;mi cech za&shy;le&shy;ca&shy;ne jest okre&shy;śle&shy;nie atry&shy;bu&shy;tu de&shy;cy&shy;zy&shy;jne&shy;go i in&shy;de&shy;ksu&shy;ją&shy;ce&shy;go je&shy;że&shy;li ta&shy;ki istnie&shy;je. " +
                "Ma to wpływ na war&shy;to&shy;ści obli&shy;cza&shy;nych cech. Ko&shy;lej&shy;no kla&shy;sy&shy;fi&shy;ka&shy;tor (wcze&shy;śniej na&shy;u&shy;czo&shy;ny na pod&shy;sta&shy;wie ta&shy;be&shy;li tre&shy;nin&shy;go&shy;wej) mo&shy;że zo&shy;stać uży&shy;ty do okre&shy;śle&shy;nia " +
                "naj&shy;le&shy;pszej me&shy;to&shy;dy gru&shy;po&shy;wa&shy;nia, me&shy;to&shy;dy li&shy;cze&shy;nia odle&shy;gło&shy;ści oraz pa&shy;ra&shy;me&shy;tru me&shy;to&shy;dy gru&shy;po&shy;wa&shy;nia. Otrzy&shy;ma&shy;ny re&shy;zu&shy;ltat moż&shy;na po&shy;rów&shy;nać do tego otrzy&shy;ma&shy;ne&shy;go me&shy;to&shy;dą " +
                "bru&shy;tal&shy;nej si&shy;ły. Pro&shy;gram ko&shy;rzy&shy;sta z trzech me&shy;tod ok&shy;reś&shy;la&shy;ją&shy;cych ja&shy;kość gru&shy;po&shy;wa&shy;nia oraz ko&shy;rzys&shy;ta z trzech za&shy;sad&shy;ni&shy;czo róż&shy;nych me&shy;tod gru&shy;po&shy;wa&shy;nia (ite&shy;ra&shy;cyj&shy;na KMeans, " +
                "aglo&shy;me&shy;ra&shy;cyj&shy;na Agglomerative oraz gę&shy;sto&shy;ścio&shy;wa DBScan) oraz trzech me&shy;tod li&shy;cze&shy;nia odle&shy;gło&shy;ści (Eu&shy;kli&shy;de&shy;so&shy;wa, city&shy;block oraz ko&shy;si&shy;nu&shy;so&shy;wa).</p><p></p>" +
                "<h4>Okno edycji tabeli treningowej</h4>" +
                "<p>Tu&shy;taj moż&shy;li&shy;we jest obli&shy;cze&shy;nie cech zbio&shy;ru oraz okre&shy;śle&shy;nie naj&shy;le&shy;pszej me&shy;to&shy;dy gru&shy;po&shy;wa&shy;nia poprzez me&shy;to&shy;dę bru&shy;tal&shy;nej siły dla wy&shy;bra&shy;ne&shy;go zbio&shy;ru i do&shy;da&shy;nie otrzy&shy;ma&shy;nych wy&shy;ni&shy;ków do ta&shy;be&shy;li tre&shy;nin&shy;go&shy;wej. " +
                "Czym wię&shy;cej wy&shy;ni&shy;ków w ta&shy;be&shy;li tym pre&shy;dyk&shy;cja bę&shy;dzie lep&shy;sza.</p><p></p>" +
                "<h4>Klasyfikator</h4>" +
                "<p>Okno usta&shy;wień kla&shy;sy&shy;fi&shy;ka&shy;to&shy;ra umo&shy;żli&shy;wia zmia&shy;nę jego pa&shy;ra&shy;me&shy;trów. Te mo&shy;gą być te&shy;sto&shy;wa&shy;ne w ok&shy;nie te&shy;stów LeaveOut lub zna&shy;le&shy;zio&shy;ne me&shy;to&shy;dą GridSearchCV z wy&shy;bra&shy;ne&shy;go za&shy;kre&shy;su pa&shy;ra&shy;me&shy;trów w oknie " +
                "te&shy;stów pa&shy;ra&shy;me&shy;trów kla&shy;sy&shy;fi&shy;ka&shy;to&shy;ra.</p>",
                DiscriptionENG = "<h4>Main window</h4>" +
                "<p>The main window allows you to select a data set (.tab, .csv, .txt format) with an indication of whether a given set has a row with column headers. " +
                "Then you can delete empty or unnecessary columns. Before calculating the features, it is also recommended to select the decision attribute and " +
                "the indexing attribute, if any. Then, after receiving the features, the learned classifier can be used to determine the best grouping method, " +
                "distance calculation method, and grouping method parameter. The result can be compared with the result of searching for these parameters using the Brute Force method. " +
                "The program includes three clustering quality measures (the results for each are significantly different) and includes three clustering methods " +
                "(KMeans iterative, agglomerative Agglomerative and DBScan density method) and three distance calculation methods (Euclidean, cityblock and cosine).</p> <p></p>" +
                "<h4>Training table editing window</h4>" +
                "<p>This window allows you to calculate the features and best method grouping method by BruteForce method of the selected set and add the results to the classifier training table. " +
                "The more results in the table, the better the prediction.</p> <p></p>" +
                "<h4>Classifier</h4>" +
                "<p>Classifier settings window allows you to change the classifier parameters. Choosen parametrs can be test in LeaveOut tests window or you can find the best classifier " +
                "parameters for defined ranges of parameters by the GridSearchCV method in test classifier parametr window.</p>",
                Technologies = "Python, Pyside2(QT5), Scikit-learn",
                License = "GNU GPL",
                SourceLink = "https://github.com/krzysztofrutana/Diploma-program",
                Platform = "Windows",
                FilePath = "",
                ScreenshotPaths = new List<string>()
                {
                    "~/Content/Projects/Diploma/Screenshots/1.jpg",
                    "~/Content/Projects/Diploma/Screenshots/2.jpg",
                    "~/Content/Projects/Diploma/Screenshots/3.jpg",
                    "~/Content/Projects/Diploma/Screenshots/4.jpg",
                    "~/Content/Projects/Diploma/Screenshots/5.jpg"
                }
            },

            new Project(){
                NamePL = "OCR Read and Translate",
                NameENG = "OCR Read and Translate",
                LogoPath = "~/Content/Projects/OCR_read_and_translate/Thumbnail/OCR_miniatura.png",
                ShortDiscriptionPL = "Pro&shy;gram umo&shy;żli&shy;wia od&shy;czy&shy;ta&shy;nie tek&shy;stu z gra&shy;fik, zdjęć oraz pli&shy;ków PDF. Umo&shy;żli&shy;wia od&shy;czyt z kon&shy;kre&shy;tne&shy;go pli&shy;ku/stro&shy;ny do&shy;ku&shy;men&shy;tu lub " +
                "ca&shy;ły tekst z wszy&shy;stkich wy&shy;bra&shy;nych pli&shy;ków/stron. Osta&shy;te&shy;cznie otrzy&shy;ma&shy;ny tekst może być prze&shy;tłu&shy;ma&shy;czo&shy;ny dzięki za&shy;im&shy;ple&shy;men&shy;to&shy;wa&shy;niu ob&shy;słu&shy;gi Google Tran&shy;sla&shy;tor w apli&shy;ka&shy;cji.",
                ShortDiscriptionENG = "The program allows you to read text from graphic and PDF files. It is possible to read a specific photo / page, " +
                "all text or only selected photos / pages. Successively received text can be translated using Google Translator through the module available " +
                "in the application.",
                DiscriptionPL = "<h4>Okno główne</h4>" +
                "<p>Umo&shy;żli&shy;wia wczy&shy;ta&shy;nie i odczyt tek&shy;stu ze zdjęć oraz pli&shy;ku PDF (oso&shy;bna za&shy;kła&shy;dka). Umo&shy;żli&shy;wia rów&shy;nież od&shy;czyt tek&shy;stu na pod&shy;sta&shy;wie stwo&shy;rzo&shy;nej wcześ&shy;niej ko&shy;lej&shy;ki zdjęć/stron. " +
                "Osta&shy;te&shy;cznie re&shy;zul&shy;tat może być sko&shy;pio&shy;wa&shy;ny bądź za&shy;pi&shy;sa&shy;ny do pli&shy;ku PDF lub txt.</p><p></p>" +
                "<h4>Okno translatora</h4>" +
                "<p>Umo&shy;żli&shy;wia wy&shy;bór ję&shy;zy&shy;ka spoś&shy;ród wszy&shy;stkich do&shy;stę&shy;pnych w ser&shy;wi&shy;sie Google Tłu&shy;macz. Pro&shy;gram au&shy;to&shy;ma&shy;ty&shy;cznie roz&shy;po&shy;zna&shy;je ję&shy;zyk te&shy;kstu źró&shy;dło&shy;we&shy;go. Tłu&shy;ma&shy;cze&shy;nie moż&shy;na za&shy;pi&shy;sać w for&shy;mie " +
                "dwóch ko&shy;lumn (tek&shy;stu źró&shy;dło&shy;we&shy;go oraz prze&shy;tłu&shy;ma&shy;czo&shy;ne&shy;go) lub tyl&shy;ko tłu&shy;ma&shy;cze&shy;nie w pli&shy;ku PDF lub txt. Dłu&shy;gość tek&shy;stu, któ&shy;ry moż&shy;na prze&shy;tłu&shy;ma&shy;czyć jest ogra&shy;ni&shy;czo&shy;na przez Goo&shy;gle Trans&shy;la&shy;tor. Mo&shy;żli&shy;we jest równ&shy;ież tłu&shy;ma&shy;cze&shy;nie " +
                "tyl&shy;ko za&shy;zna&shy;czo&shy;ne&shy;go tek&shy;stu.</p>",
                DiscriptionENG = "<h4>Main window</h4>" +
                "<p>Allows you to load and read text from photos and PDF files (second screenshot). It is also possible to arrange a queue (e.g. selected graphics or pages in a document). " +
                "Next you can save copy or save result to PDF or txt.</p><p></p>" +
                "<h4>Translator window</h4>" +
                "<p>The text translation window allows you to choose between the languages ​​available in the google translate service. The detect language option allows you to use google translator to " +
                "determine the original language. Additionally, you can save the results in the form of two columns, in one the original text and the other translated. The length of the translated " +
                "text is limited by google translator. It is possible to translate the selected text.</p>",
                Technologies = "Technologie",
                License = "GNU GPL",
                SourceLink = "https://github.com/krzysztofrutana/OCR-Desktop",
                Platform = "Windows",
                FilePath = "",
                ScreenshotPaths = new List<string>()
                {
                    "~/Content/Projects/OCR_read_and_translate/Screenshots/1.jpg",
                    "~/Content/Projects/OCR_read_and_translate/Screenshots/2.jpg",
                    "~/Content/Projects/OCR_read_and_translate/Screenshots/3.jpg"
                }
            },

            new Project(){
                NamePL = "Przypominajka",
                NameENG = "Reminder",
                LogoPath = "~/Content/Projects/Przypominajka/Thumbnail/przypominajka_miniatura.png",
                ShortDiscriptionPL = "Mój pier&shy;wszy pro&shy;gram na&shy;pi&shy;sa&shy;ny na pla&shy;tfo&shy;rmę An&shy;dro&shy;id oraz pier&shy;wszy w Ja&shy;vie. Ap&shy;li&shy;ka&shy;cja umo&shy;żli&shy;wia do&shy;da&shy;nie wy&shy;da&shy;rzeń w kon&shy;kre&shy;tne dni mie&shy;sią&shy;ca, wy&shy;da&shy;rzeń po&shy;wta&shy;rza&shy;nych o wy&shy;bra&shy;ną licz&shy;bę dni" +
                "/ty&shy;go&shy;dni/mie&shy;się&shy;cy lub je&shy;dno&shy;ra&shy;zo&shy;wych. Wszyst&shy;kie wy&shy;da&shy;rze&shy;nia wy&shy;świe&shy;tla&shy;ne są na au&shy;tor&shy;skim ka&shy;len&shy;da&shy;rzu z ko&shy;lo&shy;ro&shy;wy&shy;mi zna&shy;czni&shy;ka&shy;mi kon&shy;kre&shy;tnych wy&shy;da&shy;rzeń. Apli&shy;ka&shy;cja prze&shy;cho&shy;wu&shy;je in&shy;fo&shy;rma&shy;cję o zre&shy;ali&shy;zo&shy;wa&shy;nych " +
                "wy&shy;da&shy;rze&shy;niach i two&shy;rzy przy&shy;po&shy;mnie&shy;nie o zbli&shy;ża&shy;ja&shy;cym się wy&shy;da&shy;rze&shy;niu (o okre&shy;ślo&shy;nej przez użyt&shy;ko&shy;wni&shy;ka go&shy;dzi&shy;nie) oraz o nie&shy;zre&shy;ali&shy;zo&shy;wa&shy;nych wyda&shy;rze&shy;niach. Mo&shy;żli&shy;we jest rów&shy;nież stwo&shy;rze&shy;nie ko&shy;pii ba&shy;zy da&shy;nych " +
                "na te&shy;le&shy;fo&shy;nie lub Dy&shy;sku Google.",
                ShortDiscriptionENG = "My first android application and my first Java program. The application allows you to add events for a specific day of the month, cyclically every few days, weeks or months, " +
                "or once on a selected date. The whole is displayed in the form of an author's calendar with color markings of a given event (which is selected at the stage of adding an event)." +
                "The application stores information about completed events and creates a reminder about an upcoming event (at a time specified by the user) and about unrealized events.It is also possible to create a copy of the database.",
                DiscriptionPL = "<h4>Okno głowne</h4>" +
                "<p>Głów&shy;ne okno apli&shy;ka&shy;cji wy&shy;świe&shy;tla au&shy;tor&shy;ski ka&shy;len&shy;darz i li&shy;stę wy&shy;da&shy;rzeń na bie&shy;żą&shy;cy lub wy&shy;bra&shy;ny dzień. Po klik&shy;nię&shy;ciu na wy&shy;da&shy;rze&shy;nie wy&shy;świe&shy;tla&shy;ją się je&shy;go szcze&shy;gó&shy;ły. Je&shy;śli wy&shy;da&shy;rze&shy;nie wy&shy;pa&shy;da w da&shy;ny dzień na&shy;le&shy;ży ozna&shy;czyć wy&shy;ko&shy;na&shy;nie ta&shy;kie&shy;go wy&shy;da&shy;rze&shy;nia. W prze&shy;ciw&shy;nym wy&shy;pad&shy;ku apli&shy;ka&shy;cja przy&shy;po&shy;mni nam o nie&shy;zra&shy;li&shy;zo&shy;wa&shy;nych wy&shy;da&shy;rze&shy;niach z prze&shy;szło&shy;ści. </p><p></p>" +
                "<h4>Nawigacja</h4>" +
                "<p>Opie&shy;ra się o wy&shy;su&shy;wa&shy;ne z le&shy;wej stro&shy;ny me&shy;nu z od&shy;no&shy;śni&shy;ka&shy;mi do po&shy;szcze&shy;gól&shy;nych okien. </p><p></p>" +
                "<h4>Dodawanie nowego wydarzenia</h4>" +
                "<p>Pod&shy;czas two&shy;rze&shy;nia no&shy;we&shy;go wy&shy;da&shy;rze&shy;nia wy&shy;ma&shy;ga&shy;ne jest wpro&shy;wa&shy;dze&shy;nie je&shy;go uni&shy;kal&shy;nej na&shy;zwy oraz wy&shy;bra&shy;nie ko&shy;lo&shy;ru (k&shy;tó&shy;ry bę&shy;dzie wi&shy;docz&shy;ny w ka&shy;len&shy;da&shy;rzu oraz na li&shy;ście wy&shy;da&shy;rze&shy;ń). Opis jest opcjo&shy;nal&shy;ny. Wy&shy;da&shy;rze&shy;nie mo&shy;że być cy&shy;klicz&shy;ne w wy&shy;bra&shy;ny dzień mie&shy;sią&shy;ca przez wy&shy;bra&shy;ną licz&shy;bę mie&shy;się&shy;cy (przy&shy;dat&shy;ne np. przy pła&shy;ce&shy;niu ra&shy;chun&shy;kó&shy;w) lub co wy&shy;bra&shy;ną licz&shy;bę dni/ty&shy;go&shy;dni/mie&shy;się&shy;cy wy&shy;bra&shy;ną licz&shy;bę ra&shy;zy (przy&shy;dat&shy;ne w przy&shy;pad&shy;ku np. przyj&shy;mo&shy;wa&shy;nia le&shy;kó&shy;w). Ostat&shy;nią opcją jest wy&shy;da&shy;rze&shy;nie jed&shy;no&shy;ra&shy;zo&shy;we w wy&shy;bra&shy;ny dzień. Osta&shy;tecz&shy;nie po&shy;da&shy;ję sie da&shy;tę roz&shy;po&shy;czę&shy;cia wy&shy;da&shy;rze&shy;nia. Dla każ&shy;de&shy;go ty&shy;pu moż&shy;li&shy;we jest rów&shy;nież usta&shy;wie&shy;nie go&shy;dzi&shy;ny po&shy;wia&shy;do&shy;mie&shy;nia, mo&shy;że być ona wy&shy;bra&shy;na przez użyt&shy;kow&shy;ni&shy;ka lub do&shy;myśl&shy;na (zmie&shy;nia&shy;na w usta&shy;wie&shy;nia&shy;ch). </p><p></p>" +
                "<h4>Lista wydarzeń oraz szczegóły</h4>" +
                "<p>Li&shy;sta wy&shy;da&shy;rzeń wy&shy;świe&shy;tla wszyst&shy;kie stwo&shy;rzo&shy;ne kie&shy;dy&shy;kol&shy;wiek i nie usu&shy;nię&shy;te wy&shy;da&shy;rze&shy;nia. Po klik&shy;nię&shy;ciu na wy&shy;bra&shy;ne wy&shy;świe&shy;tla się okno z je&shy;go szcze&shy;gó&shy;ła&shy;mi. W tym miej&shy;scu moż&shy;li&shy;wa jest rów&shy;nież zmia&shy;na ko&shy;lo&shy;ru wy&shy;da&shy;rze&shy;nia, go&shy;dzi&shy;ny przy&shy;po&shy;mnie&shy;nia, prze&shy;nieść na&shy;stęp&shy;ne przy&shy;po&shy;mnie&shy;nie na wy&shy;bra&shy;ny dzień oraz za&shy;koń&shy;cze&shy;nie wy&shy;da&shy;rze&shy;nia bez usu&shy;wa&shy;nia in&shy;for&shy;ma&shy;cji o nim (w&shy;cze&shy;śniej&shy;sze da&shy;ty bę&shy;dą wy&shy;świe&shy;tla&shy;ne w ka&shy;len&shy;da&shy;rzu&shy;).</p><p></p>" +
                "<h4>Ustawienia</h4>" +
                "<p>Ok&shy;no usta&shy;wień umoż&shy;li&shy;wia zmia&shy;nę do&shy;myśl&shy;nej go&shy;dzi&shy;ny przy&shy;po&shy;mnie&shy;nia i in&shy;ter&shy;wa&shy;łu cza&shy;so&shy;we&shy;go mię&shy;dzy two&shy;rze&shy;niem no&shy;wych po&shy;wia&shy;do&shy;mień dla no&shy;wo do&shy;da&shy;nych wy&shy;da&shy;rzeń. Na&shy;stęp&shy;nie wy&shy;su&shy;wa&shy;ne me&shy;nu umoż&shy;li&shy;wia&shy;ją stwo&shy;rze&shy;nie lo&shy;kal&shy;nej ko&shy;pii za&shy;pa&shy;so&shy;wej ba&shy;zy da&shy;nych lub za&shy;pi&shy;sy&shy;wa&shy;nej na dys&shy;ku Go&shy;ogle użyt&shy;kow&shy;ni&shy;ka oraz przy&shy;wró&shy;ce&shy;nie stwo&shy;rzo&shy;nej ko&shy;pii.</p><p></p>" +
                "<h4>Niezrealizowane wydarzenia</h4>" +
                "<p>Po uru&shy;cho&shy;mie&shy;niu apli&shy;ka&shy;cja ta szu&shy;ka wszyst&shy;kich nie&shy;ozna&shy;czo&shy;nych ja&shy;ko wy&shy;ko&shy;na&shy;ne wy&shy;da&shy;rzeń w prze&shy;szło&shy;ści. Je&shy;śli ta&shy;ko&shy;we znaj&shy;dzie wy&shy;świe&shy;tla sto&shy;sow&shy;ny ko&shy;mu&shy;ni&shy;ka&shy;t, gdzie moż&shy;li&shy;we jest zi&shy;gno&shy;ro&shy;wa&shy;nie ko&shy;mu&shy;ni&shy;ka&shy;tu, opcja przy&shy;po&shy;mnij póź&shy;niej lub ozna&shy;cze&shy;nie wszyst&shy;kich po&shy;da&shy;nych wy&shy;da&shy;rzeń ja&shy;ko wy&shy;ko&shy;na&shy;ne. Op&shy;cja przy&shy;po&shy;mnij póź&shy;niej stwo&shy;rzy po&shy;wia&shy;do&shy;mie&shy;nie, któ&shy;re zo&shy;sta&shy;nie wy&shy;świe&shy;tlo&shy;ne za 2 go&shy;dzi&shy;ny od mo&shy;men&shy;tu klik&shy;nię&shy;cia opcji. </p>",

                DiscriptionENG = "<h4>Main window</h4>" +
                "<p>The main window displays the author's calendar and a list of events for a specific day or by clicking on a date for a selected day. When you click on an event, detailed information about it " +
                "is displayed. In the events occurring on the current day, it should be indicated whether they were done. Otherwise, notifications about events not done will be created in the future.</p><p></p>" +
                "<h4>Navigation</h4>" +
                "<p>Navigation in the application is based on the slide-out menu on the left and the navigation buttons on the toolbar.</p><p></p>" +
                "<h4>Adding new event</h4>" +
                "<p>When adding a new event, it is required to enter its name and color (it is displayed in the calendar view). Description is optional. An event may be cyclical on a given day of the month for a " +
                "given number of months (e.g. useful when paying bills). It can also be cyclical every few days / weeks / months (to choose from) and apply all the time or repeat only a specified number of times" +
                " (useful in the case of activities, e.g. performed every two days or e.g. taking medications). It is also possible to schedule a one-time event. Finally, the start date of the event is given. " +
                "For each type of event, the time is also set, it can be default (changed in the settings) or selected by the user.</p><p></p>" +
                "<h4>Events List and detail</h4>" +
                "<p>The list of events window allows you to view all saved events. After clicking on the selected event, it is possible to view its details and delete the selected event. In detail window, you can " +
                "also change the color of the event, time, move the next reminder to a different date or end the event (it will remain visible in the calendar view).</p><p></p>" +
                "<h4>Settings</h4>" +
                "<p>The settings allow you to change the default notification time and the time interval for checking events and creating new notifications. This tab allows you to create a local backup on your phone or " +
                "Google Drive and restore it.</p><p></p>" +
                "<h4>Unperformed events</h4>" +
                "<p>After starting, the application looks for unfinished days for all events. When some days are not mark as finished, application shows alert dialog with information about all finded days for all " +
                "events with three options: to mark all days as finished, ignore information or remind me later.</p>",

                Technologies = "Java, Room Database, Joda Time Library",
                License = "Adware",
                SourceLink = "https://github.com/krzysztofrutana/Przypominajka",
                Platform = "Android",
                FilePath = "",
                ScreenshotPaths = new List<string>()
                {
                     "~/Content/Projects/Przypominajka/Screenshots/1.png",
                     "~/Content/Projects/Przypominajka/Screenshots/2.png",
                     "~/Content/Projects/Przypominajka/Screenshots/3.png",
                     "~/Content/Projects/Przypominajka/Screenshots/4.png",
                     "~/Content/Projects/Przypominajka/Screenshots/5.png",
                     "~/Content/Projects/Przypominajka/Screenshots/6.png",
                     "~/Content/Projects/Przypominajka/Screenshots/7.png",
                     "~/Content/Projects/Przypominajka/Screenshots/8.png",
                     "~/Content/Projects/Przypominajka/Screenshots/9.png",
                     "~/Content/Projects/Przypominajka/Screenshots/10.png",
                     "~/Content/Projects/Przypominajka/Screenshots/11.png",
                     "~/Content/Projects/Przypominajka/Screenshots/12.png",
                     "~/Content/Projects/Przypominajka/Screenshots/13.png",
                     "~/Content/Projects/Przypominajka/Screenshots/14.png",
                     "~/Content/Projects/Przypominajka/Screenshots/15.png",
                     "~/Content/Projects/Przypominajka/Screenshots/16.png",
                     "~/Content/Projects/Przypominajka/Screenshots/17.png"

                }
            },

            new Project(){
                NamePL = "Asystent wokalisty",
                NameENG = "Singer's assistant",
                LogoPath = "~/Content/Projects/Asystent_wokalisty/Thumbnail/asystent_wokalisty_miniatura.png",
                ShortDiscriptionPL = "Mo&shy;ja dru&shy;ga apli&shy;ka&shy;cja an&shy;dro&shy;ida na&shy;pi&shy;sa&shy;na w C# z uży&shy;ciem Xa&shy;ma&shy;rin.Forms. Umoż&shy;li&shy;wia ona do&shy;da&shy;nie utwo&shy;rów oraz two&shy;rze&shy;nie play&shy;list z tych utwo&shy;rów.Dla każ&shy;de&shy;go utwo&shy;ru moż&shy;li&shy;we jest po&shy;bra&shy;nie tek&shy;stu z tek&shy;sto&shy;wo&shy;.pl szu&shy;ka&shy;ne na pod&shy;sta&shy;wie ty&shy;tu&shy;łu, ar&shy;ty&shy;stu lub obu&shy;). Z wi&shy;do&shy;ku play&shy;li&shy;sty moż&shy;li&shy;we jest uru&shy;cho&shy;mie&shy;nie pre&shy;zen&shy;ta&shy;cji wy&shy;świe&shy;tla&shy;ją&shy;cej tekst wszyst&shy;kich utwó&shy;rów z tej play&shy;li&shy;sty w ko&shy;lej&shy;no&shy;ści ich wy&shy;stę&shy;po&shy;wa&shy;nia. Ro&shy;zmiar czcion&shy;ki jest z gó&shy;ry okre&shy;ślo&shy;ny ta&shy;k, by był czy&shy;tel&shy;ny, ale licz&shy;ba li&shy;nii tek&shy;stu jest okre&shy;śla&shy;na dla kon&shy;kret&shy;ne&shy;go urzą&shy;dze&shy;nia. Moż&shy;li&shy;we jest uży&shy;cie jed&shy;ne&shy;go urzą&shy;dze&shy;nia ja&shy;ko ser&shy;we&shy;ra do usta&shy;wia&shy;nia tek&shy;stó&shy;w, wy&shy;świe&shy;tla&shy;nia pre&shy;zen&shy;ta&shy;cji i zmia&shy;ny stron oraz in&shy;nych urzą&shy;dzeń ja&shy;ko klien&shy;tó&shy;w, któ&shy;re bę&shy;dą otrzy&shy;my&shy;wa&shy;ły tekst do wy&shy;świe&shy;tle&shy;nia z urzą&shy;dze&shy;nia bę&shy;dą&shy;ce&shy;go ser&shy;we&shy;rem. ",
                ShortDiscriptionENG = "My second android app wrote in C# with use Xamarin.Forms. The application allows you to add songs and create songs playlist. " +
                "You can get text from tekstowo.pl to current songs (searching by title or artist name or both). From playlist view you can run presentation of songs " +
                "text by order in playlist. Text size is fixed, but number of lines is calculated for device. You can use one devices as server to set text " +
                "presentation and changing pages and other devices in band can connect to server (server client socket solution) and text will automaticaly send to " +
                "clients. Any clients will see the same text in the same time like server device.",

                DiscriptionPL = "<h4>Okno główne</h4>" +
                "<p>Jest to li&shy;sta wszyst&shy;kich do&shy;da&shy;nych utwo&shy;rów. Umoż&shy;li&shy;wia za&shy;zna&shy;cza&shy;nie kon&shy;kret&shy;nych utwo&shy;rów oraz two&shy;rze&shy;nie z nich no&shy;wych play&shy;list. Po klik&shy;nię&shy;ciu na utwór wy&shy;świe&shy;tla&shy;ne są je&shy;go szcze&shy;gó&shy;ły oraz moż&shy;li&shy;wa jest je&shy;go edy&shy;cja lub usu&shy;nię&shy;cie. Wy&shy;świe&shy;tla&shy;na jest rów&shy;nież li&shy;sta play&shy;li&shy;st, do któ&shy;rych da&shy;ny utwór na&shy;le&shy;ży. </p><p></p>" +
                "<h4>Dodawanie utworu</h4>" +
                "<p>Ok&shy;no to da&shy;je moż&shy;li&shy;wość wy&shy;szu&shy;ka&shy;nia tek&shy;stu na pod&shy;sta&shy;wie ar&shy;ty&shy;sty, ty&shy;tu&shy;łu lub obu jed&shy;no&shy;cze&shy;śnie. Tekst po&shy;cho&shy;dzi z ko&shy;du html otrzy&shy;ma&shy;ne&shy;go z wy&shy;rzu&shy;ki&shy;wa&shy;nia na tek&shy;sto&shy;wo&shy;.pl. Do po&shy;praw&shy;ne&shy;go dzia&shy;ła&shy;nia ta&shy;kie&shy;go roz&shy;wią&shy;za&shy;nia wy&shy;ko&shy;rzy&shy;sta&shy;łem bi&shy;blio&shy;te&shy;kę HTMLAgi&shy;li&shy;ty&shy;Pack.  </p><p></p>" +
                "<h4>Ustawienia połączeń</h4>" +
                "<p>Z ich po&shy;zio&shy;mu moż&shy;li&shy;we jest uru&shy;cho&shy;mie&shy;nie ser&shy;we&shy;ra na wy&shy;bra&shy;nym urzą&shy;dze&shy;niu (IP jest z gó&shy;ry usta&shy;lo&shy;ne na pod&shy;sta&shy;wie po&shy;łą&shy;cze&shy;nia z sie&shy;cią więc moż&shy;li&shy;we jest np. uru&shy;cho&shy;mie&shy;nie hot&shy;spo&shy;tu na urza&shy;dze&shy;niu be&shy;da&shy;cym ser&shy;we&shy;re&shy;m, a na&shy;stęp&shy;nie pod&shy;łą&shy;cze&shy;nie do te&shy;go hot&shy;spo&shy;tu in&shy;nych urzą&shy;dze&shy;ń, ewen&shy;tu&shy;al&shy;nie po pro&shy;stu uży&shy;cie tej sa&shy;mej sie&shy;ci Wi&shy;Fi dla wszyst&shy;kich urzą&shy;dze&shy;ń). Pa&shy;ra&shy;me&shy;trem do okre&shy;śle&shy;nia jest je&shy;dy&shy;nie port (do&shy;myśl&shy;nie jest to 11000). Po uru&shy;cho&shy;mie&shy;niu ser&shy;we&shy;ra wy&shy;świe&shy;tla&shy;ny jest ko&shy;mu&shy;ni&shy;kat z licz&shy;bą pod&shy;łą&shy;czo&shy;nych urzą&shy;dzeń. Z za&shy;kład&shy;ki usta&shy;wień dla klien&shy;ta moż&shy;li&shy;we jest pod&shy;łą&shy;cze&shy;nie się do ser&shy;we&shy;ra na pod&shy;sta&shy;wie po&shy;da&shy;ne&shy;go IP i por&shy;tu oraz po po&shy;myśl&shy;nych pod&shy;łą&shy;cze&shy;niu, uru&shy;cho&shy;mie&shy;nie try&shy;bu pre&shy;zen&shy;ta&shy;cji, gdzie wy&shy;sła&shy;ny przez ser&shy;wer tekst bę&shy;dzie au&shy;to&shy;ma&shy;tycz&shy;nie wy&shy;świe&shy;tla&shy;ny.</p><p></p>" +
                "<h4>Lista playlist, ich szczegóły oraz prezentacja tekstu</h4>" +
                "<p>Z po&shy;zio&shy;mu li&shy;sty wi&shy;docz&shy;ne są wszyst&shy;kie stwo&shy;rzo&shy;ne play&shy;li&shy;sty. Po klik&shy;nię&shy;ciu na wy&shy;bra&shy;ną wy&shy;świe&shy;tla&shy;ne są jej szcze&shy;gó&shy;ły oraz mo&shy;zli&shy;wość edy&shy;cji (u&shy;su&shy;nię&shy;cie, do&shy;da&shy;wa&shy;nie oraz usu&shy;wa&shy;nie utwo&shy;ró&shy;w, edy&shy;cja na&shy;zwy oraz zmia&shy;na ko&shy;lej&shy;no&shy;ści utwo&shy;rów na play&shy;li&shy;ście&shy;). Op&shy;cje edy&shy;cji wy&shy;świe&shy;tla&shy;ne są po klik&shy;nię&shy;ciu przy&shy;ci&shy;sku edy&shy;tuj. Po uru&shy;cho&shy;mie&shy;niu try&shy;bu pre&shy;zen&shy;ta&shy;cji, je&shy;śli da&shy;ne urzą&shy;dze&shy;nie jest ser&shy;we&shy;re&shy;m, na&shy;stę&shy;pu&shy;je au&shy;to&shy;ma&shy;tycz&shy;ne wy&shy;sy&shy;ła&shy;nie tek&shy;stu na pod&shy;łą&shy;czo&shy;ne urzą&shy;dze&shy;nia. </p>",

                DiscriptionENG = "<h4>Main window</h4>" +
                "<p>The main window of this application is the list of added songs. From there, you can select songs and add them to your new playlist. In addition, when you click on a song, you can edit the song " +
                "along with the ability to delete the song or change information such as artist, title or lyrics (looks exactly like add song window) and see which playlist it is added to. </p><p></p>" +
                "<h4>Adding song</h4>" +
                "<p>From this window possible is looking for song text by only artist, only title or both. Text come from output html code from tekstowo.pl. To this solution I use HTMLAgilityPack.</p> <p></p>" +
                "<h4>Connection settings</h4>" +
                "<p>From connection settings window you can start server (IP is getting from connected network, so you can also run hotspot, connect other devices to server devices and this will be work) " +
                "on custom port (default is 11000). After start server this window inform about count of connected client. From client page of this window you can write IP and port and connect to server. " +
                "After connect from this page you can run presentation mode to getting text from server device. </p><p></p>" +
                "<h4>Playlists list, details and text presentation</h4>" +
                "<p>List of playlist show all created playlist. After click are show detail information about playlist with list of song. From there you can edit name, add or remove songs, change order of " +
                "current song or start text presentation. Edit options show after click on edit button. When text presentation start, if current device is server, automaticly start sending songs text to " +
                "clients devices.</p>",

                Technologies = "C#, Xamarin.Forms, Html Agility Pack, SQLite.NET",
                License = "Adware",
                SourceLink = "https://github.com/krzysztofrutana/Show-song-text",
                Platform = "Android",
                FilePath = "",
                ScreenshotPaths = new List<string>()
                {
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/1.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/2.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/3.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/4.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/5.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/6.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/7.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/8.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/9.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/10.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/11.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/12.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/13.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/14.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/15.png",
                    "~/Content/Projects/Asystent_wokalisty/Screenshots/16.png"

                } },

                 new Project(){
                    NamePL = "Strona internetowa restauracji Polonez w Rzeszowie",
                    NameENG = "Website of the Polonez restaurant in Rzeszów",
                    LogoPath = "~/Content/Projects/Polonez/Thumbnail/logo.png",
                    ShortDiscriptionPL = "Mo&shy;ja pierw&shy;sza sa&shy;mo&shy;dziel&shy;nie wy&shy;ko&shy;na&shy;na stro&shy;na z uży&shy;ciem Word&shy;press. Jest to pro&shy;sty pro&shy;jekt w for&shy;mie wi&shy;zy&shy;tów&shy;ki z krót&shy;kim opi&shy;se&shy;m, ga&shy;le&shy;rią zdję&shy;ć, ma&shy;pą do&shy;jaz&shy;du oraz me&shy;cha&shy;ni&shy;zmem for&shy;mu&shy;la&shy;rza kon&shy;tak&shy;to&shy;we&shy;go. Do jej stwo&shy;rze&shy;nia uży&shy;łem wtycz&shy;ki Ele&shy;men&shy;tor w dar&shy;mo&shy;wej wer&shy;sji.",
                    ShortDiscriptionENG = "My first self-made website using Wordpress. It is a simple project in the form of a business card with a short description, a photo gallery, an access map and a contact form mechanism. To create it, I used Elementor plugin in free version.",

                    SourceLink = "http://polonez.rzeszow.pl/",
                    ItsWebPage = true
                    },

                 new Project(){
                    NamePL = "Strona internetowa firmy Lewar",
                    NameENG = "Website of Lewar company",
                    LogoPath = "~/Content/Projects/Lewar/Thumbnail/logo.png",
                    ShortDiscriptionPL = "Dru&shy;gi pro&shy;jekt opar&shy;ty o Word&shy;press stwo&shy;rzo&shy;ny dla fir&shy;my Le&shy;war. Stro&shy;na wi&shy;zu&shy;al&shy;na stwo&shy;rzo&shy;na w wtycz&shy;ce Ele&shy;men&shy;tor w wer&shy;sji dar&shy;mo&shy;wej. Do&shy;dat&shy;ko&shy;wo dzię&shy;ki wtycz&shy;ce Wo&shy;oCom&shy;mer&shy;ce stro&shy;na za&shy;wie&shy;ra me&shy;cha&shy;nizm skle&shy;pu in&shy;ter&shy;ne&shy;to&shy;we&shy;go, gdzie klient bez&shy;pro&shy;ble&shy;mo&shy;wo mo&shy;że ku&shy;pić ofe&shy;ro&shy;wa&shy;ne przez fir&shy;mę pro&shy;duk&shy;ty.",
                    ShortDiscriptionENG = "The second project based on Wordpress created for the Lewar company. The visual part was created in Elementor plugin in the free version.Additionally, thanks to the WooCommerce plugin, the website contains an online store mechanism, where the customer can easily buy the products offered by the company.",

                    SourceLink = "https://lewar.net.pl/",
                    ItsWebPage = true
                 }

            };

            foreach (Project s in projects)
            {
                context.Projects.Add(s);
            }
            context.SaveChanges();
        }

    }
}
