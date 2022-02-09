using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeChannelReader.Model
{
    public class YouTubeItem : NotifyBase
    {
        private string _iconUrl;
        public string IconUrl
        {
            get
            {
                return _iconUrl;
            }
            set
            {
                this._iconUrl = value;
                OnPropertyChanged();
            }
        }

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged();
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private string link;
        public string Link
        {
            get
            {
                return link;
            }

            set
            {
                link = value;
                OnPropertyChanged();
            }
        }

        private string author;
        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
                OnPropertyChanged();
            }
        }

        private DateTime pubDate;
        public DateTime PubDate
        {
            get
            {
                return pubDate;
            }

            set
            {
                pubDate = value;
                OnPropertyChanged();
            }
        }

        private string mediaUrl;
        public string MediaUrl
        {
            get
            {
                return mediaUrl;
            }
            set
            {
                mediaUrl = value;
                OnPropertyChanged();
            }
        }

        private string thumbnailUrl;
        public string ThumbnailUrl
        {
            get
            {
                return thumbnailUrl;
            }
            set
            {
                thumbnailUrl = value;
                OnPropertyChanged();
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }
    }
}
