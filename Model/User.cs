using System.ComponentModel.DataAnnotations;

namespace MysqlApi.Model
{
    public class User
    {

        [Required]
        public int Age { get; set; }
        
        [Required]
        public string? Name { get; set; }
        
        [Required]
        public int Id { get; set; }


    }
}
