using System.ComponentModel.DataAnnotations;

namespace TernopilDotNetDatabase
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
