namespace AutoPartsShop.Common
{
    public class EntityValidationConstants
    {
        public class VehicleCategory
        {
            public const int CategoryNameMaxLength = 50;
        }

        public class Vehicle
        {
            public const int VehicleMakeMaxLength = 15;

            public const int VehicleModelMaxLength = 40;

            public const int VehicleModificationMaxLength = 70;
        }

        public class Part
        {
            public const int PartNameMaxLength = 15;

            public const int PartDescriptionMaxLength = 300;
        }
        public class Seller
        {
            public const int SellerPhoneNumberMaxLength = 15;
        }
    }
}
