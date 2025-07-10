namespace Yuumix.OdinToolkits.Common
{
    public static class YuumiZeus
    {
        public const string NAME = "Yuumi Zeus";
        public const string EMAIL = "zeriying@gmail.com";
        public const string LINK = "https://github.com/Yuumi-Zeus";

        public static ContributorInfo ToContributor(string time)
        {
            return new ContributorInfo(time, NAME, EMAIL, LINK);
        }
    }
}
