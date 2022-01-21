using MusicPlayer.Model;
using MusicPlayer.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicPlayer.ViewModel
{
    public class FrequencyLibraryVM : BaseVM
    {
        public FrequencyLibraryVM()
        {
            mediaList = GetMedia();
            recentMedia = mediaList.Where(x => x.IsRecent == true).FirstOrDefault();
        }

        ObservableCollection<Media> mediaList;
        public ObservableCollection<Media> MediaList
        {
            get { return mediaList; }
            set
            {
                mediaList = value;
                OnPropertyChanged();
            }
        }

        private Media recentMedia;
        public Media RecentMedia
        {
            get { return recentMedia; }
            set
            {
                recentMedia = value;
                OnPropertyChanged();
            }
        }

        private Media selectedMedia;
        public Media SelectedMedia
        {
            get { return selectedMedia; }
            set
            {
                selectedMedia = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(PlayMedia);

        private void PlayMedia()
        {
            if (selectedMedia != null)
            {
                var viewModel = new FrequencyPlayerVM(selectedMedia, mediaList);
                var playerPage = new FrequencyPlayer { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(playerPage, true);
            }
        }

        private ObservableCollection<Media> GetMedia()
        {
            return new ObservableCollection<Media>
            {
                new Media { Title = "Beach Walk", Artist = "Unicorn Heads", Url = "https://devcrux.com/wp-content/uploads/Beach_Walk.mp3", CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRU6FVly4jMTD3AKB_sHxqPofJVQwqqUj5peEvgA1H4XegM3uJ7&usqp=CAU", IsRecent = true},
                new Media { Title = "I'll Follow You", Artist = "Density & Time", Url = "https://devcrux.com/wp-content/uploads/I_ll_Follow_You.mp3", CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRm-su97lHFGZrbR6BkgL32qbzZBj2f3gKGrFR0Pn66ih01SyGj&usqp=CAU"},
                new Media { Title = "Ancient", Artist = "Density & Time", Url = "https://devcrux.com/wp-content/uploads/Ancient.mp3"},
                new Media { Title = "News Room News", Artist = "Spence", Url = "https://devcrux.com/wp-content/uploads/Cats_Searching_for_the_Truth.mp3"},
                new Media { Title = "Bro Time", Artist = "Nat Keefe & BeatMowe", Url = "https://devcrux.com/wp-content/uploads/Bro_Time.mp3"},
                new Media { Title = "Cats Searching for the Truth", Artist = "Nat Keefe & Hot Buttered Rum", Url = "https://devcrux.com/wp-content/uploads/Cats_Searching_for_the_Truth.mp3"}
            };
        }
    }
}
