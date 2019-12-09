using System;
using System.Collections.ObjectModel;

namespace DAModel.Core.Domain
{
    public class Producer : ICloneable
    {
        #region Public Properties

        public int Id { get; set; }
        public string Indeks { get; set; }
        public string Name { get; set; }
        public virtual Company Company { get; set; }
        public virtual ObservableCollection<PSystem> Systems { get; set; }

        #endregion

        public Producer()
        {
            Systems = new ObservableCollection<PSystem>();
        }

        #region ICloneable Implementation
        public object Clone()
        {
            return new Producer()
            {
                Id = this.Id,
                Indeks = this.Indeks,
                Name = this.Name
            };
        }

        #endregion
    }
}
