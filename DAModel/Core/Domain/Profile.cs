using System;

namespace DAModel.Core.Domain
{
    public class Profile : ICloneable
    {
        #region Public Properties

        public int Id { get; set; }
        public string Indeks { get; set; }
        public string Name { get; set; }
        public double? Ixmm4 { get; set; }
        public double? Iymm4 { get; set; }
        public double? Wxmm3 { get; set; }
        public double? Wymm3 { get; set; }
        public double? Scmm { get; set; }
        public double? Stmm { get; set; }
        public double? Symm { get; set; }
        public double? Amm2 { get; set; }
        public double? Ix { get; set; }
        public double? Iy { get; set; }
        public double? Wx { get; set; }
        public double? Wy { get; set; }
        public double? A { get; set; }
        public double? Weight { get; set; }
        public double? Ixeff { get; set; }
        public double? Aeff { get; set; }
        public bool IsActive { get; set; }
        public bool IsInsulated { get; set; }
        public bool? IsMullion { get; set; }
        public bool? IsTransom { get; set; }
        public int? Sort { get; set; }
        public virtual Material Material { get; set; }
       // public virtual Picture Picture { get; set; }
        public virtual PSystem System { get; set; }

        #endregion

        #region ICloneable implementation
        public object Clone()
        {
            return new Profile()
            {
                Id = this.Id,
                Indeks = this.Indeks,
                Name = this.Name,
                Ixmm4= this.Ixmm4,
                Iymm4= this.Iymm4,
                Wxmm3 = this.Wxmm3,
                Wymm3 = this.Wymm3,
                Scmm = this.Scmm,
                Stmm = this.Stmm,
                Symm = this.Symm,
                Amm2 = this.Amm2,
                Ix = this.Ix,
                Iy = this.Iy,
                Wx= this.Wx,
                Wy = this.Wy,
                A = this.A,
                Weight = this.Weight,
                Ixeff = this.Ixeff,
                Aeff = this.Aeff,
                IsActive = this.IsActive,
                IsInsulated = this.IsInsulated,
                IsMullion = this.IsMullion,
                IsTransom = this.IsTransom,
                Sort = this.Sort,
                Material = this.Material.Clone() as Material,
                //Picture = this.Picture.Clone() as Picture,
                System = this.System.Clone() as PSystem
            };
        }
        #endregion
    }
}
