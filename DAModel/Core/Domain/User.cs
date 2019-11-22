using System.Collections.ObjectModel;

namespace DAModel.Core.Domain
{
    public class User
    {
        #region Public Properties
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string TempCompany { get; set; }
        public virtual Company Company { get; set; }
        public virtual ObservableCollection<PSystem> Systems { get; set; }
        public virtual ObservableCollection<License>  Licenses { get; set; }
        public virtual Config Configuration { get; set; }

        #endregion

        #region Constructors
        public User()
        {
            Systems = new ObservableCollection<PSystem>();
            Licenses = new ObservableCollection<License>();
        }

        #endregion
    }
}
