using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Projectwork_Store.Models
{
    public class Sticker
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100, ErrorMessage = "Il campo del nome non può contenere più di 100 caratteri")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100, ErrorMessage = "Il campo dell'opera non può contenere più di 100 caratteri")]
        public string Opera { get; set; }

        [Column(TypeName = "varchar(512)")]
        [StringLength(512, ErrorMessage = "Il link fornito non deve superare i 512 caratteri")]
        [Url]
        public string? Url_image { get; set; }

        //rel 1-n car
        [JsonIgnore]
        public List<Car> Cars { get; set; }

        public Sticker()
        {

        }
    }
}
