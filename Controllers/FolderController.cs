using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FolderController : Controller
    {

        private readonly ILogger<FolderController> _logger;

        public FolderController(ILogger<FolderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public JsonResult Get(string folder)
        {
            string searchDirectory = "./" + folder;
            DirectoryInfo di = new DirectoryInfo(@searchDirectory);

            string[] folderPaths = Directory.GetDirectories(@searchDirectory, "*", SearchOption.TopDirectoryOnly);
            DirectoryInfo[] diFolders = di.GetDirectories();
            Folder.Models.Folder[] folders = new Folder.Models.Folder[diFolders.Length];
            for (int i = 0; i < folders.Length; i++)
            {
                DirectoryInfo diInfo = diFolders[i];
                int size = diInfo.GetDirectories().Length + diInfo.GetFiles().Length;
                folders[i] = new Folder.Models.Folder(diInfo.Name, size, folderPaths[i]);
            }

            string[] filePaths = Directory.GetFiles(@searchDirectory, "*", SearchOption.TopDirectoryOnly);
            FileInfo[] diFiles = di.GetFiles();
            File.Models.File[] files = new File.Models.File[diFiles.Length];
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo fileInfo = diFiles[i];
                files[i] = new File.Models.File(fileInfo.Name, fileInfo.Length / 1028.0, filePaths[i]);
            }

            Folder.Models.Folder fldr = new Folder.Models.Folder("CurrentFolder", folders, files);
            return Json(fldr);
        }

    }
}