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
        public class Company
        {
            public const int CompanyNameMaxLength = 15;
            public const int CompanyNameMinLength = 3;

            public const int CompanyAddressMaxLength = 50;
            public const int CompanyAddressMinLength = 1;
        }
    }
}
