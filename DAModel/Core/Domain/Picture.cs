using System;

namespace DAModel.Core.Domain
{
    public class Picture: ICloneable
    {
        #region Public Properties

        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Profile Profile { get; set; }
       // public Company Company { get; set; }

        #endregion

        #region ICloneable Implementation

        public object Clone()
        {
            return new Picture()
            {
                Id = this.Id,
                FileName = this.FileName,
                Description = this.Description,
                Path = this.Path,
                Width = this.Width,
                Height = this.Height
            };
        }

        #endregion

    }
}
