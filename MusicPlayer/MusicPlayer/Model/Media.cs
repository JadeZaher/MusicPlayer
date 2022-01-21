using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Model
{
    public class Media
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Thumbnail { get; set; }
        public string Url { get; set; }
        public string IsFeatured { get; set; }
        public bool IsRecent { get; internal set; }
        public string Artist { get; internal set; }
        public string CoverImage { get; internal set; }
    }
}
