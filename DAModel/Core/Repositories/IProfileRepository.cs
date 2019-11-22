using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAModel.Core.Domain;

namespace DAModel.Core.Repositories
{
    public interface IProfileRepository : IRepository<Profile>
    {
        string ConnectionString { get; }
        IEnumerable<Profile> GetProfiles();

        IEnumerable<Profile> FindAndGetProfiles(IEnumerable<Profile> profiles, Func<Profile,bool> predicate);
        int AddProfile(Profile profile);
        int RemoveProfile(Profile profile);
        int UpdateProfile(Profile profile);
        Profile LastProfile();
        void ClearProfile(Profile profile);

        bool FilterProfiles(string Phrase, Profile profile);
    }
}
