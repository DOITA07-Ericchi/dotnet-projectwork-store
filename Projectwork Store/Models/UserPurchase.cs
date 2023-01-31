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
        public DateTime PurchaseDate { get; set; }
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


        public int CarId { get; set; }
        public Car? Car { get; set; }


        public UserPurchase()
        {

        }

    }
}