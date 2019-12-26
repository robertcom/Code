

using System.Collections.ObjectModel;

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
        public bool IsVisible { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsProducer { get; set; }
        public virtual string Country { get; set; }
        public virtual Logo Logo {get; set;}
        public virtual ObservableCollection<PSystem> Systems { get; set; }

        #endregion
    }
}
