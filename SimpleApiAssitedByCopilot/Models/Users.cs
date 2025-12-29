using System.ComponentModel.DataAnnotations;

namespace SimpleApiAssitedByCopilot.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
