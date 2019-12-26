using System;
using System.Collections.ObjectModel;

namespace DAModel.Core.Domain
{
    public class PSystem : ICloneable
    {
        #region Public Properties

        public int Id { get; set; }
        public string Indeks { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Company Company { get; set; }
        public virtual ObservableCollection<Profile> Profiles { get; set; }
        public virtual ObservableCollection<User> Users { get; set; }

        #endregion

        #region Constructors
        public PSystem()
        {
            Profiles = new ObservableCollection<Profile>();
            Users = new ObservableCollection<User>();
        }

        #endregion

        #region ICloneable Implementation
        public object Clone()
        {
            return new PSystem()
            {
                Id = this.Id,
                Indeks = this.Indeks,
                Name = this.Name,
                Description = this.Description
            };
        }

        #endregion

    }
}
