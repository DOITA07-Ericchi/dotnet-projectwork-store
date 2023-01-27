using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projectwork_Store.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100, ErrorMessage = "Il campo del nome non può contenere più di 100 caratteri")]
        public string Name { get; set; }

        //rel. 1-n car
        public List<Car> Cars { get; set; }

        public Category()
        {

        }
    }
}
