namespace CarServiceManager.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "CarServiceManager";

        public const string AdministratorRoleName = "Administrator";

        public const string ManagerRoleName = "Manager";

        public const string MechanicRoleName = "Mechanic";

        public static class ManagerAccountsSeeding
        {
            public const string Email = "manager@carservice.com";
            public const string Password = "123123";
            public const string FullName = "Управител 1";
        }

        public static class BrandsSeeding
        {
            public const string Audi = "Audi";
            public const string BMV = "BMV";
            public const string Mercedes = "Mercedes";
            public const string VW = "VW";
        }

        public static class ColorsSeeding
        {
            public const string White = "бял";
            public const string Black = "черен";
            public const string GrayMetalic = "сив металик";
            public const string Red = "червен";
            public const string Blue = "син";
            public const string Green = "зелен";
        }
    }
}
