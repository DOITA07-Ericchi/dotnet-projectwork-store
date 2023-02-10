using ProjectworkStore.Migrations;

namespace Projectwork_Store.Models
{
    public class CarClientPurchase
    {
        public int Id { get; set; }
        public UserPurchase Purchase { get; set; }
        public Car? Car { get; set; }
        
    }
}
