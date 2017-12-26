using System.ComponentModel.DataAnnotations;

namespace CoreApp.DbAccess.Models
{
    public class Unit
    {
        [Key]
        public int Code { get; set; }

        public string Description { get; set; }
    }
}
