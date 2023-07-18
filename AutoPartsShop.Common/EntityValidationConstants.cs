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
            public const int PartNameMinLength = 3;
            public const int PartNameMaxLength = 15;

            public const int PartDescriptionMaxLength = 300;
        }
        public class Seller
        {
            public const int SellerFirstNameMaxLength = 50;
            public const int SellerFirstNameMinLength = 5;

            public const int SellerLastNameMaxLength = 50;
            public const int SellerLastNameMinLength = 5;

            public const string SellerPhoneNumberRegularExpression = "^\\+[0-9]{12}|0[0-9]{9}";
        }
        public class Company
        {
            public const int CompanyNameMaxLength = 15;
            public const int CompanyNameMinLength = 3;

            public const int CompanyAddressMaxLength = 50;
            public const int CompanyAddressMinLength = 1;
        }
        public class Orders
        {
            public const int OrderFirstNameMaxLength = 50;
            public const int OrderFirstNameMinLength = 5;

            public const int OrderLastNameMaxLength = 50;
            public const int OrderLastNameMinLength = 5;

            public const string OrderContactPhoneNumberRegularExpression = "^\\+[0-9]{12}|0[0-9]{9}";

            public const int OrderDeliveryAddressMaxLength = 38;
            public const int OrderDeliveryAddressMinLength = 5;
        }


    }
}
