using MusicPlayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MusicPlayer.ViewModel
{
    public class FrequencyPlayerVM : BaseVM
    {
        private Media selectedMedia;
        private ObservableCollection<Media> mediaList;

        public FrequencyPlayerVM(Media selectedMedia, ObservableCollection<Media> mediaList)
        {
            this.selectedMedia = selectedMedia;
            this.mediaList = mediaList;
        }
    }
}
