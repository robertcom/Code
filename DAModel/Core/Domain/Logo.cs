using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAModel.Core.Domain
{
    public class Logo
    {
        #region Public Properties

        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public virtual Company Company { get; set; }

        #endregion
    }
}
