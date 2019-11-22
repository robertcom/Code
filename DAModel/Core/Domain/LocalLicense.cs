

namespace DAModel.Core.Domain
{
    public class LocalLicense
    {
        #region Public Properties

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string LicenseString { get; set; }
        public string HKeyString { get; set; }
        public int CheckLicenseFreq { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string CompanyIndeks { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string No { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual Picture Logo { get; set; }


        #endregion
    }
}
