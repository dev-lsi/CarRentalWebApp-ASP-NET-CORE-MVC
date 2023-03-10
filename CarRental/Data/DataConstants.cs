namespace CarRental.Data
{
    public class DataConstants
    {
        public class Car
        {
            public const int BrandNameMaxLength = 30;
            public const int BrandNameMinLength = 2;
            public const int ModelNameMaxLength = 30;
            public const int ModelNameMinLength = 2;
            public const int DescriptionMaxLength = 300;
            public const int DescriptionMinLength = 10;
            public const int CarYearMinValue = 1900;
            public const int CarYearMaxValue = 2099;
        }

        public class Dealer
        {
            public const int DealerNameMaxLength = 50;
            public const int PhoneNumberMaxLength = 30;
        }



    }
}
