using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAModel.Core.Domain;
using SQLiteDapper;

namespace WpfApp_SQLite_Test
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string nazwaWlasnosci)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwaWlasnosci));
        }

        #endregion
      
        public ICollectionView ProfilesView
        {
            get { return CollectionViewSource.GetDefaultView(Profiles); }
        }


       
        private Profile _selectedProfile;
        public Profile SelectedProfile
        {
            get => _selectedProfile;
            set
            {
                _selectedProfile = value;
                OnPropertyChanged("SelectedProfile");
                EditProfileCommandHandler(this, null);
                //if (Profiles.Where(p=> p.Indeks==_selectedProfile.Indeks).Count() >= 2) { MessageBox.Show("Uwaga"); }
            }
        }

        private Profile _newProfile;
        public Profile NewProfile
        {
            get { return _newProfile; }
            set
            {
                _newProfile = value;
                OnPropertyChanged("NewProfile");
            }
        }

        public ObservableCollection<Profile> Profiles { get; set; }

        private bool _isAddProfileGridVisible;
        public bool IsAddProfileGridVisible
        {
            get => _isAddProfileGridVisible;
            set
            {
                _isAddProfileGridVisible = value;
                OnPropertyChanged("IsAddProfileGridVisible");
            }
        }

        private bool _isEditProfileGridVisible;
        public bool IsEditProfileGridVisible
        {
            get => _isEditProfileGridVisible;

            set
            {
                _isEditProfileGridVisible = value;
                OnPropertyChanged("IsEditProfileGridVisible");
            }
        }


        private string _phraseToSearch;
        public string PhraseToSearch
        {
            get { return _phraseToSearch; }
            set
            {
                _phraseToSearch = value;
                OnPropertyChanged("PhraseToSearch");
                ProfilesView.Refresh();
            }
        }

        private readonly UnitOfWork _unitOfWork;
        public MainWindow()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork(GetConnectionString());
            _newProfile = new Profile();
            _isEditProfileGridVisible = true;
            _isAddProfileGridVisible = false;
            Profiles = new ObservableCollection<Profile>(_unitOfWork.Profiles.GetProfiles());
            //ProfilesView.Filter = new Predicate<object>(o => FilterProfiles(o as Profile));
            ProfilesView.Filter = new Predicate<object>(o => _unitOfWork.Profiles.FilterProfiles(PhraseToSearch, o as Profile));
            DataContext = this;
        }

        public static string GetConnectionString(string id = "sqliteDapper")
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        #region Private Methods

        private void ClearProfileForm()
        {

        }

        #endregion


        private void SaveCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (IsAddProfileGridVisible)
            {
                //Profile profile = (FindResource("daProfile") as Profile).Clone() as Profile;
                try
                {
                    if (NewProfile.Indeks != null)
                    {
                        if (_unitOfWork.Profiles.AddProfile(NewProfile) == 1)
                        {
                            Profile profileFromDb = _unitOfWork.Profiles.LastProfile();
                            Profiles.Add(profileFromDb);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wyjątek: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (IsEditProfileGridVisible)
            {
                try
                {
                    _unitOfWork.Profiles.UpdateProfile(SelectedProfile);
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show("Wyjątek: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RemoveProfileCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (SelectedProfile.Indeks != null)
            {
                if (_unitOfWork.Profiles.RemoveProfile(SelectedProfile) == 1)
                    Profiles.Remove(SelectedProfile);
            }
        }

        private void AddProfileCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            IsEditProfileGridVisible = false;
            IsAddProfileGridVisible = true;
        }
        private void EditProfileCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            IsAddProfileGridVisible = false;
            IsEditProfileGridVisible = true;
        }

        private bool FilterProfiles(Profile profile)
        {
            return 
                PhraseToSearch == null ||
                profile.Indeks.ToUpper().Contains(PhraseToSearch.ToUpper()) || 
                profile.Name.ToUpper().Contains(PhraseToSearch.ToUpper());
        }
    }
}
