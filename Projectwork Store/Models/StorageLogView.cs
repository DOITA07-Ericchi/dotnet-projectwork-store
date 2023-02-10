namespace Projectwork_Store.Models
{
    public class StorageLogView
    {
        public Car Car { get; set; }
        public List<UserPurchase>? UserPurchases { get; set; }
        public List<SupplierPurchase>? SupplierPurchases {get; set;}
    }
}
