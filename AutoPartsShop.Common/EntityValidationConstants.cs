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
            public const int VehicleMakeMinLength = 1;
            public const int VehicleMakeMaxLength = 15;

            public const int VehicleModelMinLength = 1;
            public const int VehicleModelMaxLength = 40;

            public const int VehicleModificationMinLength = 5;
            public const int VehicleModificationMaxLength = 70;

            public const int VehicleProductionYearMinLength = 4;
            public const int VehicleProductionYearMaxLength = 4;
        }

        public class Part
        {
            public const int PartNameMaxLength = 15;

            public const int PartDescriptionMaxLength = 300;
        }
        public class Seller
        {
            public const int SellerPhoneNumberMaxLength = 15;

            public const int SellerFirstNameMaxLength = 50;
            public const int SellerFirstNameMinLength = 5;

            public const int SellerLastNameMaxLength = 50;
            public const int SellerLastNameMinLength = 5;
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
