using System;
using System.Collections.ObjectModel;

namespace DAModel.Core.Domain
{
    public class Material : ICloneable
    {
        #region Public Properties

        public int Id { get; set; }
        public string Indeks { get; set; } // Rodzaj stopu aluminium lub klasa stali
        public string Name { get; set; }
        public string Description { get; set; }
        public double fo { get; set; }
        public double fu { get; set; }
        public double E { get; set; }
        public bool IsActive { get; set; }
        public virtual ObservableCollection<Profile> Profiles { get; set; }

        #endregion

        #region Constructors

        public Material()
        {
            Profiles = new ObservableCollection<Profile>();
        }

        #endregion

        #region ICloneable Implementation
        public object Clone()
        {
            return new Material()
            {
                Id = this.Id,
                Indeks = this.Indeks,
                Name = this.Name,
                Description = this.Description,
                fo = this.fo,
                fu = this.fu,
                E = this.E,
                IsActive = this.IsActive
            };
        }

        #endregion
    }
}
