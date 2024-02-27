using System.ComponentModel.DataAnnotations;

namespace File.Models
{
    public class File
    {
        public File(string name, double size, string path)
        {
            Name = name;
            Size = size;
            Path = path;
        }
        public double Size { get; set; }
        public string? Name { get; set; }

        public string? Path {get; set;}
    }
}