

namespace DAModel.Core.Domain
{
    public class License
    {
        #region Public Properties

        public int Id { get; set; }
        public string LicenseString { get; set; }
        public string HKeyString { get; set; }
        public bool IsHKeyValid { get; set; }
        public virtual User User { get; set; }

        #endregion
    }
}
