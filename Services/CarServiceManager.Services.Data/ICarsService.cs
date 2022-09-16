namespace CarServiceManager.Services.Data
{
    using System.Collections.Generic;

    public interface ICarsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllBrandsAsKeyValuePair();

        IEnumerable<KeyValuePair<string, string>> GetAllColorsAsKeyValuePair();
    }
}
