using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {

        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public JsonResult Get(string folder, string search)
        {
            string searchDirectory = "./" + folder;

            string[] returnedFiles = Directory.GetFiles(@searchDirectory, search + "*", SearchOption.AllDirectories);
            File.Models.File[] files = new File.Models.File[returnedFiles.Length];
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = new File.Models.File(returnedFiles[i], 0, returnedFiles[i]);
            }

            string[] returnedFolders = Directory.GetDirectories(@searchDirectory, search + "*", SearchOption.AllDirectories);
            Folder.Models.Folder[] folders = new Folder.Models.Folder[returnedFolders.Length];
            for (int i = 0; i < folders.Length; i++)
            {
                folders[i] = new Folder.Models.Folder(returnedFolders[i], 0, returnedFolders[i]);
            }

            Folder.Models.Folder results = new Folder.Models.Folder("SearchResults", folders, files);
            return Json(results);
        }

    }
}