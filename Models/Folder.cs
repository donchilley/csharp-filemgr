using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Folder.Models
{
    public class Folder
    {
        public Folder(string name, Folder[] folders, File.Models.File[] files)
        {
            Name = name;
            Folders = folders;
            Files = files;
        }

        public Folder(string name, int size, string path)
        {
            Name = name;
            Size = size;
            Path = path;
        }

        public string Name { get; set; }

        public string? Path { get; set; }
        public int? Size { get; set; }
        public Folder[]? Folders { get; set; }
        public File.Models.File[]? Files { get; set; }
    }
}