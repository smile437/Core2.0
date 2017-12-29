using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreApp.DbAccess.Models
{
    public class Unit
    {
        [Key]
        public int Code { get; set; }

        public string Description { get; set; }
    }
}
