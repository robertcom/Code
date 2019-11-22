

namespace DAModel.Core.Domain
{
    public class Config
    {
        #region Public Properties
        public int Id { get; set; }
        public string LicenseString { get; set; }
        public int UsedHKeysCounter { get; set; }
        public int HKeysValidAmount { get; set; }
        public int CheckLicenseFreq { get; set; }
        public virtual User User { get; set; }

        #endregion
    }
}
