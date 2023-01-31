using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Projectwork_Store.Models
{
    public class UserPurchase
    {
        [Key]
        public int Id { get; set; }
        public DateTime PurchaseData { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "Il testo fornito non deve superare i 50 caratteri")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "Il testo fornito non deve superare i 50 caratteri")]
        public string Surname { get; set; }
        [Column(TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "La mail fornita non deve superare i 50 caratteri")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(20)")]
        [StringLength(20, ErrorMessage = "Il numero fornito non deve superare i 20 caratteri")]
        public string Phone { get; set; }

        //rel 1-n car
        [JsonIgnore]
        public List<Car> Cars { get; set; }

        public UserPurchase()
        {

        }

    }
}