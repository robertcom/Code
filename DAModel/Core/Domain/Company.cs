

namespace DAModel.Core.Domain
{
    public class Company
    {
        #region Public Properties

        public int Id { get; set; }
        public string Indeks { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string No { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public virtual string Country { get; set; }
        public virtual Logo Logo {get; set;}

        #endregion
    }
}
