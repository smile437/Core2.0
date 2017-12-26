using System.ComponentModel.DataAnnotations;

namespace CoreApp.DbAccess.Models
{
    public class Type
    {
        [Key]
        public int Code { get; set; }

        public string Description { get; set; }
    }
}
