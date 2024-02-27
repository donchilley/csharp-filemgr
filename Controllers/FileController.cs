using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : Controller
    {

        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Download(string fileName)
        {
            var memoryStream = new MemoryStream();

            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memoryStream);
            }
            memoryStream.Position = 0;

            return File(memoryStream, "text/plain", Path.GetFileName(fileName));
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            long size = file.Length;
            if (file.Length > 0)
            {
                using (var stream = System.IO.File.Create("./uploads/" + file.FileName))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Ok(new { count = 1, size });
        }


    }
}