using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Projectwork_Store.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100, ErrorMessage = "Il testo non deve superare i 100 caratteri")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }


        [Column(TypeName = "varchar(512)")]
        [StringLength(512, ErrorMessage = "Il testo non deve superare i 512 caratteri")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(24)")]
        [StringLength(24, ErrorMessage = "Il testo non deve superare i 24 caratteri")]
        public string Color { get; set; }

        public double Price { get; set; }

        [Column(TypeName = "varchar(512)")]
        [StringLength(512, ErrorMessage = "Il link fornito non deve superare i 512 caratteri")]
        [Url]
        public string Url_image { get; set; }

        public int Quantity { get; set; }

        public int StickerId { get; set; }

        public Sticker? Sticker { get; set; }


        public int? N_like { get; set; }


        //rel 1-n UserPurchase
        [JsonIgnore]
        public List<UserPurchase>? UserPurchases { get; set; }

        //rel 1-n SupplierPurchase
        [JsonIgnore]
        public List<SupplierPurchase> SupplierPurchases { get; set; }


        public Car()
        {

        }

        public Car(string name, int categoryId, string description, string color, int price, string url_image)
        {
            Name = name;
            CategoryId = categoryId;
            Description = description;
            Color = color;
            Price = price;
            Url_image = url_image;
        }
    }
}
