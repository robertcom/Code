using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAModel.Core.Domain;
using DAModel.Core.Repositories;

namespace SQLiteDapper.Repositories
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public string ConnectionString { get; }
        public ProfileRepository()
        { }

        public ProfileRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public IEnumerable<Profile> GetProfiles()
        {
            using (IDbConnection cnn = new SQLiteConnection(ConnectionString))
            {
                return cnn.Query<Profile>("SELECT * FROM Profile", new DynamicParameters()).ToList();
            }
        }

        public int AddProfile(Profile profile)
        {
            using (IDbConnection cnn = new SQLiteConnection(ConnectionString))
            {
                return cnn.Execute("INSERT INTO Profile ('Indeks', 'Name', 'Ix', 'Iy') VALUES (@Indeks, @Name, @Ix, @Iy)", profile); 
            }
        }
        public int RemoveProfile(Profile profile)
        {
            using (IDbConnection cnn = new SQLiteConnection(ConnectionString))
            {
                return cnn.Execute("DELETE FROM Profile WHERE Id = @Id", profile);
            }
        }

        public int UpdateProfile(Profile profile)
        {
            using (IDbConnection cnn = new SQLiteConnection(ConnectionString))
            {
                return cnn.Execute("UPDATE Profile SET " +
                    "'Indeks'= @Indeks, " +
                    "'Name'= @Name, " +
                    "'Ix' = @Ix, "+
                    "'Iy' = @Iy"+
                    " WHERE Id = @Id", profile);
            }
        }

        public IEnumerable<Profile> FindAndGetProfiles(IEnumerable<Profile> profiles ,Func<Profile, bool> predicate)
        {
            return profiles.Where(predicate);
        }

        public Profile LastProfile()
        {
            using (IDbConnection cnn = new SQLiteConnection(ConnectionString))
            {
                return (Profile)(cnn.Query<Profile>("SELECT * FROM Profile ORDER BY Indeks DESC LIMIT 1", new DynamicParameters())).First();
            }
        }

        public void ClearProfile(Profile profile)
        {
            if (profile!=null)
            {
                profile.Indeks = "";
                profile.Name = "";
                profile.Ix = 0.00;
                profile.Iy = 0.00;
            }
        }

        public bool FilterProfiles(string Phrase, Profile profile)
        {
            return
               Phrase == null ||
               profile.Indeks.ToUpper().Contains(Phrase.ToUpper()) ||
               profile.Name.ToUpper().Contains(Phrase.ToUpper());
        }
    }
}
