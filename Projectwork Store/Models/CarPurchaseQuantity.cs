namespace Projectwork_Store.Models
{
    public class CarPurchaseQuantity
    {

        public int IdCar { get; set; }
        public int CarQuantity { get; set; }

        public CarPurchaseQuantity(int idCar, int carQuantity)
        {
            IdCar = idCar;
            CarQuantity = carQuantity;
        }


    }
}
